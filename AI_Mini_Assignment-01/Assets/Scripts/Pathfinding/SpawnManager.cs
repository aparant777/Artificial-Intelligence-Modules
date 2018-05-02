using UnityEngine;
using UnityEngine.Collections;
using System.Collections.Generic;

public class SpawnManager : MonoBehaviour
{

    public GameObject nodePrefab;

    public const int rowLength = 32;
    public const int columLength = 32;

    public float seperationX;
    public float seperationZ;

    public List<GameObject> listOfNodes;
    public List<Node> listOfNodeObjects;

    //public float probability;
    public float randomNumber;

    public int spawnCounter;

    void Start()
    {
        SpawnNodes();
        CalculateChildren();
        //CalculateNewChildren();
        spawnCounter = 0;
    }

    void SpawnNodes()
    {
        for (int i = 1; i <= rowLength; i++)
        {
            for (int j = 1; j <= columLength; j++)
            {
                SpawnNode(i, j);
                spawnCounter++;
            }
        }
    }

    void SpawnNode(int rowNumber, int columnNumber)
    {
        //seperationX = Random.Range(1, 7);
        //seperationZ = Random.Range(3, 7); 

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
        node.gameObject.name = "Cube["+rowNumber+","+columnNumber+"]";
        //} else {
        // previousNode = node;

        // previousNode.GetComponent<Node>().rowPosition = rowNumber;
        // previousNode.GetComponent<Node>().columnPosition = columnNumber;
        //}

        //probability = Random.Range(1,10);
        listOfNodes.Add(node);
        listOfNodeObjects.Add(node.GetComponent<Node>());

    }

    void CalculateChildren()
    {
        for (int i = 0; i < listOfNodes.Count; i++)
        {
            Node node = listOfNodes[i].GetComponent<Node>();

            //top left
            if (node.rowPosition == 1)
            {
                if (node.columnPosition == 1)
                {
                    node.children = new GameObject[2];
                    node.children[0] = listOfNodes[i + 1];
                    node.children[1] = listOfNodes[i + rowLength];
                }
            }

            //top right
            if (node.rowPosition == 1)
            {
                if (node.columnPosition == columLength)
                {
                    node.children = new GameObject[2];
                    node.children[0] = listOfNodes[i - 1];
                    node.children[1] = listOfNodes[i + rowLength];
                }
            }

            //bottom left
            if (node.rowPosition == rowLength)
            {
                if (node.columnPosition == 1)
                {
                    node.children = new GameObject[2];
                    node.children[0] = listOfNodes[i + 1];
                    node.children[1] = listOfNodes[i - rowLength];
                }
            }

            //bottom right
            if (node.rowPosition == rowLength)
            {
                if (node.columnPosition == columLength)
                {
                    node.children = new GameObject[2];
                    node.children[0] = listOfNodes[i - 1];
                    node.children[1] = listOfNodes[i - rowLength];
                }
            }

            //top edges
            if (node.rowPosition == 1)
            {
                //if its not on the corners
                if (node.columnPosition > 1 &&
                    node.columnPosition < columLength)
                {

                    node.children = new GameObject[3];

                    node.children[0] = listOfNodes[i - 1];
                    node.children[1] = listOfNodes[i + 1];
                    node.children[2] = listOfNodes[i + rowLength];

                }
            }

            //bottom edges
            if (node.rowPosition == rowLength)
            {
                //if its not on the corners
                if (node.columnPosition > 1 &&
                    node.columnPosition < columLength)
                {

                    node.children = new GameObject[3];

                    node.children[0] = listOfNodes[i - 1];
                    node.children[1] = listOfNodes[i + 1];
                    node.children[2] = listOfNodes[i - rowLength];

                }
            }

            //left edges
            if (node.columnPosition == 1)
            {
                //if its not on the corners
                if (node.rowPosition > 1 &&
                    node.rowPosition < columLength)
                {

                    node.children = new GameObject[3];

                    node.children[0] = listOfNodes[i + rowLength];
                    node.children[1] = listOfNodes[i + 1];
                    node.children[2] = listOfNodes[i - rowLength];

                }
            }

            //right edges
            if (node.columnPosition == columLength)
            {
                //if its not on the corners
                if (node.rowPosition > 1 &&
                    node.rowPosition < columLength)
                {

                    node.children = new GameObject[3];

                    node.children[0] = listOfNodes[i + rowLength];
                    node.children[1] = listOfNodes[i - 1];
                    node.children[2] = listOfNodes[i - rowLength];

                }
            }

            if (node.rowPosition > 1 &&
                node.rowPosition < rowLength &&
                node.columnPosition > 1 &&
                node.columnPosition < columLength)
            {

                //if (probability >= 0.5 && probability <= 1.0f)
               // {
                    node.children = new GameObject[4];

                    node.children[0] = listOfNodes[i - 1];
                    node.children[1] = listOfNodes[i + 1];
                    node.children[2] = listOfNodes[i + rowLength];
                    node.children[3] = listOfNodes[i - rowLength];
                //} else if (probability > 0 && probability < 0.5)
                //{

                //    node.children = new GameObject[2];
                //    int randomNumber = Random.Range(1, 10);

                //    if (randomNumber < 5)
                //    {
                //        node.children[0] = listOfNodes[i - 1];
                //        node.children[1] = listOfNodes[i + rowLength];
                //    } else
                //    {
                //        node.children[0] = listOfNodes[i + rowLength];
                //        node.children[1] = listOfNodes[i - rowLength];
                //    }

                //}
            }
        }
    }

    void PrintRandom(string label)
    {
        Debug.Log(string.Format("{0} - RandomValue {1}", label, Random.Range(1, 100)));
    }


    public void ResetAllNodes_Astar()
    {
        foreach (GameObject n in listOfNodes)
        {
            n.GetComponent<Node>().gValue = 0.0f;
            n.GetComponent<Node>().hValue = 0.0f;
            n.GetComponent<Node>().fValue = 0.0f;
            n.GetComponent<Node>().goalVisistedAstar = false;
        }
    }

    void CalculateNewChildren()
    {
        for (int i = 0; i < listOfNodes.Count; i++)
        {
            Node node = listOfNodes[i].GetComponent<Node>();

            int randomNumber = Random.Range(1, 10);

            if (randomNumber < 5)
            {
                node.children = new GameObject[1];
                node.children[0] = listOfNodes[i + 1];
            } else
            {
                node.children = new GameObject[2];
                node.children[0] = listOfNodes[i + 1];
                node.children[1] = listOfNodes[i + rowLength];
            }
        }
    }



    void SpawnRandomNodes()
    {
        for (int i = 1; i <= rowLength; i++)
        {
            for (int j = 1; j <= columLength; j++)
            {
                //SpawnNode(i, j);
                spawnCounter++;
            }
        }
    }

    public void ResetAllNodes()
    {
        for(int i = 0; i < listOfNodeObjects.Count; i++)
        {
            listOfNodeObjects[i].ResetNode();
        }
    }
}