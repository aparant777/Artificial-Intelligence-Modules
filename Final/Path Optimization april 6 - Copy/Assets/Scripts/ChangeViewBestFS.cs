using UnityEngine;
using System.Collections;
//a
public class ChangeViewBestFS : MonoBehaviour {

	public Vector3 BestFSPosition = new Vector3 ( 242.9f, 123.9f, -513.2f );
	public void Move () {
		transform.position = Vector3.Lerp ( gameObject.transform.position, BestFSPosition, 20f );
	}
}
