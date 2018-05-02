using UnityEngine;
using System.Collections;

public class ChangeViewDijk : MonoBehaviour {

	public Vector3 DijkPosition = new Vector3 ( 77.7f, 123.9f, -513.2f );
	public void Move () {
		transform.position = Vector3.Lerp ( gameObject.transform.position, DijkPosition, 20f );
	}
}
//dijk
