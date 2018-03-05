using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KinematicArrive : MonoBehaviour {

    //public Goal goalObject;
    public GoalManager goalManager;
    private Transform goal;
    private SteeringParams sp;
    private KinematicSteering ks;
    public float radius_of_satisfaction = 0.5f; //some chutiyagiri naming....call it -----offset-----
    public float time_to_target = 0.25f;

	// Use this for initialization
	void Start () {
        //goalObject = GetComponent<Goal>();
        //goalManager = GetComponent<GoalManager>();
        sp = GetComponent<SteeringParams>();
	}
        
    public KinematicSteering getSteering()
    {
        ks = new KinematicSteering();

        //goal = goalObject.getGoal();
        goal = goalManager.GetGoal();
        //steering = new Steering();              
        Vector3 new_velc = goal.position - transform.position;

        //if the boid has come within the offset vicinity, it stops
        if (new_velc.magnitude < radius_of_satisfaction) {
            new_velc = new Vector3(0f, 0f, 0f);
            ks.velc = new_velc;
            goal = goalManager.GetNextGoal();
            return ks;
        }

        //keep increasing the speed of boid untill it reaches the offset vicinity
        new_velc = new_velc / time_to_target;
        Debug.Log(new_velc);

        //clamp the speed to its MAXSPEED
        if (new_velc.magnitude > sp.MAXSPEED)
        {
            new_velc.Normalize();
            new_velc = new_velc * sp.MAXSPEED;
        }

        ks.velc = new_velc;
        return ks;
    }
}
