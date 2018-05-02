using UnityEngine;
using System.Collections;
using System.Collections.Generic;
public class AStarModifiedAlgo : MonoBehaviour {
    //
	public int nodesVisited;
	private int count;
	public int tempCount;
	GameObject[] QueueToArray;
	int childAccesed = 0;
	public Queue<GameObject> open = new Queue<GameObject> ();
	public Queue<GameObject> closed = new Queue<GameObject> ();
	float[] fValuesOfChild = new float[5];
	public Stack<GameObject> AStarModifiedSearch ( GameObject start, GameObject goal ) {
		Dictionary<GameObject, GameObject> parent = new Dictionary<GameObject, GameObject> ();

		float g, f,h;
		float newg;
		float timeToCompute = 0f;

		Stack<GameObject> s = new Stack<GameObject> ();

		int i, j;

		GameObject temp = null;
		GameObject n, child = null;
		
		parent[start] = null;
		open.Enqueue ( start );

		while ( open.Count > 0 ) {
			n = open.Dequeue ();

			if ( n == goal ) {
				s.Push ( goal );
				while ( goal != start ) {

					s.Push ( parent[goal] );
					
					goal = parent[goal];
				}
				return s;
			}

			foreach ( GameObject go in n.GetComponent<Waypoint_AStar_Modified> ().children ) {

				child = go;
				newg = n.GetComponent<Waypoint_AStar_Modified>().gValue +
					Vector3.Distance ( n.transform.position, child.transform.position );

				if ( ( open.Contains ( child ) || closed.Contains ( child ) )
					&& child.GetComponent<Waypoint_AStar_Modified> ().gValue <= newg ) {
						GetNodesVisisted (); 
					continue;
				}
			

				//if ( child.GetComponent<Waypoint_AStar_Modified> ().goalVisisted != true )
					
			
				parent[child] = n;
				child.GetComponent<Waypoint_AStar_Modified> ().gValue = newg;
				child.GetComponent<Waypoint_AStar_Modified> ().hValue = Vector3.Distance ( child.transform.position, goal.transform.position );
				child.GetComponent<Waypoint_AStar_Modified> ().fValue =
					 child.GetComponent<Waypoint_AStar_Modified> ().gValue / 99f + child.GetComponent<Waypoint_AStar_Modified> ().hValue * 99f;
//				Debug.Log ( child.GetComponent<Waypoint_AStar_Modified> ().fValue );
				fValuesOfChild[childAccesed] = child.GetComponent<Waypoint_AStar_Modified> ().fValue;
				/*childAccesed++;

				if ( childAccesed != 1 ) {
					if ( fValuesOfChild[childAccesed - 1] == fValuesOfChild[childAccesed] ) {
						GetNodesVisisted ();
					}
				}
				 * */
				if ( closed.Contains ( child ) ) {
					closed.Dequeue ();
					//GetNodesVisisted (); 
				}
				if ( open.Contains ( child ) == false ) {
					open.Enqueue ( child );
					//GetNodesVisisted (); 
				}

				else {
					//GetNodesVisisted (); 
					QueueSort ();//requeue
				}
			}

			closed.Enqueue ( n );
		}
		return null;
	}
	public void GetNodesVisisted () {
		count++;
		tempCount = count;
	}

	public int AstarModifiedSendVisited () {
		return tempCount;
	}


	public void QueueSort () {
		int i, j;
		GameObject temp;
		QueueToArray = open.ToArray ();
		for ( i = QueueToArray.Length - 2; i >= 0; i-- ) {
			for ( j = 0; j <= i; j++ ) {
				if ( QueueToArray[j].GetComponent<Waypoint_AStar_Modified> ().fValue >
						QueueToArray[j + 1].GetComponent<Waypoint_AStar_Modified> ().fValue ) {
					temp = QueueToArray[j];
					QueueToArray[j] = QueueToArray[j + 1];
					QueueToArray[j + 1] = temp;
				}
			}
		}
		open.Clear ();
		for ( i = 0; i < QueueToArray.Length; i++ ) {
			open.Enqueue ( QueueToArray[i] );
		}
	}
}

/*

using UnityEngine;
using System.Collections;
using System.Collections.Generic;
public class AStarModifiedAlgo : MonoBehaviour {

	public int nodesVisited;
	private int count;
	public int tempCount;
	GameObject[] QueueToArray;
	public Queue<GameObject> open = new Queue<GameObject> ();
	public Queue<GameObject> closed = new Queue<GameObject> ();

	public Stack<GameObject> AStarModifiedSearch ( GameObject start, GameObject goal ) {
		Dictionary<GameObject, GameObject> parent = new Dictionary<GameObject, GameObject> ();

		float g, f, newg, h;
		float timeToCompute = 0f;

		Stack<GameObject> s = new Stack<GameObject> ();

		int i, j;

		GameObject temp = null;
		GameObject n, child = null;
		
		parent[start] = null;
		open.Enqueue ( start );

		while ( open.Count > 0 ) {
			n = open.Dequeue ();

			if ( n == goal ) {
				s.Push ( goal );
				while ( goal != start ) {

					s.Push ( parent[goal] );
					
					goal = parent[goal];
				}
				return s;
			}

			foreach ( GameObject go in n.GetComponent<Waypoint_AStar_Modified> ().children ) {
				child = go;
				newg = n.GetComponent<Waypoint_AStar_Modified> ().gValue +
					Vector3.Distance ( n.transform.position, child.transform.position );

				if ( ( open.Contains ( child ) || closed.Contains ( child ) )
					&& child.GetComponent<Waypoint_AStar_Modified> ().gValue <= newg ) {
					
					continue;
				}
			

				//if ( child.GetComponent<Waypoint_AStar_Modified> ().goalVisisted != true )
					
			
				parent[child] = n;
				child.GetComponent<Waypoint_AStar_Modified> ().gValue = newg;
				child.GetComponent<Waypoint_AStar_Modified> ().hValue = Vector3.Distance ( child.transform.position, goal.transform.position );
				child.GetComponent<Waypoint_AStar_Modified> ().fValue = 
					child.GetComponent<Waypoint_AStar_Modified> ().gValue / 5F * child.GetComponent<Waypoint_AStar_Modified> ().hValue * 5F;

				
				if ( closed.Contains ( child ) ) {
					closed.Dequeue ();
				}
				if ( open.Contains ( child ) == false ) {
					open.Enqueue ( child );
					GetNodesVisisted ();
				}

				else {
					//GetNodesVisisted ();
					QueueSort ();//requeue
				}
			}

			closed.Enqueue ( n );
		}
		return null;
	}
	public void GetNodesVisisted () {
		count++;
		tempCount = count;
	}

	public int AstarModifiedSendVisited () {
		return tempCount;
	}


	public void QueueSort () {
		int i, j;
		GameObject temp;
		QueueToArray = open.ToArray ();
		for ( i = QueueToArray.Length - 2; i >= 0; i-- ) {
			for ( j = 0; j <= i; j++ ) {
				if ( QueueToArray[j].GetComponent<Waypoint_AStar_Modified> ().fValue >
						QueueToArray[j + 1].GetComponent<Waypoint_AStar_Modified> ().fValue ) {
					temp = QueueToArray[j];
					QueueToArray[j] = QueueToArray[j + 1];
					QueueToArray[j + 1] = temp;
				}
			}
		}
		open.Clear ();
		for ( i = 0; i < QueueToArray.Length; i++ ) {
			open.Enqueue ( QueueToArray[i] );
		}
	}
}


*/