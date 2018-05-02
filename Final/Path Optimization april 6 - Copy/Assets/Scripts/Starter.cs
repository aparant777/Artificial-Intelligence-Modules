using UnityEngine;
using System.Collections;

public class Starter : MonoBehaviour {

	public GameObject bfsZombie;
	public GameObject bfsGoal;

	public GameObject astarZombie;
	public GameObject astarGoal;

	public GameObject dfsZombie;
	public GameObject dfsGoal;

	public GameObject bestZombie;
	public GameObject bestGoal;

	public GameObject astarModifiedZombie;
	public GameObject astarModifiedGoal;

	public GameObject dijkstraZombie;
	public GameObject dijkstraGoal;

	public bool bfsReady = false;
	public bool astarReady = false;
	public bool dfsReady = false;
	public bool bestReady = false;
	public bool astarModifiedReady = false;
	public bool dijkstraReady = false;

	float bfsValue;
	float astarValue;

	void Start () {
		
	}

	void Update () {
		if ( Vector3.Distance ( bfsZombie.transform.position, bfsGoal.transform.position ) < 3f )
			bfsReady = true;

		if ( Vector3.Distance ( astarZombie.transform.position, astarGoal.transform.position ) < 3f )
			astarReady = true;

		if ( Vector3.Distance ( dfsZombie.transform.position, dfsGoal.transform.position ) < 3f )
			dfsReady = true;

		if ( Vector3.Distance ( bestZombie.transform.position, bestGoal.transform.position ) < 3f )
			bestReady = true;

		if ( Vector3.Distance ( astarModifiedZombie.transform.position, astarModifiedGoal.transform.position ) < 3f )
			astarModifiedReady = true;

		if ( Vector3.Distance ( dijkstraZombie.transform.position, dijkstraGoal.transform.position ) < 3f )
			dijkstraReady = true;
	}
}
/*
 * 
 * 
 * 
 * starter
 * 
 * 
 */
