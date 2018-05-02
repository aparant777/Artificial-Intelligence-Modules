using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class Waypoint_DFS : MonoBehaviour {

	public bool goalVisisted = false;
	public GameObject[] children;
	public GameObject goal;
	public float radius = 2.0f;
	public bool setVisited;

	void OnDrawGizmos () {
		Gizmos.color = Color.red;
		Gizmos.DrawWireCube ( transform.position, Vector3.one );
		LineDraw ();
	}
	void LineDraw () {
		foreach ( GameObject go in children ) {
			Gizmos.DrawLine ( transform.position, go.transform.position );
		}
	}
}

