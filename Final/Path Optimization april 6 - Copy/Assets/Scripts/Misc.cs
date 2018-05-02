using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class Misc : MonoBehaviour {
	Dictionary<int, int> name = new Dictionary<int, int> ();

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per fram
	void Update () {

		Debug.Log ( name.Keys);
	}

}
