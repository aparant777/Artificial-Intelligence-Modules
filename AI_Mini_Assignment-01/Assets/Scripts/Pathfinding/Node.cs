using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Node : MonoBehaviour {
   
    //public List<GameObject> neighbors = new List<GameObject> ();
    public bool goalVisistedDijkstra = false;
    public bool goalVisistedAstar = false;
    public float nodeRadius = 50.0f;
    public GameObject goal;
    public float nodeCost;

    //A* stuff
    public float gValue;
    public float hValue;
    public float fValue;

    public bool setVisitedAstar;
    public bool setVisitedDijkstra;

    public GameObject[] children;

    public int rowPosition;
    public int columnPosition;

    void OnDrawGizmos() {
       Gizmos.color = Color.red;
       Gizmos.DrawWireCube(transform.position, Vector3.one);
       //LineDraw();
    }

    void LineDraw(){
        foreach (GameObject go in children){
            Gizmos.DrawLine(transform.position, go.transform.position);
        }
    }

    public void ResetNode() {
        gValue = 0.0f;
        hValue = 0.0f;
        fValue = 0.0f;
        goalVisistedAstar = false;
        //goalVisistedDijkstra = false;
    }
}
