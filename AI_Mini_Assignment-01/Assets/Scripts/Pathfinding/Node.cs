using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Node : MonoBehaviour {
   
    //public List<GameObject> neighbors = new List<GameObject> ();
    public bool goalVisisted = false;
    public float nodeRadius = 50.0f;
    public GameObject goal;
    public bool setVisited;
    public float nodeCost;
     
    public GameObject[] children;

    public int rowPosition;
    public int columnPosition;

    void OnDrawGizmos() {
       Gizmos.color = Color.red;
       Gizmos.DrawWireCube(transform.position, Vector3.one);
       LineDraw();
    }

    void LineDraw(){
        foreach (GameObject go in children){
            Gizmos.DrawLine(transform.position, go.transform.position);
        }
    }
}
