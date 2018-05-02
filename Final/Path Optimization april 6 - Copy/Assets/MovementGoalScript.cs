using UnityEngine;
using System.Collections;

public class MovementGoalScript : MonoBehaviour {

	Vector3 point;
	public GameObject dfsGoal;
	public GameObject bfsGoal;
	public GameObject astarModifiedGoal;
	public GameObject bestfsGoal;
	public GameObject dijkstraGoal;

	void Start () {
		dfsGoal = GameObject.FindGameObjectWithTag ( "DFSPlayer" );
		bfsGoal = GameObject.FindGameObjectWithTag ( "BFSPlayer" );
		astarModifiedGoal = GameObject.FindGameObjectWithTag ( "AModifiedPlayer" );
		bestfsGoal = GameObject.FindGameObjectWithTag ( "BestFSPlayer" );
		dijkstraGoal = GameObject.FindGameObjectWithTag ( "DijkPlayer" );
	}
	void OnMouseDrag () {
		point = Camera.main.ScreenToWorldPoint ( Input.mousePosition );
		point.y = transform.position.y;
		transform.position = point;
		dfsGoal.transform.position = point + new Vector3 ( 435f, 0f, -155f );
		bfsGoal.transform.position = point + new Vector3 ( 435f, 0f, 3f );
		astarModifiedGoal.transform.position = point + new Vector3 ( 230f, 0f, 1f );
		bestfsGoal.transform.position = point + new Vector3 ( 230f, 0f, -155f );
		dijkstraGoal.transform.position = point + new Vector3 ( 0f, 0f, -155f );
	}
}
