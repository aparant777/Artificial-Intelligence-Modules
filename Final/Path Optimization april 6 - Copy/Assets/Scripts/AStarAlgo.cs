using UnityEngine;
using System.Collections;
using System.Collections.Generic;
public class AStarAlgo : MonoBehaviour {

	public int nodesVisited;
	private int count;
	public int tempCount;
	GameObject[] QueueToArray;
	public Queue<GameObject> open = new Queue<GameObject> ();
	public Queue<GameObject> closed = new Queue<GameObject> ();

	public Stack<GameObject> AStarSearch ( GameObject start, GameObject goal ) {
		Dictionary<GameObject, GameObject> parent = new Dictionary<GameObject, GameObject> ();	
		Dictionary<GameObject, float> f_value = new Dictionary<GameObject, float> ();
        
		float g, f, newg, h;
		float timeToCompute = 0f;
		
		Stack<GameObject> s = new Stack<GameObject> ();
	
		int i, j;
		
		GameObject temp = null;
		GameObject n, child = null;
		//start.GetComponent<Waypoint_AStar> ().isVisited = true;
		//n.GetComponent<Waypoint_AStar> ().goalVisisted = true;
		parent[start] = null;
		open.Enqueue ( start );

		while( open.Count > 0 ) {
			n = open.Dequeue ();

			///Debug.Log (n.GetComponent<Waypoint_BFS> ().isVisited = true );
			///Debug.Log ( "goal is " + goal );
			
			if ( n == goal ) {
				s.Push ( goal );
				while ( goal != start ) {
					
					s.Push ( parent[goal] );
					//Debug.Log ( parent[goal] );
					goal = parent[goal];
				}
				//			
				//Debug.Log ( "path computed of Astar in "+timeToCompute +"ms");
				return s;
				//return true;
			}

			foreach ( GameObject go in n.GetComponent<Waypoint_AStar> ().children ) {
				child = go;
				newg = n.GetComponent<Waypoint_AStar>().gValue +
					Vector3.Distance ( n.transform.position, child.transform.position ); //+ Vector3.Distance(child.transform.position, goal.transform.position);
				///Debug.Log ( "child is " + child );
				if ((open.Contains ( child ) || closed.Contains (child)) 
					&& child.GetComponent<Waypoint_AStar>().gValue <=newg){
						GetNodesVisisted (); 

					continue;
				}
				//if ( child.GetComponent<Waypoint_AStar> ().isVisited == false ) {
					///Debug.Log ( "i am here" );
					
				//if ( child.GetComponent<Waypoint_AStar> ().goalVisisted != true )
					 
				//GetNodes ();
//				Debug.Log ( nodesExamined );
				parent[child] = n;	
				child.GetComponent<Waypoint_AStar>().gValue = newg;
				child.GetComponent<Waypoint_AStar>().hValue = Vector3.Distance(child.transform.position, goal.transform.position);
				child.GetComponent<Waypoint_AStar> ().fValue = child.GetComponent<Waypoint_AStar> ().gValue + child.GetComponent<Waypoint_AStar> ().hValue;
				
				//Debug.Log ( "g is " + g );
				//Debug.Log ( "h is " + h );
				//Debug.Log ( "f is " + f );
				if(closed.Contains(child)) {
					closed.Dequeue();
					//GetNodesVisisted (); 
				}
				if(	open.Contains(child) == false) {
					open.Enqueue(child);
					//GetNodesVisisted (); 

				}

				else {
					//GetNodesVisisted (); 
					QueueSort ();//requeue
				}
			}
			
			closed.Enqueue (n);
		}
		return null;	
	}
	public void GetNodesVisisted () {
		count++;
		tempCount = count;
	}

	public int AstarSendVisited () {
		return tempCount;
	}


	public void QueueSort () {
		int i, j;
		GameObject temp;
		QueueToArray = open.ToArray ();
		for ( i = QueueToArray.Length - 2; i >= 0; i-- ) {
			for ( j = 0; j <= i; j++ ) {
				if ( QueueToArray[j].GetComponent<Waypoint_AStar> ().fValue >
						QueueToArray[j + 1].GetComponent<Waypoint_AStar> ().fValue ) {
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