using UnityEngine;
using System.Collections;

public class CurrentNodeDFS : MonoBehaviour {
	public GameObject currentNode;
	public bool isAI = true;
	void Start () {
		SetCurrentNode ();

	}

	void SetCurrentNode () {
		float shortestDistance = Mathf.Infinity;
		GameObject[] abc = GameObject.FindGameObjectsWithTag ( "DFSNode" );
		foreach ( GameObject obj in abc ) {
			float dist = ( obj.transform.position - gameObject.transform.position ).magnitude;
			if ( dist < shortestDistance ) {
				shortestDistance = dist;
				currentNode = obj;
			}
		}
	}

	void Update () {	
		SetCurrentNode ();
	}

	void OnTriggerEnter ( Collider col ) {
		if ( col.tag == "DFSNode" ) {
			currentNode = col.gameObject;
		}
	}
}
