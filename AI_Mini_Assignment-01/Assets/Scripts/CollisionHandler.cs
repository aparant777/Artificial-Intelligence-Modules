using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CollisionHandler : MonoBehaviour {

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    private void OnCollisionEnter(Collision collision)
    {
        Vector3 location = Vector3.zero;
        //Get closest safeLocation in Child
        {
            float distanceToSafePoint = float.MaxValue;
            for (int index = 0; index < transform.childCount; index++)
            {
                if (distanceToSafePoint > (collision.gameObject.transform.position - transform.GetChild(index).transform.position).magnitude)
                {
                    distanceToSafePoint = (collision.gameObject.transform.position - transform.GetChild(index).transform.position).magnitude;
                    location = transform.GetChild(index).transform.position;
                }
            }

            collision.gameObject.GetComponent<SteeringBehavior_Wandering>().ToggleWanderBehavior();
            collision.gameObject.GetComponent<SteeringBehavior_Wandering>().MoveToSafeLocation(location);
        }
    }
}
