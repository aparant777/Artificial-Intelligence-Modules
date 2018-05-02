using System;
using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class BestFSZombie : MonoBehaviour {


	public float speed = 5f;
	public float turnSpeed = 500.0f;
	public float sphereCastRadius = 0.5f;

	private GameObject goal;
	public GameObject player;
	public GameObject[] finalPath;
	public int currentPathIndex;
	public float mass = 5.0f;
	public float timeCounter = 0f;

	public Stack<GameObject> path;
	public int nodesExamined;
	float count = 0f;
	public bool once = false;
	private float totalDistanceCovered;
	private float distanceCovered;
	public int temp;
	public bool buttonPressed;
	public Material blue;
	public float maxNodes = 97f;
	public float bestFSEfficiency;
	public float bestFSEfficiency1;
	float timers = 0f;
	public GameObject newsource;
	public GameObject newdestination;
	BestFirstSearch bestFsalgo = new BestFirstSearch ();

	void Start () {
		buttonPressed = false;
		newsource = null;
		newdestination = null;
	}

	void Update () {
		if ( buttonPressed == true ) {
			if ( false ) {
			}
			else {
				if ( Vector3.Distance ( player.transform.position, GameObject.FindGameObjectWithTag ( "BestFSZombie" ).transform.position ) > 0.1f ) {
					if ( once == false ) {
						timers = Time.realtimeSinceStartup; 
						path = bestFsalgo.BestFirstCompute (
								gameObject.GetComponent<CurrentNodeBestFS> ().currentNode,
								player.GetComponent<CurrentNodeBestFS> ().currentNode );
						Debug.Log ( "Time Required to execute BestFS is" + timers );
						BestFSTotalNodesCovered ();
						BestFSNodesExamined ();
						BestfsEfficiency ();
					}
					once = true;
					if ( path.Count > 0 )
						goal = path.Peek ();
					goal.GetComponent<Renderer> ().material = blue;

					if ( path.Count > 0 ) {

						BestFSTotalTimeCovered ();
						if ( path.Contains ( player.GetComponent<CurrentNodeBestFS> ().currentNode ) ) {

							Vector3 goalPosition = goal.transform.position;
							Vector3 goalDirection = goalPosition - transform.position;
							goalDirection.y = 0.0f;
							Vector3 normalizedGoalDirection = goalDirection.normalized;
							transform.position += transform.forward * speed * Time.deltaTime;
							transform.rotation = Quaternion.RotateTowards ( transform.rotation,
								Quaternion.LookRotation ( normalizedGoalDirection ),
								turnSpeed * Time.deltaTime );

							BestFSTotalDistanceCovered ();

							if ( Vector3.Distance ( gameObject.transform.position, goalPosition ) < 0.5f ) {
								if ( goal.GetComponent<Waypoint_BestFS> ().goalVisisted == false ) {
									goal.GetComponent<Waypoint_BestFS> ().goalVisisted = true;
									path.Pop ();

								}
							}
						}
					}
				}
			}
		}
	}
	
	void OnDrawGizmos () {

		Gizmos.color = Color.red;
		Gizmos.DrawLine ( gameObject.transform.position, player.transform.position );
	}

	public void BestFSTotalDistanceCovered () {
		distanceCovered = Vector3.Distance ( transform.position, goal.transform.position );
		totalDistanceCovered = totalDistanceCovered + distanceCovered;
	}

	public void BestFSTotalTimeCovered () {
		if ( Vector3.Distance ( player.transform.position, GameObject.FindGameObjectWithTag ( "BestFSZombie" ).transform.position ) > 0.5f ) {
			timeCounter = Time.deltaTime + timeCounter;
		}
	}

	public void BestFSTotalNodesCovered () {
		if ( Vector3.Distance ( player.transform.position, GameObject.FindGameObjectWithTag ( "BestFSZombie" ).transform.position ) > 0.5f ) {
			temp = path.Count;
		}
	}

	public float GetBestFSTotalDistanceCovered () {
		return timeCounter;
	}

	public float GetBestFSTotalTimeCovered () {
		return totalDistanceCovered / 10;
	}

	public int GetBestFSTotalNodes () {
		return temp;
	}

	public void ChaluKaro () {
		buttonPressed = true;
	}

	public void BestFSNodesExamined () {
		nodesExamined = bestFsalgo.BestFSendVisited ();
	}

	public float GetBestFSExecutionTime () {
		return timers;
	}

	public int BestFSTotalNodesExamined () {
		return nodesExamined;
	}

	public void BestfsEfficiency () {
		bestFSEfficiency = maxNodes* Mathf.Log ( maxNodes, 5f );
		bestFSEfficiency1 =maxNodes* Mathf.Log ( maxNodes, 2f );
		//Debug.Log ( "base 5 is "+bestFSEfficiency );
		//Debug.Log ( "base 2 is "+bestFSEfficiency1 );	
	}
}
