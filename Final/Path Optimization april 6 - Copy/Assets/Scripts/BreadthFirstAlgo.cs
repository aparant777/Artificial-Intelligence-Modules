using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class BreadthFirstAlgo {

	private int count;
	public int tempCount;

	public Stack<GameObject> BreadthFirstSearch ( GameObject start, GameObject goal ) {

		Dictionary<GameObject, GameObject> parent = new Dictionary<GameObject, GameObject> ();	//kiska baap kaun hai...
		Queue<GameObject> open = new Queue<GameObject> ();	//holds the nodes
		Stack<GameObject> s = new Stack<GameObject> ();	//return stack karenge
		GameObject n, child = null;

		parent[start] = null;
		open.Enqueue ( start );
		while ( open.Count > 0 ) {
			n = open.Dequeue ();
			n.GetComponent<Waypoint_BFS> ().setVisited = true;
			if ( n == goal ) {
				s.Push ( goal );
				while ( goal != start ) {
					s.Push ( parent[goal] );
					goal = parent[goal];
				}
				return s;
			}

			foreach ( GameObject go in n.GetComponent<Waypoint_BFS> ().children ) {
				child = go;
				if ( child.GetComponent<Waypoint_BFS> ().setVisited != true )
					GetNodesVisisted ();
				if ( child.GetComponent<Waypoint_BFS> ().setVisited == true ) {
					continue;
				}
				parent[child] = n;
				open.Enqueue ( child );
			}
		}
		return null;
	}

	public void GetNodesVisisted () {
		count++;
		tempCount = count;
	}

	public int BFSSendVisited () {
		return tempCount;
	}
}

/*
 * bool BreadthFirstSearch(Node start, Node goal)
{
	Queue open;
	Node n, child;
	start.parent = NULL;
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
			if (child.visited())
				continue;
			child.parent = n;
			open.enqueue(child);
		}
	}	
	return false;
}
*/

/*
 * 
 * using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class BreadthFirstAlgo {

	public static Stack<GameObject> BreadthFirstSearch ( GameObject start, GameObject goal ) {
		
		Dictionary<GameObject, GameObject> parent = new Dictionary<GameObject, GameObject> ();	//kiska baap kaun hai...
		Queue<GameObject> open = new Queue<GameObject> ();	//holds the nodes
		Stack<GameObject> s = new Stack<GameObject> ();	//return stack karenge
		GameObject n, child = null;
	
		parent[start] = null;		
		open.Enqueue ( start );
		while ( open.Count > 0 ) {
			n = open.Dequeue ();
			n.GetComponent<Waypoint_BFS> ().setVisited = true;
			if ( n == goal ) {
				s.Push ( goal );
				while ( goal != start ) {
					s.Push ( parent[goal] );
					goal = parent[goal];		
				}
				return s;
			}

			foreach ( GameObject go in n.GetComponent<Waypoint_BFS> ().children ) {
				child = go;
				if (child.GetComponent<Waypoint_BFS> ().setVisited == true ) {
					continue;
				}
				parent[child] = n;
				open.Enqueue ( child );
			}
		}
		return null;
	}
}
 * 
 * 
 */
