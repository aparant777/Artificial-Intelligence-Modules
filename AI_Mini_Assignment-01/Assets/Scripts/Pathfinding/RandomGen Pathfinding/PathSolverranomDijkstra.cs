using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PathSolverranomDijkstra : MonoBehaviour {

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

    public Stack<RandomNode> path;
    public int temp;
    public Material blue;
    Dijkstra_random dj = new Dijkstra_random();

    public bool once = false;

    void Update()
    {
        //compute the algorithm once
        if (once == false)
        {

            System.Diagnostics.Stopwatch firstTime = System.Diagnostics.Stopwatch.StartNew();
            firstTime.Start();

            path = dj.ComputePath(
                gameObject.GetComponent<GetCurrentNode>().currentNode.GetComponent<RandomNode>(),
                player.GetComponent<GetCurrentNode>().currentNode.GetComponent<RandomNode>());

            firstTime.Stop();
            Debug.Log("Dijkstra: Total time is: " + firstTime.ElapsedMilliseconds);

            System.TimeSpan ts = firstTime.Elapsed;
            string temp = System.String.Format("{0:00}:{1:00}:{2:00}.{3:00}",
            ts.Hours, ts.Minutes, ts.Seconds,
            ts.Milliseconds / 10);

            Debug.Log("Dijkstra: Nodes in open list are " + dj.DijkstraSendVisited());
            Debug.Log("Dijkstra: Nodes in closed list are " + path.Count);

            once = true;
        }

        if (path.Count > 0)
        {
            goal = path.Peek().gameObject;
        }

        goal.GetComponent<Renderer>().material = blue;

        if (path.Count > 0)
        {
            if (path.Contains(player.GetComponent<GetCurrentNode>().currentNode.GetComponent<RandomNode>()))
            {

                Vector3 goalPosition = goal.transform.position;
                Vector3 goalDirection = goalPosition - transform.position;
                goalDirection.y = 0.0f;
                Vector3 normalizedGoalDirection = goalDirection.normalized;
                transform.position += transform.forward * speed * Time.deltaTime;
                transform.rotation = Quaternion.RotateTowards(transform.rotation,
                    Quaternion.LookRotation(normalizedGoalDirection),
                    turnSpeed * Time.deltaTime);


                if (Vector3.Distance(gameObject.transform.position, goalPosition) < 0.5f)
                {
                    if (goal.GetComponent<RandomNode>().goalVisistedDijkstra == false)
                    {
                        goal.GetComponent<RandomNode>().goalVisistedDijkstra = true;
                        path.Pop();
                    }
                }
            }
        }

    }

    void OnDrawGizmos()
    {
        //Gizmos.color = Color.red;
        //Gizmos.DrawLine ( gameObject.transform.position, player.transform.position );
    }

    public void ButtonPressed()
    {
        buttonPressed = true;
    }
}
