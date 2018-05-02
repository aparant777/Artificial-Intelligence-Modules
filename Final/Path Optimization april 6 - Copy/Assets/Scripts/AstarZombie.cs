using System;
using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class AstarZombie : MonoBehaviour {


	public float speed = 5f;
	public float turnSpeed = 500.0f;
	public float sphereCastRadius = 0.5f;
	public float timeToCompute;

	private GameObject goal;
	public GameObject player;
	public GameObject[] finalPath;
	public int currentPathIndex;
	public float mass = 5.0f;
	public float timeCounter = 0f;

	public Stack<GameObject> path;
	public Stack<GameObject> path1;
	public bool once = false;
	private float totalDistanceCovered;
	private float distanceCovered;
	public int temp;
	public bool buttonPressed;
	public Material blue;
	AStarAlgo asa = new AStarAlgo ();
	public int nodesExamined;
	float timers = 0f;

	void Start () {
		buttonPressed = false;
	}


	void Update () {
		
		if ( buttonPressed == true ) {
			if ( false ) {

			}
			else {
				if ( Vector3.Distance ( player.transform.position, GameObject.FindGameObjectWithTag ( "AZombie" ).transform.position ) > 0.1f ) {
					if ( once == false ) {
						timers = Time.realtimeSinceStartup;
						AStarTimeToCompute ();
						path = asa.AStarSearch (
								gameObject.GetComponent<CurrentNodeAstar> ().currentNode,
								player.GetComponent<CurrentNodeAstar> ().currentNode );
						Debug.Log ( "Time Required to execute Astar is" + timers );
						
						AStarTotalNodesCovered ();
						AstarNodesExamined ();

					}
					once = true;
					
					if ( path.Count > 0 ) {
						goal = path.Peek ();
						goal.GetComponent<Renderer> ().material = blue;
						AStarTotalTimeCovered ();
						if ( path.Contains ( player.GetComponent<CurrentNodeAstar> ().currentNode ) ) {

							Vector3 goalPosition = goal.transform.position;
							Vector3 goalDirection = goalPosition - transform.position;
							goalDirection.y = 0.0f;
							Vector3 normalizedGoalDirection = goalDirection.normalized;
							transform.position += transform.forward * speed * Time.deltaTime;
							transform.rotation = Quaternion.RotateTowards ( transform.rotation,
								Quaternion.LookRotation ( normalizedGoalDirection ),
								turnSpeed * Time.deltaTime );

							AStarTotalDistanceCovered ();
							if ( Vector3.Distance ( gameObject.transform.position, goalPosition ) < 0.2f ) {
								if ( goal.GetComponent<Waypoint_AStar> ().goalVisisted == false ) {

									goal.GetComponent<Waypoint_AStar> ().goalVisisted = true;
									path.Pop ();
								}
							}
						}
					}
				}
			}
		}
	}

	public void AStarTotalDistanceCovered () {
		distanceCovered = Vector3.Distance ( transform.position, goal.transform.position );
		totalDistanceCovered = totalDistanceCovered + distanceCovered;
	}

	public void AStarTotalTimeCovered () {
		if ( Vector3.Distance ( player.transform.position, GameObject.FindGameObjectWithTag ( "AZombie" ).transform.position ) > 0.5f ) {
			timeCounter = Time.deltaTime + timeCounter;
		}
	}

	public void AStarTotalNodesCovered () {
		if ( Vector3.Distance ( player.transform.position, GameObject.FindGameObjectWithTag ( "AZombie" ).transform.position ) > 0.5f ) {
			temp = path.Count;
		}
	}

	public void AStarTimeToCompute () {
		timeToCompute = Time.time + 1;
	}
	public float GetAstarTotalDistanceCovered () {
		return timeCounter;
	}

	public float GetAstarTotalTimeCovered () {
		return totalDistanceCovered / 10;
	}

	public int GetAstarTotalNodes () {
		return temp;
	}

	public void ChaluKaro () {
		buttonPressed = true;
	}

	public void AstarNodesExamined () {
		nodesExamined = asa.AstarSendVisited ();
	}

	public float GetAstarExecutionTime () {
		return timers;
	}
	public int GetAstarTotalNodesExamined () {
		return nodesExamined;
	}

	void OnDrawGizmos () {
		Gizmos.color = Color.red;
		Gizmos.DrawLine ( gameObject.transform.position, player.transform.position );
	}
}


/*

////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
 * if ( player.GetComponent<CurrentNodeAstar> ().currentNode != path.Contains ( player.GetComponent<CurrentNodeAstar> ().currentNode )) {
						while ( path.Count > 0 ) {
							GameObject tempGameobject = path.Pop ();
							tempGameobject.GetComponent<Waypoint_AStar> ().goalVisisted = false;
						}
						path.Clear ();
						path = asa.AStarSearch (
								gameObject.GetComponent<CurrentNodeAstar> ().currentNode,
								player.GetComponent<CurrentNodeAstar> ().currentNode );
					
					}
////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////

/*
 * Author(s)	:	Aparant Mane, Ashish Pardhiye, Tejas Lad
 * Purpose		:	Moves the entity to the goal
 * Dependencies	:	AStarAlgo.cs
 *
using System;
using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class AstarZombie : MonoBehaviour {


	public float speed = 5f;
	public float turnSpeed = 500.0f;
	public float sphereCastRadius = 0.5f;
	public float timeToCompute;

	private GameObject goal;
	public GameObject player;
	public GameObject[] finalPath;
	public int currentPathIndex;
	public float mass = 5.0f;
	public float timeCounter = 0f;

	public Stack<GameObject> path;
	
	public bool once = false;
	private float totalDistanceCovered;
	private float distanceCovered;
	public int temp;
	public bool buttonPressed;
	public Material blue;
	AStarAlgo asa = new AStarAlgo ();
	public int nodesExamined;
	public Vector3 newPlayerPosition;

	void Start () {
		buttonPressed = false;
	}


	void Update () {
		newPlayerPosition = player.transform.position;
		if ( buttonPressed == true ) {
			if ( false ) {

			}
			else {
				if ( Vector3.Distance ( player.transform.position, GameObject.FindGameObjectWithTag ( "AZombie" ).transform.position ) > 0.1f ) {
					if ( once == false ) {
						float timers = Time.realtimeSinceStartup;
						AStarTimeToCompute ();
						path = asa.AStarSearch (
								gameObject.GetComponent<CurrentNodeAstar> ().currentNode,
								player.GetComponent<CurrentNodeAstar> ().currentNode );
						//Debug.Log ( "Path computed for Astar in " + ( int ) ( timers * 100 ) + "ms" );
						//						Debug.Log ( timeToCompute );
						AStarTotalNodesCovered ();
						AstarNodesExamined ();

					}
					once = true;
					if ( path.Count > 0 )
						goal = path.Peek ();
					goal.GetComponent<Renderer> ().material = blue;


					if ( path.Count > 0 ) {

						AStarTotalTimeCovered ();
						if ( path.Contains ( player.GetComponent<CurrentNodeAstar> ().currentNode ) ) {

							Vector3 goalPosition = goal.transform.position;
							Vector3 goalDirection = goalPosition - transform.position;
							goalDirection.y = 0.0f;
							Vector3 normalizedGoalDirection = goalDirection.normalized;
							transform.position += transform.forward * speed * Time.deltaTime;
							transform.rotation = Quaternion.RotateTowards ( transform.rotation,
								Quaternion.LookRotation ( normalizedGoalDirection ),
								turnSpeed * Time.deltaTime );

							AStarTotalDistanceCovered ();
							if ( Vector3.Distance ( gameObject.transform.position, goalPosition ) < 0.2f ) {
								if ( goal.GetComponent<Waypoint_AStar> ().goalVisisted == false ) {

									goal.GetComponent<Waypoint_AStar> ().goalVisisted = true;
									path.Pop ();
								}
							}
						}
					}
					if ( player.transform.position != newPlayerPosition ) {
						while ( path.Count > 0 ) {
							GameObject tempGameobject = path.Pop ();
							tempGameobject.GetComponent<Waypoint_AStar> ().goalVisisted = false;
						}
						path.Clear ();
						path = asa.AStarSearch (
								gameObject.GetComponent<CurrentNodeAstar> ().currentNode,
								player.GetComponent<CurrentNodeAstar> ().currentNode );
					}
				}
			}
		}
	}

	public void AStarTotalDistanceCovered () {
		distanceCovered = Vector3.Distance ( transform.position, goal.transform.position );
		totalDistanceCovered = totalDistanceCovered + distanceCovered;
	}

	public void AStarTotalTimeCovered () {
		if ( Vector3.Distance ( player.transform.position, GameObject.FindGameObjectWithTag ( "AZombie" ).transform.position ) > 0.5f ) {
			timeCounter = Time.time + 1;
		}
	}

	public void AStarTotalNodesCovered () {
		if ( Vector3.Distance ( player.transform.position, GameObject.FindGameObjectWithTag ( "AZombie" ).transform.position ) > 0.5f ) {
			temp = path.Count;
		}
	}

	public void AStarTimeToCompute () {
		timeToCompute = Time.timeScale + 1;
	}
	public float GetAstarTotalDistanceCovered () {
		return timeCounter;
	}

	public float GetAstarTotalTimeCovered () {
		return totalDistanceCovered / 10;
	}

	public int GetAstarTotalNodes () {
		return temp;
	}

	public void ChaluKaro () {
		buttonPressed = true;
	}

	public void AstarNodesExamined () {
		nodesExamined = asa.AstarSendVisited ();
	}

	public int GetAstarTotalNodesExamined () {
		return nodesExamined;
	}
	void OnDrawGizmos () {

		Gizmos.color = Color.red;
		Gizmos.DrawLine ( gameObject.transform.position, player.transform.position );
	}
}
*/