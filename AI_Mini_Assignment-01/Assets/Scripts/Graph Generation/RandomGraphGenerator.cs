using UnityEngine;
using System.Collections.Generic;

public class RandomGraphGenerator : MonoBehaviour {

    public GameObject nodePrefab;
    public float acceptanceRadius;

    public const int rowLength = 10;
    public const int columLength = 10;

    public float seperationX;
    public float seperationZ;

    public List<GameObject> listOfNodes;
    public int spawnCounter;

    public float spawnAcceptanceRadius;

    private void Start() {
        //SpawnNodes();
        RandomSpawn();
    }

    void SpawnNodes() {
        for (int i = 1; i <= rowLength; i++) {
            for (int j = 1; j <= columLength; j++) {
                SpawnNode(i, j);
                spawnCounter++;
            }
        }
    }

    void SpawnNode(int rowNumber, int columnNumber)
    {
        seperationX = Random.Range(5, 15);
        seperationZ = Random.Range(5, 15); 

        GameObject node = null;
        GameObject previousNode = node;

        //if (spawnCounter == 0) {
        node = Instantiate(nodePrefab,
            new Vector3(transform.position.x + seperationX * rowNumber,
                        transform.position.y,
                        transform.position.z + seperationZ * columnNumber),
            Quaternion.identity) as GameObject;

        node.GetComponent<Node>().rowPosition = rowNumber;
        node.GetComponent<Node>().columnPosition = columnNumber;
        //} else {
        // previousNode = node;

        // previousNode.GetComponent<Node>().rowPosition = rowNumber;
        // previousNode.GetComponent<Node>().columnPosition = columnNumber;
        //}

        //probability = Random.Range(1,10);
        listOfNodes.Add(node);
    }


    void RandomSpawn() {

        for(int i = 0; i < 10; i++)
        {
            seperationX = Random.Range(5, 10);
            seperationZ = Random.Range(5, 10);

            GameObject node = Instantiate(nodePrefab,
            new Vector3(transform.position.x + seperationX,
                        transform.position.y,
                        transform.position.z + seperationZ),
            Quaternion.identity) as GameObject;


        }
    }
}
