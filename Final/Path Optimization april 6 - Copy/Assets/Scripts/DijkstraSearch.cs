/*
using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class DijkstraSearch : MonoBehaviour {


	public bool DijkstraSearchCompute ( GameObject start, GameObject goal ) {
		Dictionary<GameObject, GameObject> parent = new Dictionary<GameObject, GameObject> ();	//kiska baap kaun hai...
		Queue<GameObject> open = new Queue<GameObject> ();	//holds the nodes
		
		GameObject n, child = null;
		parent[start] = null;
		open.Enqueue ( start );
		while(open.Count > 0) {
			n = open.Dequeue ();
			if ( n == goal ) {
				return true;
			}
			foreach ( GameObject go in n.GetComponent<Waypoint_Dijkstra> ().neighbors ) {
				
				float alt = dist[n] + ( n.transform.position - v.transform.position ).magnitude;
				if ( alt < dist[v] )		//alt = newcost.
				{
					dist[v] = alt;
					previous[v] = n;
				}
			}

		}


	}
	
}

/*
 * bool DijkstraSearch(Node start, Node goal)
{
	PriorityQueue open;
	Node n, child;
	start.parent = NULL;
	start.cost = 0;
	open.enqueue(start);
	while(!open.isEmpty())
	{
		n = open.dequeue();
		n.setVisited(true);
		if (n == goal)
		{
			makePath();
			return true;
		}		
		while (n.hasMoreChildren())
		{
			child = n.getNextChild();
			COSTVAL newcost = n.cost + cost(n, child);
			if (child.visited())
				continue;
			if (open.contains(child) && child.cost <= newcost)
				continue;
			child.parent = n;
			child.cost = newcost;
			if (!open.contains(child))
				open.enqueue(child);
			else
				open.reenqueue(child);
		}
	}
	return false;a
 }
*/