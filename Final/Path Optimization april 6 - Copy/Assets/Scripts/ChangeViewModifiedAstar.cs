using UnityEngine;
using System.Collections;

public class ChangeViewModifiedAstar : MonoBehaviour {

	public Vector3 ModifiedAStarPosition = new Vector3 ( 315.3f, 123.9f, -377.5f );
	public void Move () {
		transform.position = Vector3.Lerp ( gameObject.transform.position, ModifiedAStarPosition, 20f );
	}
}
//a*mod