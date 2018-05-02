using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Astar_random : MonoBehaviour
{

    public int nodesVisited;
    private int count;
    public int tempCount;
    RandomNode[] QueueToArray;
    public Queue<RandomNode> open = new Queue<RandomNode>();
    public Queue<RandomNode> closed = new Queue<RandomNode>();

    public Stack<RandomNode> AStarSearch(RandomNode start, RandomNode goal)
    {
        Dictionary<RandomNode, RandomNode> parent = new Dictionary<RandomNode, RandomNode>();
        Dictionary<RandomNode, float> f_value = new Dictionary<RandomNode, float>();

        float g, f, newg, h;
        float timeToCompute = 0f;

        Stack<RandomNode> s = new Stack<RandomNode>();

        int i, j;

        RandomNode temp = null;
        RandomNode n, child = null;

        parent[start] = null;
        open.Enqueue(start);

        while (open.Count > 0)
        {
            n = open.Dequeue();

            ///Debug.Log (n.GetComponent<Waypoint_BFS> ().isVisited = true );
            ///Debug.Log ( "goal is " + goal );

            if (n == goal)
            {
                s.Push(goal);
                while (goal != start)
                {

                    s.Push(parent[goal]);
                    //Debug.Log ( parent[goal] );
                    goal = parent[goal];
                }
                //			
                //Debug.Log ( "path computed of Astar in "+timeToCompute +"ms");
                return s;
                //return true;
            }

            foreach (RandomNode go in n.GetComponent<RandomNode>().connectedNode)
            {
                child = go;
                newg = n.GetComponent<RandomNode>().gValue +
                    Vector3.Distance(n.transform.position, child.transform.position); //+ Vector3.Distance(child.transform.position, goal.transform.position);
                                                                                      ///Debug.Log ( "child is " + child );
                if ((open.Contains(child) || closed.Contains(child))
                    && child.GetComponent<RandomNode>().gValue <= newg)
                {
                    GetNodesVisisted();

                    continue;
                }
                //if ( child.GetComponent<Waypoint_AStar> ().isVisited == false ) {
                ///Debug.Log ( "i am here" );

                //if ( child.GetComponent<Waypoint_AStar> ().goalVisisted != true )

                //GetNodes ();
                //				Debug.Log ( nodesExamined );
                parent[child] = n;
                child.GetComponent<RandomNode>().gValue = newg;
                child.GetComponent<RandomNode>().hValue = Vector3.Distance(child.transform.position, goal.transform.position);
                child.GetComponent<RandomNode>().fValue = child.GetComponent<RandomNode>().gValue + child.GetComponent<RandomNode>().hValue;

                //Debug.Log ( "g is " + g );
                //Debug.Log ( "h is " + h );
                //Debug.Log ( "f is " + f );
                if (closed.Contains(child))
                {
                    closed.Dequeue();
                    //GetNodesVisisted (); 
                }
                if (open.Contains(child) == false)
                {
                    open.Enqueue(child);
                    //GetNodesVisisted (); 

                } else
                {
                    //GetNodesVisisted (); 
                    QueueSort();//requeue
                }
            }

            closed.Enqueue(n);
        }
        return null;
    }
    public void GetNodesVisisted()
    {
        count++;
        tempCount = count;
    }

    public int AstarSendVisited()
    {
        return tempCount;
    }

    public void QueueSort()
    {
        int i, j;
        RandomNode temp;
        QueueToArray = open.ToArray();
        for (i = QueueToArray.Length - 2; i >= 0; i--)
        {
            for (j = 0; j <= i; j++)
            {
                if (QueueToArray[j].GetComponent<RandomNode>().fValue >
                        QueueToArray[j + 1].GetComponent<RandomNode>().fValue)
                {
                    temp = QueueToArray[j];
                    QueueToArray[j] = QueueToArray[j + 1];
                    QueueToArray[j + 1] = temp;
                }
            }
        }
        open.Clear();
        for (i = 0; i < QueueToArray.Length; i++)
        {
            open.Enqueue(QueueToArray[i]);
        }
    }
}
