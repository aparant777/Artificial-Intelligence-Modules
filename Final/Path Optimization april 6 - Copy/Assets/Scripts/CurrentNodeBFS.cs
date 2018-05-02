using UnityEngine;
using System.Collections;

public class CurrentNodeBFS : MonoBehaviour {

	public GameObject currentNode;
	public bool isAI = true;
	public GameObject[] abc;


	void Awake () {
		abc = GameObject.FindGameObjectsWithTag ( "BFSNode" );
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
		if ( col.tag == "BFSNode" ) {
			currentNode = col.gameObject;
		}
	}
}
