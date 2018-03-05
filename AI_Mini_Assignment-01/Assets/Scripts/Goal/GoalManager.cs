using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GoalManager : MonoBehaviour {

    private GameObject previousGoal;
    public GameObject goalObject;

    public Transform goal;

    public int goal_index = 0;

    private float time_since_goal_switch = 0f;
    public float orientation;

    public Material non_goal_material;
    public Material goal_material;

    private bool changed_goal = false;

    public List<GameObject> listOfGoals;

  
    void Start() {
        previousGoal = goalObject;
        orientation = 0f;
        goalObject = listOfGoals[goal_index];
        goalObject.GetComponent<Renderer>().material = goal_material;      
        goal = goalObject.transform;
    }

    void Update() {
        if (previousGoal != goalObject)
        {
            changed_goal = true;
            goal = goalObject.transform;
        }

        if (changed_goal)
        {
            previousGoal.GetComponent<Renderer>().material = non_goal_material;
            //previousGoal.AddComponent<Material>(non_goal_material);
            goalObject.GetComponent<Renderer>().material = goal_material;
            //goalObject.AddComponent<Material>(goal_material);
            changed_goal = false;
            previousGoal = goalObject;
        }
    }

    public Transform GetNextGoal(){
        if (goal_index < listOfGoals.Count - 1){
            //previousGoal = goalObject;
            goal_index += 1;
            changed_goal = true;
        } else{
            goal_index = 0;
        }
        orientation = 0f;

        goalObject = listOfGoals[goal_index];      
        return goalObject.transform;
    }

    public Transform GetGoal() {
        return goal;
    }

    public float GetOrientation() {
        return orientation;
    }
}
