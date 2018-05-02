using System;
using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class DijkstraZombie : MonoBehaviour {


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
	public bool buttonPressed;

	public Stack<GameObject> path;
	float count = 0f;
	public bool once = false;
	private float totalDistanceCovered;
	private float distanceCovered;
	public int nodesExamined;
	float timers = 0f;
	public int temp;
	public Material blue;
	Dijkstra dj = new Dijkstra ();

	void Start () {
		buttonPressed = false;
	}
	void Update () {
		if ( buttonPressed == true ) {
			if ( false ) {
			}
			else {
				if ( once == false ) {
					timers = Time.realtimeSinceStartup;
					path = dj.ComputePath (
							gameObject.GetComponent<CurrentNodeDijkstra> ().currentNode,
							player.GetComponent<CurrentNodeDijkstra> ().currentNode );
					Debug.Log ( "Time Required to execute Dijkstra is" + timers );
					DijkstraTotalNodesCovered ();

					DijkstraNodesExamined ();
				}
				once = true;
				if ( path.Count > 0 )
					goal = path.Peek ();
				goal.GetComponent<Renderer> ().material = blue;

				if ( path.Count > 0 ) {

					DijkstraTotalTimeCovered ();
					if ( path.Contains ( player.GetComponent<CurrentNodeDijkstra> ().currentNode ) ) {

						Vector3 goalPosition = goal.transform.position;
						Vector3 goalDirection = goalPosition - transform.position;
						goalDirection.y = 0.0f;
						Vector3 normalizedGoalDirection = goalDirection.normalized;
						transform.position += transform.forward * speed * Time.deltaTime;
						transform.rotation = Quaternion.RotateTowards ( transform.rotation,
							Quaternion.LookRotation ( normalizedGoalDirection ),
							turnSpeed * Time.deltaTime );

						DijkstraTotalDistanceCovered ();
						if ( Vector3.Distance ( gameObject.transform.position, goalPosition ) < 0.5f ) {
							if ( goal.GetComponent<Waypoint_Dijkstra> ().goalVisisted == false ) {
								goal.GetComponent<Waypoint_Dijkstra> ().goalVisisted = true;
								path.Pop ();

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

	public void DijkstraTotalDistanceCovered () {
		distanceCovered = Vector3.Distance ( transform.position, goal.transform.position );
		totalDistanceCovered = totalDistanceCovered + distanceCovered;
	}

	public void DijkstraTotalTimeCovered () {
		if ( Vector3.Distance ( player.transform.position, GameObject.FindGameObjectWithTag ( "DijkZombie" ).transform.position ) > 0.5f ) {
			timeCounter = Time.deltaTime + timeCounter;
		}
	}

	public void DijkstraTotalNodesCovered () {
		if ( Vector3.Distance ( player.transform.position, GameObject.FindGameObjectWithTag ( "DijkZombie" ).transform.position ) > 0.5f ) {
			temp = path.Count;
		}
	}

	public void DijkstraTimeToCompute () {
		timeToCompute = Time.timeScale + 1;
	}
	public float GetDijkstraTotalDistanceCovered () {
		return timeCounter;
	}

	public float GetDijkstraTotalTimeCovered () {
		return totalDistanceCovered / 10;
	}

	public int GetDijkstraTotalNodes () {
		return temp;
	}

	public void ChaluKaro () {
		buttonPressed = true;
	}

	public void DijkstraNodesExamined () {
		nodesExamined = dj.DijkstraSendVisited ();
	}

	public float GetDijkstraExecutionTime () {
		return timers;
	}

	public int GetDijkstraTotalNodesExamined () {
		return nodesExamined;
	}
}
