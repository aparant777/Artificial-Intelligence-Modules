using System;
using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public  class Dijkstra : MonoBehaviour {  
    private int count;
    public int tempCount;
    public GameObject[] QueueToArray;
    Queue<GameObject> open = new Queue<GameObject> ();

    public Stack<GameObject> ComputePath ( GameObject start, GameObject goal ) {

        Dictionary<GameObject, GameObject> parent = new Dictionary<GameObject, GameObject> ();

        Dictionary<GameObject, float> costToGoal = new Dictionary<GameObject, float>();


        Stack<GameObject> s = new Stack<GameObject> ();
        GameObject n, child = null;
        float newCost;
        parent[start] = null;
        start.GetComponent<Node> ().nodeCost = 0;
        open.Enqueue ( start );
        while ( open.Count > 0 ) {
            n = open.Dequeue ();
            n.GetComponent<Node> ().setVisited = true;
            if ( n == goal ) {
                s.Push ( goal );
                while ( goal != start ) {
                    s.Push ( parent[goal] );
                    goal = parent[goal];
                }
                return s;
            }
            foreach ( GameObject go in n.GetComponent<Node> ().children ) {
                child = go;
                GetNodesVisisted ();
                newCost = n.GetComponent<Node>().nodeCost + 
                    Vector3.Distance(n.transform.position, go.transform.position);

                if ( child.GetComponent<Node> ().setVisited == true ) {
                    continue;
                }

                if(open.Contains(child) && child.GetComponent<Node>().nodeCost <= newCost)
                    continue;

                parent[child] = n;

                child.GetComponent<Node> ().nodeCost = newCost;

                if ( !open.Contains ( child ) ) {
                    open.Enqueue ( child );
                }

                else {
                    QueueSort (); 
                }
            }
        }
        return null;
    }

    public void QueueSort () {
        int i ,j;
        GameObject temp;
        QueueToArray = open.ToArray();
        for ( i = QueueToArray.Length-2 ; i >= 0 ; i-- ) {
            for ( j = 0 ; j <= i ; j++ ) {
                if( QueueToArray[j].GetComponent<Node>().nodeCost > 
                    QueueToArray[j+1].GetComponent<Node>().nodeCost ) {
                    temp = QueueToArray[j];
                    QueueToArray[j] = QueueToArray[j+1];
                    QueueToArray[j+1] = temp;
                }
            }
        }
        open.Clear();
        for ( i=0; i<QueueToArray.Length; i++) {
            open.Enqueue(QueueToArray[i]);
        }   
    }

    public void GetNodesVisisted () {
        count++;
        tempCount = count;
    }

    public int DijkstraSendVisited () {
        return tempCount;
    }
}