/**/

using System;
using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class PathSolver : MonoBehaviour {
  
    public float speed = 5f;
    public float turnSpeed = 500.0f;
    public float sphereCastRadius = 0.5f;
    public float timeToCompute;

    public GameObject goal;
    public GameObject player;
    public GameObject[] finalPath;
    public int currentPathIndex;
    public float mass = 5.0f;
    public float timeCounter = 0f;
    public bool buttonPressed;

    public Stack<GameObject> path;
    public int temp;
    public Material blue;
    Dijkstra dj = new Dijkstra ();

    public bool once = false;

    void Update(){
        //compute the algorithm once
        if (once == false) {

            System.Diagnostics.Stopwatch firstTime = System.Diagnostics.Stopwatch.StartNew();
            firstTime.Start();

            path = dj.ComputePath(
                gameObject.GetComponent<GetCurrentNode>().currentNode,
                player.GetComponent<GetCurrentNode>().currentNode);

            firstTime.Stop();
            Debug.Log("Dijkstra: Total time is: " + firstTime.Elapsed);

            System.TimeSpan ts = firstTime.Elapsed;
            string temp = System.String.Format("{0:00}:{1:00}:{2:00}.{3:00}",
            ts.Hours, ts.Minutes, ts.Seconds,
            ts.Milliseconds / 10);

            Debug.Log("Dijkstra: Nodes in open list are "+dj.DijkstraSendVisited());
            Debug.Log("Dijkstra: Nodes in closed list are " + path.Count);
            
            once = true;
        }

        if (path.Count > 0){
            goal = path.Peek();
        }

        goal.GetComponent<Renderer>().material = blue;

        if (path.Count > 0) {
            if (path.Contains(player.GetComponent<GetCurrentNode>().currentNode)) {

                Vector3 goalPosition = goal.transform.position;
                Vector3 goalDirection = goalPosition - transform.position;
                goalDirection.y = 0.0f;
                Vector3 normalizedGoalDirection = goalDirection.normalized;
                transform.position += transform.forward * speed * Time.deltaTime;
                transform.rotation = Quaternion.RotateTowards(transform.rotation,
                    Quaternion.LookRotation(normalizedGoalDirection),
                    turnSpeed * Time.deltaTime);


                if (Vector3.Distance(gameObject.transform.position, goalPosition) < 0.5f) {
                    if (goal.GetComponent<Node>().goalVisistedDijkstra == false) {
                        goal.GetComponent<Node>().goalVisistedDijkstra = true;
                        path.Pop();
                    }
                }
            }
        } 
                
    }

    void OnDrawGizmos () {
        //Gizmos.color = Color.red;
        //Gizmos.DrawLine ( gameObject.transform.position, player.transform.position );
    }

   public void ButtonPressed(){
        buttonPressed = true;
    }
}
