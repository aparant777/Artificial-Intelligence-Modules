using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class Waypoint_AStar_Modified : MonoBehaviour {

	public bool goalVisisted = false;
	public GameObject[] children;
	public float radius = 2.0f;
	public GameObject player;
	public float gValue;
	public float hValue;
	public float fValue;

	void OnDrawGizmos () {
		Gizmos.color = Color.red;
		Gizmos.DrawWireCube ( transform.position, Vector3.one );
		LineDraw ();

		if ( player ) {
		//	CheckGoalAssigned();
		}
	}

	void LineDraw () {
		foreach ( GameObject go in children ) {
			Gizmos.DrawLine ( transform.position, go.transform.position );
		}
	}
}