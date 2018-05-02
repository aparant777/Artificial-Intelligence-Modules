using System;
using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class DFSZombie : MonoBehaviour {


	public float speed = 5f;
	public float turnSpeed = 500.0f;
	
	private GameObject goal;
	public GameObject player;
	public float timeCounter = 0f;
	public Stack<GameObject> path;
	public bool once = false;
	private float totalDistanceCovered;
	private float distanceCovered;
	public int temp;
	public GameObject[] line;
	Stack<GameObject> tempStack = new Stack<GameObject> ();
	public bool buttonPressed;
	public Material blue;
	DepthFirstAlgo dfsa = new DepthFirstAlgo ();
	public int nodesVisited;
	public float dfsEfficiency;
	public float maxNodes = 97f;
	float timers = 0f;
	void Start () {
		buttonPressed = false;
	}
	void Update () {
		if ( buttonPressed == true ) {
			if ( false ) {
			}
			else {
				if ( Vector3.Distance ( player.transform.position, GameObject.FindGameObjectWithTag ( "DFSZombie" ).transform.position ) > 0.1f ) {
					if ( once == false ) {

						timers = Time.realtimeSinceStartup;
						path = dfsa.DepthFirstSearch (
								gameObject.GetComponent<CurrentNodeDFS> ().currentNode,
								player.GetComponent<CurrentNodeDFS> ().currentNode );
						Debug.Log ( "Time Required to execute DFS is" + timers );

						DFSEfficiency ();
						DFSTotalNodesCovered ();
						DFSTotalNodesExamined ();
					}
					once = true;
					if ( path.Count > 0 )
						goal = path.Peek ();
					goal.GetComponent<Renderer> ().material = blue;

					if ( path.Count > 0 ) {
						//#code for timer starts
						DFSTotalTimeCovered ();
						if ( path.Contains ( player.GetComponent<CurrentNodeDFS> ().currentNode ) ) {

							Vector3 goalPosition = goal.transform.position;
							Vector3 goalDirection = goalPosition - transform.position;
							goalDirection.y = 0.0f;

							Vector3 normalizedGoalDirection = goalDirection.normalized;
							transform.position += transform.forward * speed * Time.deltaTime;
							transform.rotation = Quaternion.RotateTowards ( transform.rotation,
								Quaternion.LookRotation ( normalizedGoalDirection ),
								turnSpeed * Time.deltaTime );

							DFSTotalDistanceCovered ();
							if ( Vector3.Distance ( gameObject.transform.position, goalPosition ) < 0.2f ) {
								if ( goal.GetComponent<Waypoint_DFS> ().goalVisisted == false ) {

									goal.GetComponent<Waypoint_DFS> ().goalVisisted = true;
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

	public void DFSTotalDistanceCovered () {
		distanceCovered = Vector3.Distance ( transform.position, goal.transform.position );
		totalDistanceCovered = totalDistanceCovered + distanceCovered;
	}

	public void DFSTotalTimeCovered () {
		if ( Vector3.Distance ( player.transform.position, GameObject.FindGameObjectWithTag ( "DFSZombie" ).transform.position ) > 0.5f ) {
			timeCounter = Time.deltaTime + timeCounter;
		}
	}

	public void DFSTotalNodesCovered () {
		if ( Vector3.Distance ( player.transform.position, GameObject.FindGameObjectWithTag ( "DFSZombie" ).transform.position ) > 0.5f ) {
			temp = path.Count;
		}
	}

	public float GetDFSTotalDistanceCovered () {
		return timeCounter;
	}

	public float GetDFSTotalTimeCovered () {
		return totalDistanceCovered / 10;
	}

	public int GetDFSTotalNodes () {
		return temp;
	}

	public void ChaluKaro () {
		buttonPressed = true;
	}

	public void DFSTotalNodesExamined () {
		nodesVisited = dfsa.DFSSendVisited ();
	}

	public int GetDFSTotalNodesExamined () {
		return nodesVisited;
	}

	public float GetDFSExecutionTime () {
		return timers;
	}

	public void DFSEfficiency () {
		dfsEfficiency = maxNodes * Mathf.Log ( maxNodes );
		//Debug.Log ( "dfs efficiency is "+dfsEfficiency );
	}
}
