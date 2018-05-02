using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class Waypoint_BFS : MonoBehaviour {

	public bool goalVisisted = false;
	public GameObject[] children;
	public GameObject goal;
	public float radius = 2.0f;
	public bool setVisited;

	void OnDrawGizmos () {
		Gizmos.color = Color.red;
		Gizmos.DrawWireCube ( transform.position, Vector3.one );
		LineDraw();

		if ( goal ) {
			//CheckGoalAssigned();
		}
	}

	void LineDraw () {
		RaycastHit hit;
		for(int i = 0; i < children.Length;i++){
			if ( !Physics.Raycast ( transform.position, ( children[i].transform.position - transform.position ), out hit, 50f ) ) {
				Gizmos.DrawLine ( transform.position, children[i].transform.position );
			}
		}
	}
}

