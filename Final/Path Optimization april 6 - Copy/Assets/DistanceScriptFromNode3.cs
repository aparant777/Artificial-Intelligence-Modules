using UnityEngine;
using System.Collections;

public class DistanceScriptFromNode3 : MonoBehaviour {

	public GameObject source;
	public GameObject goal;

	void Update () {

		int gValue = ( int ) Vector3.Distance ( transform.position, source.transform.position );
		int hValue = ( int ) Vector3.Distance ( transform.position, goal.transform.position );
		int fValue = gValue + hValue;


		Debug.Log ( "Value of G from 3 to 1 - " + gValue );

		Debug.Log ( "Value of H from 3 to Goal - " + hValue );

		Debug.Log ( "Value of F for 3 is " + fValue );
	}
}
//cost