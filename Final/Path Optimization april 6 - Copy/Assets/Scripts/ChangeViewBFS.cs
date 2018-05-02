using UnityEngine;
using System.Collections;

public class ChangeViewBFS : MonoBehaviour {

	public Vector3 BFSPosition = new Vector3 ( 165.7f, 123.9f, -377.5f );
	public void Move () {
		transform.position = Vector3.Lerp ( gameObject.transform.position, BFSPosition, 20f );
	}
}
//bfs