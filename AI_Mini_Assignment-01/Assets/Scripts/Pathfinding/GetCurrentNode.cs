/*
 * This script is responsible for getting the closest node on the grid.
 * This is required since, we do not want the boid to forcefully exit the graph and go to 
 * any random location 
 * 
 */ 

using UnityEngine;
using System.Collections;

public class GetCurrentNode : MonoBehaviour {

    public GameObject currentNode;
    public bool isAI = true;    //make this only for Solver (Zombie)

    void Start () { SetCurrentNode (); }
    void Update () { SetCurrentNode (); }

    void SetCurrentNode () {
        float shortestDistance = Mathf.Infinity;    //let the shortest path be infinity
        foreach ( GameObject obj in GameObject.FindGameObjectsWithTag ( "Node" ) ) {
            float dist = ( obj.transform.position - transform.position ).magnitude;
            //finding the value of the distance between the same object and all the objects
            if ( dist < shortestDistance ) {
                shortestDistance = dist;
                currentNode = obj;
            }
        }
    }
        
    void OnTriggerEnter ( Collider col ) {
        if ( col.tag == "Node" ) {
            currentNode = col.gameObject;
        }
    }
}
