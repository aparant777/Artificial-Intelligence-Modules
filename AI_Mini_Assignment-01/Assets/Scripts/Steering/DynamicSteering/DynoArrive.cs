using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DynoArrive : MonoBehaviour {
   
    public GoalManager goalManager;
    private Transform goal;
    private SteeringParams sp;
    private DynoSteering ds;
    private Kinematic charRigidBody;
    public float goalRadius = 0.5f;
    public float slowRadius = 4.5f;
    public float time_to_target = 0.25f;
    private Vector3 direction;
    private float distance;
    private float targetSpeed;
    private Vector3 targetVelocity;

    // Use this for initialization
    void Start () {
        //goalObject = GetComponent<Goal>();
        sp = GetComponent<SteeringParams>();
        charRigidBody = GetComponent<Kinematic>();
    }
	
	// Update is called once per frame
	public DynoSteering getSteering () {

        ds = new DynoSteering();
        goal = goalManager.GetGoal();

        direction = goal.position - transform.position;
        distance = direction.magnitude;

        //adjust speed with distance
        if (distance > slowRadius)
        {
            targetSpeed = sp.MAXSPEED;
        } else
        {
            targetSpeed = sp.MAXSPEED * distance / slowRadius;
        }


        if (distance < goalRadius){
            if(targetSpeed < 0.5f)
                goal = goalManager.GetNextGoal();
        }

        targetVelocity = direction;
        targetVelocity.Normalize();
        targetVelocity = targetVelocity * targetSpeed;

        ds.force = targetVelocity - charRigidBody.getVelocity();
        ds.force = ds.force / time_to_target;

        if (ds.force.magnitude > sp.MAXACCEL)
        {
            ds.force.Normalize();
            ds.force = ds.force * sp.MAXACCEL;
        }
        ds.torque = 0f;

        return ds;
	}
}
