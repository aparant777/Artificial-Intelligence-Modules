using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RandomNode : MonoBehaviour
{
    public List<RandomNode> connectedNode;
    public List<float> connectingEdge;
    public int ID;

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

    public RandomNode()
    {
        connectedNode = new List<RandomNode>();
        connectingEdge = new List<float>();
        ID = -1;
    }

    public RandomNode(int i_ID)
    {
        connectedNode = new List<RandomNode>();
        connectingEdge = new List<float>();
        ID = i_ID;
    }

    public override bool Equals(object other)
    {
        if (other == null)
            return false;
        RandomNode node = other as RandomNode;
        return ID == node.ID;
    }

    public override int GetHashCode()
    {
        return ID;
    }

    public bool Equals(RandomNode other)
    {
        if (other == null)
            return false;
        return ID == other.ID;
    }

    void OnDrawGizmos()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireCube(transform.position, Vector3.one);
        LineDraw();
    }

    void LineDraw()
    {
        foreach (RandomNode go in connectedNode)
        {
            Gizmos.DrawLine(transform.position, go.gameObject.transform.position);
        }
    }

}