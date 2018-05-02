using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public  class BestFirstSearch : MonoBehaviour{
	public int nodesVisited;
	private int count;
	public int tempCount;

	public Stack<GameObject> BestFirstCompute ( GameObject start, GameObject goal ) {

		Dictionary<GameObject, GameObject> parent = new Dictionary<GameObject, GameObject> ();
		Queue<GameObject> open = new Queue<GameObject> ();
		Dictionary<GameObject, float> costToGoal = new Dictionary<GameObject, float>();
		float lowestCost = Mathf.Infinity;
		GameObject shortestNode = null;
		Stack<GameObject> s = new Stack<GameObject> ();
		GameObject n, child = null;
		float timeToCompute = 0f;
		timeToCompute = Time.smoothDeltaTime + 1;
		
		parent[start] = null;
		open.Enqueue ( start );
		while ( open.Count > 0 ) {
			n = open.Dequeue ();
			n.GetComponent<Waypoint_BestFS> ().setVisited = true;
			if ( n == goal ) {
				s.Push ( goal );
				while ( goal != start ) {
					s.Push ( parent[goal] );
					goal = parent[goal];
				}
				//Debug.Log ( "path computed of BestFS in " + timeToCompute + "ms" );
				return s;
			}
			foreach ( GameObject go in n.GetComponent<Waypoint_BestFS> ().children ) {
				child = go;
				if ( child.GetComponent<Waypoint_BestFS> ().setVisited == true ) {
					continue;
				}
				if ( child.GetComponent<Waypoint_BestFS> ().goalVisisted != true )
					GetNodesVisisted ();
				parent[child] = n;
				float newDistance = Vector3.Distance(child.transform.position, goal.transform.position);
				if(newDistance < lowestCost) {
					lowestCost = newDistance;
					costToGoal[child] = lowestCost;
					shortestNode = child;
				}
			}
			open.Enqueue( shortestNode );
			lowestCost = Mathf.Infinity;
		}
		return null;
	}

	public void GetNodesVisisted () {
		count++;
		tempCount = count;
	}

	public int BestFSendVisited () {
		return tempCount;
	}
}