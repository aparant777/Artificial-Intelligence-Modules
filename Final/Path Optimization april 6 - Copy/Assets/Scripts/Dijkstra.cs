//--------------------------------------------------------------------------------------

using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public  class Dijkstra : MonoBehaviour{

	private int count;
	public int tempCount;
	public GameObject[] QueueToArray;
	Queue<GameObject> open = new Queue<GameObject> ();

	public Stack<GameObject> ComputePath ( GameObject start, GameObject goal ) {

		Dictionary<GameObject, GameObject> parent = new Dictionary<GameObject, GameObject> ();
		
		Dictionary<GameObject, float> costToGoal = new Dictionary<GameObject, float>();
	
		//float lowestCost = Mathf.Infinity;
		//GameObject shortestNode = null;
		Stack<GameObject> s = new Stack<GameObject> ();
		GameObject n, child = null;
		float newCost;
		parent[start] = null;
		start.GetComponent<Waypoint_Dijkstra> ().nodeCost = 0;
		open.Enqueue ( start );
		while ( open.Count > 0 ) {
			n = open.Dequeue ();
			n.GetComponent<Waypoint_Dijkstra> ().setVisited = true;
			if ( n == goal ) {
				s.Push ( goal );
				while ( goal != start ) {
					s.Push ( parent[goal] );
					goal = parent[goal];
				}
				return s;
			}
			foreach ( GameObject go in n.GetComponent<Waypoint_Dijkstra> ().neighbors ) {
				child = go;
				GetNodesVisisted ();
				newCost = n.GetComponent<Waypoint_Dijkstra>().nodeCost + 
					Vector3.Distance(n.transform.position, go.transform.position);

				if ( child.GetComponent<Waypoint_Dijkstra> ().setVisited == true ) {
					continue;
				}

				if(open.Contains(child) && child.GetComponent<Waypoint_Dijkstra>().nodeCost <= newCost)
					continue;

				parent[child] = n;

				child.GetComponent<Waypoint_Dijkstra> ().nodeCost = newCost;

				if ( !open.Contains ( child ) ) {
					open.Enqueue ( child );
				}

				else {
					QueueSort (); //reenqueue
				}
				
			}
		}
		return null;
	}

	public void QueueSort () {
		int i ,j;
		GameObject temp;
		QueueToArray = open.ToArray();
		for ( i = QueueToArray.Length-2 ; i >= 0 ; i-- ) {
			for ( j = 0 ; j <= i ; j++ ) {
				if( QueueToArray[j].GetComponent<Waypoint_Dijkstra>().nodeCost > 
						QueueToArray[j+1].GetComponent<Waypoint_Dijkstra>().nodeCost ) {
					temp = QueueToArray[j];
					QueueToArray[j] = QueueToArray[j+1];
					QueueToArray[j+1] = temp;
				}
			}
		}
		open.Clear();
		for ( i=0; i<QueueToArray.Length; i++) {
			open.Enqueue(QueueToArray[i]);
		}	
	}

	public void GetNodesVisisted () {
		count++;
		tempCount = count;
	}

	public int DijkstraSendVisited () {
		return tempCount;
	}
}

/*

/*
 * Author(s)	:	Aparant Mane, Ashish Pardhiye, Tejas Lad
 * Purpose		:	Core Algorithm
 * Dependencies	:	Node.cs
 

//--------------------------------------------------------------------------------------

using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public  class Dijkstra : MonoBehaviour{

	public static Stack<GameObject> ComputePath ( GameObject start, GameObject goal ) {

		Dictionary<GameObject, GameObject> parent = new Dictionary<GameObject, GameObject> ();
		Queue<GameObject> open = new Queue<GameObject> ();
		Dictionary<GameObject, float> costToGoal = new Dictionary<GameObject, float>();
		float lowestCost = Mathf.Infinity;
		GameObject shortestNode = null;
		Stack<GameObject> s = new Stack<GameObject> ();
		GameObject n, child = null;
		parent[start] = null;
		open.Enqueue ( start );
		while ( open.Count > 0 ) {
			n = open.Dequeue ();
			n.GetComponent<Waypoint_Dijkstra> ().setVisited = true;
			if ( n == goal ) {
				s.Push ( goal );
				while ( goal != start ) {
					s.Push ( parent[goal] );
					goal = parent[goal];
				}
				return s;
			}
			foreach ( GameObject go in n.GetComponent<Waypoint_Dijkstra> ().neighbors ) {
				child = go;
				if ( child.GetComponent<Waypoint_Dijkstra> ().setVisited == true ) {
					continue;
				}
				parent[child] = n;
				float newDistance = Vector3.Distance(parent[child].transform.position, go.transform.position);
				if ( child == goal ) {
					shortestNode = child;
					break;
				}

				else if(newDistance <= lowestCost) {
					Debug.Log ( newDistance );
					Debug.Log ( child );
					lowestCost = newDistance;
					costToGoal[child] = lowestCost;
					shortestNode = child;
				}
			}
			Debug.Log("Selected child is"+child+"and cost is" +lowestCost);
			open.Enqueue( shortestNode );
			lowestCost = Mathf.Infinity;
		}
		return null;
	}
}


*/