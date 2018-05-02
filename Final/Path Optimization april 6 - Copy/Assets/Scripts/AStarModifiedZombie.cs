using System;
using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.EventSystems;

public class AStarModifiedZombie : MonoBehaviour {

	public float speed = 5f;
	public float turnSpeed = 500.0f;
	public float sphereCastRadius = 0.5f;
	public bool buttonPressed;
	private GameObject goal;
	public GameObject player;
	public GameObject[] finalPath;
	public int currentPathIndex;
	public float mass = 5.0f;
	public float timeCounter = 0f;
	public float timeToCompute;
	public Button startButton;
	public Material blue;
	public int nodesExamined;
	
	public Stack<GameObject> path;
	float count = 0f;
	//float timeToCompute = 0f;
	int temp = 0;
	public bool once = false;
	private float totalDistanceCovered;
	private float distanceCovered;
	public int nodesVisitedAstarModified;
	public Vector3 newPlayerPosition;
	AStarModifiedAlgo ag = new AStarModifiedAlgo ();
	float timers = 0f;
	void Start () {
		buttonPressed = false;
		newPlayerPosition = player.transform.position;
	}

	void Update () {
		

		if ( false ) {

		}
		else {

			if ( Vector3.Distance ( player.transform.position, GameObject.FindGameObjectWithTag ( "AModifiedZombie" ).transform.position ) > 0.1f && buttonPressed == true ) {
				if ( once == false ) {
					timers = Time.realtimeSinceStartup;
					path = ag.AStarModifiedSearch (
							gameObject.GetComponent<CurrentNodeAstarModified> ().currentNode,
							player.GetComponent<CurrentNodeAstarModified> ().currentNode );
					Debug.Log ( "Time Required to execute AstarModified is" + timers );
					//Debug.Log ( "Path computed for Modified Astar in " + ( int ) ( timers * 100 ) + "ms" );
					//Debug.Log ( path );
					AStarModifiedTotalNodesCovered ();
					AstarModifiedNodesExamined ();
				}
				once = true;
				if ( path.Count > 0 )
					goal = path.Peek ();
				goal.GetComponent<Renderer> ().material = blue;

				if ( path.Count > 0 ) {

					AStarModifiedTotalTimeCovered ();
					if ( path.Contains ( player.GetComponent<CurrentNodeAstarModified> ().currentNode ) ) {

						Vector3 goalPosition = goal.transform.position;
						Vector3 goalDirection = goalPosition - transform.position;
						goalDirection.y = 0.0f;
						Vector3 normalizedGoalDirection = goalDirection.normalized;
						transform.position += transform.forward * speed * Time.deltaTime;
						transform.rotation = Quaternion.RotateTowards ( transform.rotation,
							Quaternion.LookRotation ( normalizedGoalDirection ),
							turnSpeed * Time.deltaTime );
						AStarModifiedTotalDistanceCovered ();
						if ( Vector3.Distance ( gameObject.transform.position, goalPosition ) < 0.2f ) {
							if ( goal.GetComponent<Waypoint_AStar_Modified> ().goalVisisted == false ) {

								goal.GetComponent<Waypoint_AStar_Modified> ().goalVisisted = true;
								path.Pop ();
							}
						}
					}
				}
				/*if ( player.transform.position != newPlayerPosition ) {
					while ( path.Count > 0 ) {
						GameObject tempGameobject = path.Pop ();
						tempGameobject.GetComponent<Waypoint_AStar_Modified> ().goalVisisted = false;
					}
					path.Clear ();
					path = ag.AStarModifiedSearch (
							gameObject.GetComponent<CurrentNodeAstarModified> ().currentNode,
							player.GetComponent<CurrentNodeAstarModified> ().currentNode );
				}
					* */
			}
		}
	}
	

	public void AStarModifiedTotalDistanceCovered () {
		distanceCovered = Vector3.Distance ( transform.position, goal.transform.position );
		totalDistanceCovered = totalDistanceCovered + distanceCovered;
	}

	public void AStarModifiedTotalTimeCovered () {
		if ( Vector3.Distance ( player.transform.position, GameObject.FindGameObjectWithTag ( "AModifiedZombie" ).transform.position ) > 0.5f ) {
			timeCounter = Time.deltaTime + timeCounter;
		}
	}

	public void AStarModifiedTotalNodesCovered () {
		if ( Vector3.Distance ( player.transform.position, GameObject.FindGameObjectWithTag ( "AModifiedZombie" ).transform.position ) > 0.5f ) {
			temp = path.Count;
		}
	}

	public void AStarModifiedTimeToCompute () {
		timeToCompute = Time.time + 1;
	}

	public void AstarModifiedNodesExamined () {
		nodesExamined = ag.AstarModifiedSendVisited ();
	}

	public float GetAstarModifiedTotalDistanceCovered () {
		return timeCounter;
	}

	public float GetAstarModifiedTotalTimeCovered () {
		return totalDistanceCovered / 10;
	}

	public int GetAstarModifiedTotalNodes () {
		return temp;
	}

	public int GetAstarModifiedTotalNodesExamined () {
		return nodesExamined;
	}

	public float GetAstarModifiedExecutionTime () {
		return timers;
	}
	void OnDrawGizmos () {
		Gizmos.color = Color.red;
		Gizmos.DrawLine ( gameObject.transform.position, player.transform.position );
	}

	public void ChaluKaro () {
		buttonPressed = true;
	}
	
}
