using UnityEngine;
using UnityEngine.Collections;
using System.Collections.Generic;

public class SpawnManager : MonoBehaviour {

    public GameObject nodePrefab;
    public const int rowLength = 50;
    public const int columLength = 50;

    public float seperationX;
    public float seperationZ;

    public List<GameObject> listOfNodes;

    public float probability;
    public float randomNumber;

    public int spawnCounter;

    void Start() { 
        SpawnNodes(); 
        CalculateChildren();
        spawnCounter = 0;
    }

    void SpawnNodes() {
        for (int i = 1; i <= rowLength; i++) {
            for (int j = 1; j <= columLength; j++) {
                SpawnNode(i,j);
                spawnCounter++;
            }
        }
    }

    void SpawnNode(int rowNumber, int columnNumber) {
        seperationX = Random.Range(5, 7);
        seperationZ = Random.Range(5, 7);

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

        listOfNodes.Add(node);  
    }

    void CalculateChildren() {
        for(int i=0;i<listOfNodes.Count;i++){

            Node node = listOfNodes[i].GetComponent<Node>();

            //top left
            if (node.rowPosition == 1){
                if (node.columnPosition == 1){
                    node.children = new GameObject[2];
                    node.children[0] = listOfNodes[i + 1];
                    node.children[1] = listOfNodes[i + rowLength];
                }
            }

            //top right
            if (node.rowPosition == 1){
                if (node.columnPosition == columLength){
                    node.children = new GameObject[2];
                    node.children[0] = listOfNodes[i - 1];
                    node.children[1] = listOfNodes[i + rowLength];
                }
            }

            //bottom left
            if (node.rowPosition == rowLength){
                if (node.columnPosition == 1){
                    node.children = new GameObject[2];
                    node.children[0] = listOfNodes[i + 1];
                    node.children[1] = listOfNodes[i - rowLength];
                }
            }

            //bottom right
            if (node.rowPosition == rowLength){
                if (node.columnPosition == columLength){
                    node.children = new GameObject[2];
                    node.children[0] = listOfNodes[i - 1];
                    node.children[1] = listOfNodes[i - rowLength];
                }
            }

            //top edges
            if (node.rowPosition == 1) {
                //if its not on the corners
                if (node.columnPosition > 1 &&
                    node.columnPosition < columLength) {

                    node.children = new GameObject[3];

                    node.children[0] = listOfNodes[i - 1];
                    node.children[1] = listOfNodes[i + 1];
                    node.children[2] = listOfNodes[i + rowLength];

                }
            }

            //bottom edges
            if (node.rowPosition == rowLength) {
                //if its not on the corners
                if (node.columnPosition > 1 &&
                    node.columnPosition < columLength) {

                    node.children = new GameObject[3];

                    node.children[0] = listOfNodes[i - 1];
                    node.children[1] = listOfNodes[i + 1];
                    node.children[2] = listOfNodes[i - rowLength];

                }
            }

            //left edges
            if (node.columnPosition == 1) {
                //if its not on the corners
                if (node.rowPosition > 1 &&
                    node.rowPosition < columLength) {

                    node.children = new GameObject[3];

                    node.children[0] = listOfNodes[i + rowLength];
                    node.children[1] = listOfNodes[i + 1];
                    node.children[2] = listOfNodes[i - rowLength];

                }
            }

            //right edges
            if (node.columnPosition == columLength) {
                //if its not on the corners
                if (node.rowPosition > 1 &&
                    node.rowPosition < columLength) {

                    node.children = new GameObject[3];

                    node.children[0] = listOfNodes[i + rowLength];
                    node.children[1] = listOfNodes[i - 1];
                    node.children[2] = listOfNodes[i - rowLength];

                }
            }
                
            if (node.rowPosition > 1 &&
                node.rowPosition < rowLength &&
                node.columnPosition > 1 &&
                node.columnPosition < columLength )  {

                if (probability >= 0.5 && probability <= 1.0f) {
                    node.children = new GameObject[4];

                    node.children[0] = listOfNodes[i - 1];
                    node.children[1] = listOfNodes[i + 1];
                    node.children[2] = listOfNodes[i + rowLength];
                    node.children[3] = listOfNodes[i - rowLength];
                } else if (probability > 0 && probability < 0.5) {

                    node.children = new GameObject[2];
                    int randomNumber = Random.Range(1, 10);

                    if(randomNumber < 5) {
                        node.children[0] = listOfNodes[i - 1];
                        node.children[1] = listOfNodes[i + rowLength];
                    } else {
                        node.children[0] = listOfNodes[i + rowLength];
                        node.children[1] = listOfNodes[i - rowLength];
                    }

                }
            }
        }
    }


    void PrintRandom(string label)
    {
        Debug.Log(string.Format("{0} - RandomValue {1}", label, Random.Range(1, 100)));
    }
}
