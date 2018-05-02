using UnityEngine;
using System.Collections;

public class CurrentNodeBestFS : MonoBehaviour {

	public GameObject currentNode;
	public bool isAI = true;
	public GameObject[] abc;

	void Start () {
		SetCurrentNode ();
	}

	void Update () {
		SetCurrentNode ();
	}

	void SetCurrentNode () {

		float shortestDistance = Mathf.Infinity;
		GameObject[] abc = GameObject.FindGameObjectsWithTag ( "BestFSNode" );
		foreach ( GameObject obj in abc ) {
			float dist = ( obj.transform.position - gameObject.transform.position ).magnitude;
			if ( dist < shortestDistance ) {
				shortestDistance = dist;
				currentNode = obj;
			}
		}
	}

	void OnTriggerEnter ( Collider col ) {
		if ( col.tag == "BestFSNode" ) {
			currentNode = col.gameObject;
		}
	}
}
