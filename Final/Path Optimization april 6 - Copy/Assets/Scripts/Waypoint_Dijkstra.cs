using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class Waypoint_Dijkstra : MonoBehaviour
{
	public List<GameObject> neighbors = new List<GameObject> ();
	public bool goalVisisted = false;
	public float nodeRadius = 50.0f;
	public GameObject goal;
	public bool setVisited;
	public float nodeCost;

	void OnDrawGizmos()
	{
		Gizmos.color = Color.red;
		Gizmos.DrawWireCube(transform.position, Vector3.one);
	
		foreach(GameObject neighbor in neighbors)
		{
			
			Gizmos.DrawLine ( transform.position, neighbor.transform.position );
		}
	}
}
