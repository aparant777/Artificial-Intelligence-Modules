using UnityEngine;
using System.Collections;

public class ChangeViewAstar : MonoBehaviour {

	public Vector3 AstarPosition = new Vector3 ( 14.1f, 123.9f, -378.1f );
	public void Move () {
		transform.position = Vector3.Lerp ( gameObject.transform.position, AstarPosition, 20f);
	}
}

//