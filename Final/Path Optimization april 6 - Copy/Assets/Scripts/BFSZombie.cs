using System;
using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class BFSZombie : MonoBehaviour {

	public float speed = 5f;
	public float turnSpeed = 500.0f;
	public float sphereCastRadius = 0.5f;
	public float timeToCompute = 0f;
	public int nodesVisited;

	private GameObject goal;
	public GameObject player;
	public GameObject[] finalPath;
	public int currentPathIndex;
	public float mass = 5.0f;
	public float timeCounter = 0f;

	public Stack<GameObject> path;
	public bool once = false;
	public float totalDistanceCovered;
	public float distanceCovered;

	private float instanceRate;
	public GameObject Zombie;
	public Vector3 instancePosition;
	public float nextInstanceRate;
	float timers = 0f;
	public int temp;
	public bool hasReached = false;
	public bool buttonPressed;
	public Material blue;
	public float bfsEfficiency;
	public float maxNodes = 97f;
	public BreadthFirstAlgo bfsa = new BreadthFirstAlgo ();

	void Start () {
		buttonPressed = false;
	}
	void Update () {
		if ( buttonPressed == true ) {
			if ( false ) {

			}
			else {
				if ( Vector3.Distance ( player.transform.position, GameObject.FindGameObjectWithTag ( "BFSZombie" ).transform.position ) > 0.1f ) {
					if ( once == false ) {
						timers = Time.realtimeSinceStartup;
						BFSTimeToCompute ();
						float dfsTimeRequiredToComplete = Time.time;
						path = bfsa.BreadthFirstSearch (
								gameObject.GetComponent<CurrentNodeBFS> ().currentNode,
								player.GetComponent<CurrentNodeBFS> ().currentNode );
						//Debug.Log ( "Path computed for BFS in " + ( int ) ( timers * 100 ) + "ms" );
						Debug.Log ( "Time Required to execute BFS is" + timers );
						BFSTotalNodesCovered ();
						BFSTotalNodesExamined ();
						BFSEfficiency ();

					}

					once = true;
					if ( path.Count > 0 )
						goal = path.Peek ();
					goal.GetComponent<Renderer> ().material = blue;

					if ( path.Count > 0 ) {
						//#code for timer starts
						BFSTotalTimeCovered ();
						if ( path.Contains ( player.GetComponent<CurrentNodeBFS> ().currentNode ) ) {

							Vector3 goalPosition = goal.transform.position;
							Vector3 goalDirection = goalPosition - transform.position;
							goalDirection.y = 0.0f;

							Vector3 normalizedGoalDirection = goalDirection.normalized;
							transform.position += transform.forward * speed * Time.deltaTime;
							transform.rotation = Quaternion.RotateTowards ( transform.rotation,
								Quaternion.LookRotation ( normalizedGoalDirection ),
								turnSpeed * Time.deltaTime );

							//#total distance covered method
							BFSTotalDistanceCovered ();

							if ( Vector3.Distance ( gameObject.transform.position, goalPosition ) < 0.2f ) {
								if ( goal.GetComponent<Waypoint_BFS> ().goalVisisted == false ) {

									goal.GetComponent<Waypoint_BFS> ().goalVisisted = true;

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
		
		RaycastHit hit;
		Physics.SphereCast ( transform.position, sphereCastRadius, player.transform.position - transform.position, out hit );

		Gizmos.color = Color.red;
		Gizmos.DrawLine ( gameObject.transform.position, player.transform.position );
		
	}

	public void BFSTotalDistanceCovered () {
		distanceCovered = Vector3.Distance ( transform.position, goal.transform.position );
		totalDistanceCovered = totalDistanceCovered + distanceCovered;
	}

	public void BFSTotalTimeCovered () {
		if ( Vector3.Distance ( player.transform.position, GameObject.FindGameObjectWithTag ( "BFSZombie" ).transform.position ) > 0.5f ) {
			timeCounter = Time.deltaTime + timeCounter;
		}
	}

	public void BFSTotalNodesCovered () {
		if ( Vector3.Distance ( player.transform.position, GameObject.FindGameObjectWithTag ( "BFSZombie" ).transform.position ) > 0.5f ) {
			temp = path.Count;
		}
	}

	public void BFSTimeToCompute () {
		timeToCompute = Time.time + 1;
	}

	public float GetBFSTotalDistanceCovered () {
		return timeCounter;
	}

	public float GetBFSTotalTimeCovered () {
		return totalDistanceCovered / 10;
	}

	public int GetBFSTotalNodes () {
		return temp;
	}

	public void ChaluKaro () {
		buttonPressed = true;
	}

	public void BFSTotalNodesExamined () {
		nodesVisited = bfsa.BFSSendVisited ();
	}

	public float GetBFSExecutionTime () {
		return timers;
	}

	public int GetBFSTotalNodesExamined () {
		return nodesVisited;
	}

	public void BFSEfficiency () {
		bfsEfficiency = maxNodes * Mathf.Log ( maxNodes );
		//Debug.Log ( "bfs efficiency is "+bfsEfficiency );
	}
}
