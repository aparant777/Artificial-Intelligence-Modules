using UnityEngine;
using System.Collections;

public class ChangeViewDFS : MonoBehaviour {

	public Vector3 DFSPosition = new Vector3 ( 315.3f, 123.9f, -377.5f );
	public void Move () {
		transform.position = Vector3.Lerp ( gameObject.transform.position, DFSPosition, 20f );
	}
}
//dfs