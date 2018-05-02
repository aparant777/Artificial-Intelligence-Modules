using UnityEngine;
using System.Collections;

public class RestartLevel : MonoBehaviour {

	public void Restart () {
		Application.LoadLevel ( 0 );
	}
}
//a