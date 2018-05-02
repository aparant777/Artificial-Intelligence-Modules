using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;

public class PathSolverAstar : MonoBehaviour {

    public float speed = 5f;
    public float turnSpeed = 500.0f;
    public float sphereCastRadius = 1.0f;
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
    Astar astar = new Astar();

    public bool once = false;
    public int count = 0;

    public int intialPathCount = 0;

    public GameObject goalGameobject;
    public List<Node> nodesToClear;
    public SpawnManager spawnManager;

    public List<Transform> tail = new List<Transform>();
    public GameObject tailPrefab;

    private void Start() {
        goalGameobject = GameObject.Find("Goal");
        spawnManager = GameObject.Find("SpawnManager").GetComponent<SpawnManager>();
    }

    void Update()
    {
        //compute the algorithm once
        if (once == false)
        {
            System.Diagnostics.Stopwatch firstTime = System.Diagnostics.Stopwatch.StartNew();
            firstTime.Start();
            path = astar.AStarSearch(
                gameObject.GetComponent<GetCurrentNode>().currentNode,
                player.GetComponent<GetCurrentNode>().currentNode);
            firstTime.Stop();

            Debug.Log("A* Total time is: "+firstTime.Elapsed);

            System.TimeSpan ts = firstTime.Elapsed;
            string temp = System.String.Format("{0:00}:{1:00}:{2:00}.{3:00}",
            ts.Hours, ts.Minutes, ts.Seconds,
            ts.Milliseconds / 10);

            if (path.Count <= 0)
            {
                Debug.Log("A*: Nodes in open list are " + astar.AstarSendVisited());
                Debug.Log("A*: Nodes in closed list are " + path.Count);
            } 
            once = true;
        }

        if (path != null)
        {
            if (path.Count > 0)
            {
                goal = path.Peek();
            }
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

                if (tail.Count > 0)
                {
                    tail.Last().position = transform.position;
                    tail.Insert(0, tail.Last());
                    tail.RemoveAt(tail.Count - 1);
                }

                if (Vector3.Distance(gameObject.transform.position, goalPosition) < 0.5f) {
                    if (goal.GetComponent<Node>().goalVisistedAstar == false) {
                        goal.GetComponent<Node>().goalVisistedAstar = true;
                        path.Pop();
                    }
                }
            }
        }

        if(path.Count == 0) {          
            //reset nodes
            spawnManager.ResetAllNodes_Astar();
            path.Clear();
            astar.ClearQueues();

            //goalGameobject.transform.position = new Vector3(
            //    gameObject.transform.position.x + 20,
            //    gameObject.transform.position.y,
            //    gameObject.transform.position.z);
            GameObject g = Instantiate(tailPrefab, transform.position, Quaternion.identity);
            tail.Insert(0, g.transform);
            FindNextGoalPosition();
            once = false;
        }


    }

    IEnumerator ExecuteAfterTime(float time)
    {
        yield return new WaitForSeconds(time);

        // Code to execute after the delay
    }

    void OnDrawGizmos() {
        //Gizmos.color = Color.red;
        //Gizmos.DrawLine ( gameObject.transform.position, player.transform.position );
    }

    public void ButtonPressed() {
        buttonPressed = true;
    }
   
    void Update1()
    {
        //compute the algorithm once
        //if (buttonPressed == true) {
        path = astar.AStarSearch(
            gameObject.GetComponent<GetCurrentNode>().currentNode,
            player.GetComponent<GetCurrentNode>().currentNode);
        Debug.Log("Path count is " + path.Count);
        intialPathCount = path.Count;
        buttonPressed = false;
        //}

        //if (path != null) {
        if (path.Count > 0)
        {
            goal = path.Peek();
        }
        //}

        //if (path != null) {
        if (path.Count > 0)
        {
            if (path.Contains(player.GetComponent<GetCurrentNode>().currentNode))
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
                    if (goal.GetComponent<Node>().goalVisistedAstar == false)
                    {
                        goal.GetComponent<Node>().goalVisistedAstar = true;
                        GameObject temp = path.Pop();
                        temp.GetComponent<Node>().ResetNode();
                        count++;
                    }
                }
            }
        }
        if (count == intialPathCount)
        {
            Debug.Log("THis is where we are");
            //goal = null;
            //path = null;
            //count = 0;

            //goalGameobject.transform.position = new Vector3(
            //    gameObject.transform.position.x + 20,
            //    gameObject.transform.position.y,
            //    gameObject.transform.position.z);


            ////reset all values of f,g,h in the search
            //spawnManager.ResetAllNodes_Astar();
        }
        //}
    }

    void FindNextGoalPosition() {

        //iterate through the list


        //selesct those which are
        //not in part of snake

        //not visited yet



        Node n = spawnManager.listOfNodeObjects[Random.Range(0, spawnManager.listOfNodeObjects.Count)];
        player.transform.position = n.gameObject.transform.position;
        //Debug.Log(goal.gameObject.name);
    }
}