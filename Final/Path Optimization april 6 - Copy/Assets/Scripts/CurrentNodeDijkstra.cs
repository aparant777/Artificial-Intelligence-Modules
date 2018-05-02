using UnityEngine;
using System.Collections;

public class CurrentNodeDijkstra : MonoBehaviour {

	public GameObject currentNode;

	public bool isAI = true;

	// Use this for initialization
	void Start () {
		SetCurrentNode ();
	}

	void SetCurrentNode () {
		float shortestDistance = Mathf.Infinity;	//let the shortest path be infinity
		foreach ( GameObject obj in GameObject.FindGameObjectsWithTag ( "DijkNode" ) ) {
			float dist = ( obj.transform.position - transform.position ).magnitude;
			//finding the value of the distance between wohi object and all the objects
			if ( dist < shortestDistance ) {
				shortestDistance = dist;
				currentNode = obj;
			}
		}
	}

	// Update is called once per frame
	void Update () {
		SetCurrentNode ();
	}

	void OnTriggerEnter ( Collider col ) {
		if ( col.tag == "DijkNode" ) {
			currentNode = col.gameObject;
		}
	}
}
