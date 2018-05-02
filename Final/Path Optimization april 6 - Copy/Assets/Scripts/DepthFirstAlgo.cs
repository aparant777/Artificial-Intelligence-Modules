using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class DepthFirstAlgo : MonoBehaviour {

	private int count;
	public int tempCount;
	
	public  Stack<GameObject> DepthFirstSearch(GameObject start, GameObject goal) {

		Dictionary<GameObject, GameObject> parent = new Dictionary<GameObject, GameObject> ();	
		Stack<GameObject> open = new Stack<GameObject> ();
		Stack<GameObject> s = new Stack<GameObject> ();
		GameObject n, child = null;

		//start.GetComponent<Waypoint_DFS> ().isVisited = true;
		parent[start] = null;
		open.Push ( start );
		while ( open.Count > 0 ) {
			n = open.Pop();
			n.GetComponent<Waypoint_DFS> ().setVisited = true;
			if(n == goal) {
				s.Push ( goal );
				while ( goal != start ) {

					s.Push ( parent[goal] );
					//Debug.Log ( parent[goal] );
					goal = parent[goal];
				}
				//Debug.Log ( s.Count );
				return s;
				//return true;
			}
			foreach ( GameObject go in n.GetComponent<Waypoint_DFS> ().children ) {
			
				child = go;
				if ( child.GetComponent<Waypoint_DFS> ().setVisited != true )
					GetNodesVisisted ();
				///Debug.Log ( "child is " + child );
				if ( child.GetComponent<Waypoint_DFS> ().setVisited == true ) {
					///Debug.Log ( "i am here" );
					continue;
				}
				parent[child] = n;
				///Debug.Log ("parent of "+child+" is "+parent[child]);	
				open.Push ( child );
			}
		}
		return null;
	}

	public void GetNodesVisisted () {
		count++;
		tempCount = count;
	}

	public int DFSSendVisited () {
		return tempCount;
	}
}
/*


bool DepthFirstSearch(Node node, Node goal, int depth, int length)
{
	int d;
	if (node == goal)
	{
		makePath();
		return true;
	}
	if (depth < MAXDEPTH)
	{
		while (node.hasMoreChildren())
		{
			child = node.getNextChild();
			d = node.dist + node.getCost(child);
			if (!isTowardsGoal(node, child, goal))
				continue;
			if (child.visited() || d > child.cost)
				continue;
			child.parent = node;
			child.visited = true;
			child.cost = d;
			if (DepthFirstSearch(child, goal, depth+1, child.cost))
				return true;
			child.visited = false;
		}
	}
	return false;
}
*/