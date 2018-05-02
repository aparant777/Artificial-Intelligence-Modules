﻿using UnityEngine;
using System.Collections;

public class CurrentNodeAstar : MonoBehaviour {

	public GameObject currentNode;
	public bool isAI = true;
	public GameObject[] abc;


	void Awake () {
		abc = GameObject.FindGameObjectsWithTag ( "ANode" );
	}

	void Start () {
		SetCurrentNode ();
	}

	void Update () {
		SetCurrentNode ();
	}

	void SetCurrentNode () {

		float shortestDistance = Mathf.Infinity;
		foreach ( GameObject obj in abc ) {
			float dist = ( obj.transform.position - gameObject.transform.position ).magnitude;
			if ( dist < shortestDistance ) {
				shortestDistance = dist;
				currentNode = obj;
			}
		}
	}

	void OnTriggerEnter ( Collider col ) {
		if ( col.tag == "ANode" ) {
			currentNode = col.gameObject;
		}
	}
}

//CurrentNodeAstar
