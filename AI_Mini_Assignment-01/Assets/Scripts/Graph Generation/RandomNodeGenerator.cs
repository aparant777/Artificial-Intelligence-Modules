using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RandomNodeGenerator : MonoBehaviour {

    public List<RandomNode> nodeList;
    public int NumberOfNodes;
    public float randomGeneratedLength;
    public GameObject nodeObject;
    public int MaxNumberOfConnectionPerNode;
    public int MaxDistanceForConnection;

    private void Start() {
        GenerateGraph(NumberOfNodes);
    }

    void GenerateGraph(int numberOfNodes)
    {
        nodeList = new List<RandomNode>(NumberOfNodes);
        for (int i = 0; i < numberOfNodes; i++) {
            Vector3 position = new Vector3(Random.Range(-randomGeneratedLength, randomGeneratedLength), 0f, Random.Range(-randomGeneratedLength, randomGeneratedLength));

            GameObject go = Instantiate(nodeObject, position, Quaternion.identity);
            RandomNode node = go.GetComponent<RandomNode>();
            go.name = "cube " + i;
            node.ID = i;
            nodeList.Add(node);
        }
        for (int i = 0; i < numberOfNodes; i++) {
            List<RandomNode> tempNodeList = new List<RandomNode>(nodeList);
            tempNodeList.RemoveAt(i);
            int NumberOfConnectedNodes = (int)Random.Range(1, MaxNumberOfConnectionPerNode);
            while (nodeList[i].connectedNode.Count < NumberOfConnectedNodes || tempNodeList.Count == 0)
            {
                int listLength = tempNodeList.Count;
                int index = (int)Random.Range(0, listLength);
                RandomNode randomNodeInList = tempNodeList[index];
                float distance = Vector3.Distance(nodeList[i].transform.position, randomNodeInList.transform.position);
                if (randomNodeInList.connectedNode.Count == MaxNumberOfConnectionPerNode || distance > MaxDistanceForConnection)
                    tempNodeList.RemoveAt(index);
                else {
                    nodeList[i].connectedNode.Add(randomNodeInList);
                    nodeList[i].connectingEdge.Add(distance);
                    randomNodeInList.connectedNode.Add(nodeList[i]);
                    randomNodeInList.connectingEdge.Add(distance);
                    tempNodeList.RemoveAt(index);
                }
            }
        }
    }
}
