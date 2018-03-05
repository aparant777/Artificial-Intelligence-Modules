using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KinematicSeek : MonoBehaviour {

    private KinematicSteering steering;
    private SteeringParams sp;
    //private Goal goalObject;
    public GoalManager goalManager;
    private Transform goal;


    void Start () {
        //goalObject = GetComponent<Goal>();
        //goalManager.GetComponent<GoalManager>();
        sp = GetComponent<SteeringParams>();
    }
	
	public KinematicSteering getSteering () {        
        goal = goalManager.GetGoal();
        //goal = goalObject.getGoal();
        steering = new KinematicSteering();
        steering.velc = goal.position - this.transform.position;
        steering.velc.Normalize();
        steering.velc = steering.velc * sp.MAXSPEED;
        return steering;
    }
}
