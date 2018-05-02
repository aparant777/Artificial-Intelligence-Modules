using System;
using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class Dijkstra_random : MonoBehaviour
{
    private int count;
    public int tempCount;
    public RandomNode[] QueueToArray;
    Queue<RandomNode> open = new Queue<RandomNode>();

    public Stack<RandomNode> ComputePath(RandomNode start, RandomNode goal)
    {

        Dictionary<RandomNode, RandomNode> parent = new Dictionary<RandomNode, RandomNode>();

        Dictionary<RandomNode, float> costToGoal = new Dictionary<RandomNode, float>();


        Stack<RandomNode> s = new Stack<RandomNode>();
        RandomNode n, child = null;
        float newCost;
        parent[start] = null;
        start.GetComponent<RandomNode>().nodeCost = 0;
        open.Enqueue(start);
        while (open.Count > 0)
        {
            n = open.Dequeue();
            n.GetComponent<RandomNode>().setVisitedDijkstra = true;
            if (n == goal)
            {
                s.Push(goal);
                while (goal != start)
                {
                    s.Push(parent[goal]);
                    goal = parent[goal];
                }
                return s;
            }
            foreach (RandomNode go in n.GetComponent<RandomNode>().connectedNode)
            {
                child = go;
                GetNodesVisisted();
                newCost = n.GetComponent<RandomNode>().nodeCost +
                    Vector3.Distance(n.transform.position, go.transform.position);

                if (child.GetComponent<RandomNode>().setVisitedDijkstra == true)
                {
                    continue;
                }

                if (open.Contains(child) && child.GetComponent<RandomNode>().nodeCost <= newCost)
                    continue;

                parent[child] = n;

                child.GetComponent<RandomNode>().nodeCost = newCost;

                if (!open.Contains(child))
                {
                    open.Enqueue(child);
                } else
                {
                    QueueSort();
                }
            }
        }
        return null;
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
                if (QueueToArray[j].GetComponent<RandomNode>().nodeCost >
                    QueueToArray[j + 1].GetComponent<RandomNode>().nodeCost)
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

    public void GetNodesVisisted()
    {
        count++;
        tempCount = count;
    }

    public int DijkstraSendVisited()
    {
        return tempCount;
    }
}