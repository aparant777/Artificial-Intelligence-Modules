using UnityEngine;
using System.Collections;

public class DistanceScripts : MonoBehaviour {

	public GameObject neighbour1;
	public GameObject neighbour2;
	public GameObject goal;

	public int gValueNode1;
	public int gValueNode2;

	public int hValueNode1;
	public int hValueNode2;

	public int fValueNode1;
	
	void Update () {

		gValueNode1 =  ( int ) Vector3.Distance ( transform.position, neighbour1.transform.position );
		gValueNode2 =  ( int ) Vector3.Distance ( transform.position, neighbour2.transform.position );

		gValueNode1 =  ( int ) Vector3.Distance ( transform.position, neighbour1.transform.position );
		gValueNode1 =  ( int ) Vector3.Distance ( transform.position, neighbour1.transform.position );
		gValueNode1 =  ( int ) Vector3.Distance ( transform.position, neighbour1.transform.position );
	}
}
