using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class AllStars : MonoBehaviour {

	public GameObject mainCamera;

	public GameObject bfsZombie;
	public GameObject astarZombie;
	public GameObject dfsZombie;
	public GameObject bestZombie;
	public GameObject astarModifiedZombie;
	public GameObject dijkstraZombie;


	public Text DisplayAlgorithmBFS;
	public Text DisplayAlgorithmDFS;
	public Text DisplayAlgorithmBESTFS;
	public Text DisplayAlgorithmDIJKSTRA;
	public Text DisplayAlgorithmASTAR;
	public Text DisplayAlgorithmASTARMODIFIED;

	public Text CategoryTime;
	public Text CategoryDistance;
	public Text CategoryNodes;
	public Text CategoryNodesVisited;
	public Text CategoryEfficiency;
	public Text CategoryEfficiencyMemory;
	public Text CategoryExecutionTime;

	public Text bfs;
	public Text dfs;
	public Text bestFs;
	public Text dijk;
	public Text astar;
	public Text modifiedAstar;

	public Text bfsRankTime;
	public Text dfsRankTime;
	public Text bestFsRankTime;
	public Text dijkRankTime;
	public Text astarRankTime;
	public Text astarModifiedRankTime;

	public Text bfsRankDistance;
	public Text dfsRankDistance;
	public Text bestFsRankDistance;
	public Text dijkstraRankDistance;
	public Text astarRankDistance;
	public Text astarModifiedRankDistance;

	public Text bfsRankNodes;
	public Text dfsRankNodes;
	public Text bestFsRankNodes;
	public Text dijkstraRankNodes;
	public Text astarRankNodes;
	public Text astarModifiedRankNodes;

	public Text bfsRankNodesVisited;
	public Text dfsRankNodesVisited;
	public Text bestFsRankNodesVisited;
	public Text dijkstraRankNodesVisited;
	public Text astarRankNodesVisited;
	public Text astarModifiedRankNodesVisited;

	public Text bfsRankEfficiency;
	public Text dfsRankEfficiency;
	public Text bestfsRankEfficiency;
	public Text dijkstraRankEfficiency;
	public Text astarRankEfficiency;
	public Text astarModifiedRankEfficiency;

	public Text bfsExecution;
	public Text dfsExecution;
	public Text bestfsExecution;
	public Text dijkstraExecution;
	public Text astarExecution;
	public Text astarModifiedExecution;

	public Text bfsRankEfficiency1;
	public Text dfsRankEfficiency1;
	public Text bestfsRankEfficiency1;
	public Text dijkstraRankEfficiency1;
	public Text astarRankEfficiency1;
	public Text astarModifiedRankEfficiency1;

	public Text selectedAlgorithm;

	public Image backGroundImage;

	public float bfsDistance;
	public float bfsTime;
	public int bfsNodes;
	public int bfsNodesExamined;
	public float bfsExecutionTime;

	public float astarDistance;
	public float astarTime;
	public int astarNodes;
	public int astarNodesExamined;
	public float astarExecutionTime;

	public float dfsDistance;
	public float dfsTime;
	public int dfsNodes;
	public int dfsNodesExamined;
	public float dfsExecutionTime;

	public float bestDistance;
	public float bestTime;
	public int bestNodes;
	public int bestNodesExamined;
	public float bestExecutionTime;

	public float astarModifiedDistance;
	public float astarModifiedTime;
	public int astarModifiedNodes;
	public int astarModifiedNodesExamined;
	public float astarModifiedExecutionTime;

	public float dijkstraDistance;
	public float dijkstraTime;
	public int dijkstraNodes;
	public int dijkstraNodesExamined;
	public float dijkstraExecutionTime;
	

	int ASTARMODIFIED = 0;
	int ASTAR = 1;
	int BFS = 2;
	int DFS = 3;
	int BESTFS = 4;
	int DIJKSTRA = 5;

	public bool done = false;

	//int Dijkstra = 0, Astar = 1, Bfs = 2, Dfs = 3, Bestfs = 4;

	public Dictionary<int, string> AlgorithmDict = new Dictionary<int, string> ();
	
	float[] ArraySort;
	int[] indexOfTie;
	int[] WinCount;
	int i, j;
	float temp;
	int rank = 6, EqualCount = 0, max0, max1, max2, max3, max4, max5;
	public Dictionary<int, float> TotalTime = new Dictionary<int, float> ();
	public Dictionary<int, int> TotalTimeRank = new Dictionary<int, int> ();

	public Dictionary<int, int> TotalNodes = new Dictionary<int, int> ();
	public Dictionary<int, int> TotalNodesRank = new Dictionary<int, int> ();

	public Dictionary<int, float> TotalEfficiency = new Dictionary<int, float> ();
	public Dictionary<int, float> TotalEfficiencyRank = new Dictionary<int, float> ();

	public Dictionary<int, float> TotalDistance = new Dictionary<int, float> ();
	public Dictionary<int, float> TotalDistanceRank = new Dictionary<int, float> ();

	public Dictionary<int, int> TotalNodesExamined = new Dictionary<int, int> ();
	public Dictionary<int, int> TotalNodesExaminedRank = new Dictionary<int, int> ();

	public Dictionary<int, int> TotalAlgorithmRank = new Dictionary<int, int> ();
	public Dictionary<int, int> TotalAlgorithmRankPriority = new Dictionary<int, int> ();

	public Dictionary<int, float> TotalEfficiencyMemory = new Dictionary<int, float> ();
	public Dictionary<int, float> TotalEfficiencyMemoryRank = new Dictionary<int, float> ();

	void Start () {
		bfs.enabled = false;
		dfs.enabled = false;
		bestFs.enabled = false;
		dijk.enabled = false;
		astar.enabled = false;
		modifiedAstar.enabled = false;
		ArraySort = new float[6];		// array size allocation........IMP IMP IMP Forgetting..
		//indexOfTie = new int [5];
		WinCount = new int[4];
		backGroundImage.enabled = false;


		//setting the text of displayAlgorithm Textboxes..
		DisplayAlgorithmBFS.text = "BFS";
		DisplayAlgorithmDFS.text = "DFS";
		DisplayAlgorithmBESTFS.text = "BESTFS";
		DisplayAlgorithmDIJKSTRA.text = "DIJKSTRA";
		DisplayAlgorithmASTAR.text = "ASTAR";
		DisplayAlgorithmASTARMODIFIED.text = "ASTAR MODIFIED";


		AlgorithmDict[0] = "ASTARMODIFIED";
		AlgorithmDict[1] = "ASTAR";
		AlgorithmDict[2] = "BFS";
		AlgorithmDict[3] = "DFS";
		AlgorithmDict[4] = "BESTFS";
		AlgorithmDict[5] = "DIJKSTRA";



	}
	void Update () {

		if ( mainCamera.GetComponent<Starter> ().bfsReady == true  && 
				mainCamera.GetComponent<Starter>().astarReady == true &&
					mainCamera.GetComponent<Starter>().dfsReady == true && 
						mainCamera.GetComponent<Starter>().bestReady == true && 
							mainCamera.GetComponent<Starter>().astarModifiedReady == true &&
								mainCamera.GetComponent<Starter>().dijkstraReady == true && done == false) {


									backGroundImage.enabled = true;

			CategoryTime.text = "Time";
			CategoryDistance.text = "Distance";
			CategoryNodes.text = "Nodes in path";
			CategoryNodesVisited.text = "Nodes examined";
			CategoryEfficiency.text = "Time Efficiency";
			CategoryEfficiencyMemory.text = "Memory Efficiency";
			CategoryExecutionTime.text = "Time to Execution";

			bfs.enabled = true;
			dfs.enabled = true;
			bestFs.enabled = true;
			dijk.enabled = true;
			astar.enabled = true;
			modifiedAstar.enabled = true;

			bfsTime = bfsZombie.GetComponent<BFSZombie> ().GetBFSTotalDistanceCovered ();
			bfsDistance = bfsZombie.GetComponent<BFSZombie> ().GetBFSTotalTimeCovered ();
			bfsNodes = bfsZombie.GetComponent<BFSZombie> ().GetBFSTotalNodes ();
			bfsNodesExamined = bfsZombie.GetComponent<BFSZombie>().GetBFSTotalNodesExamined();
			bfsExecutionTime = bfsZombie.GetComponent<BFSZombie> ().GetBFSExecutionTime ();
			Debug.Log ( "BFS " + bfsExecutionTime );
			

			bfsRankTime.text = bfsTime.ToString ();
			bfsRankDistance.text = bfsDistance.ToString ();
			bfsRankNodes.text = bfsNodes.ToString ();
			bfsRankNodesVisited.text = bfsNodesExamined.ToString ();
			bfsExecution.text = bfsExecutionTime.ToString ();
		
			

			astarTime = astarZombie.GetComponent<AstarZombie> ().GetAstarTotalDistanceCovered ();
			astarDistance = astarZombie.GetComponent<AstarZombie> ().GetAstarTotalTimeCovered ();
			astarNodes = astarZombie.GetComponent<AstarZombie> ().GetAstarTotalNodes ();
			astarNodesExamined = astarZombie.GetComponent<AstarZombie> ().GetAstarTotalNodesExamined ();
			astarExecutionTime = astarZombie.GetComponent<AstarZombie> ().GetAstarExecutionTime ();
			Debug.Log ( "Astar " + astarExecutionTime );
			

			astarRankTime.text = astarTime.ToString ();
			astarRankDistance.text = astarDistance.ToString ();
			astarRankNodes.text = astarNodes.ToString ();
			astarRankNodesVisited.text = astarNodesExamined.ToString ();
			astarExecution.text = astarExecutionTime.ToString ();
			
			

			dfsTime = dfsZombie.GetComponent<DFSZombie> ().GetDFSTotalDistanceCovered ();
			dfsDistance= dfsZombie.GetComponent<DFSZombie> ().GetDFSTotalTimeCovered ();
			dfsNodes = dfsZombie.GetComponent<DFSZombie> ().GetDFSTotalNodes ();
			dfsNodesExamined = dfsZombie.GetComponent<DFSZombie> ().GetDFSTotalNodesExamined ();
			dfsExecutionTime = dfsZombie.GetComponent<DFSZombie> ().GetDFSExecutionTime ();
			Debug.Log ( "DFS " + dfsExecutionTime );
			
			
			dfsRankTime.text = dfsTime.ToString ();
			dfsRankDistance.text = dfsDistance.ToString ();
			dfsRankNodes.text = dfsNodes.ToString ();
			dfsRankNodesVisited.text = dfsNodesExamined.ToString ();
			dfsExecution.text = dfsExecutionTime.ToString ();

			bestTime = bestZombie.GetComponent<BestFSZombie> ().GetBestFSTotalDistanceCovered ();
			bestDistance  = bestZombie.GetComponent<BestFSZombie> ().GetBestFSTotalTimeCovered ();
			bestNodes = bestZombie.GetComponent<BestFSZombie> ().GetBestFSTotalNodes ();
			bestNodesExamined = bestZombie.GetComponent<BestFSZombie> ().BestFSTotalNodesExamined ();
			bestExecutionTime = bestZombie.GetComponent<BestFSZombie> ().GetBestFSExecutionTime ();
			
			bestFsRankTime.text = bestTime.ToString ();
			bestFsRankDistance.text = bestDistance.ToString ();
			bestFsRankNodes.text = bestNodes.ToString ();
			bestFsRankNodesVisited.text = bestNodesExamined.ToString ();
			bestfsExecution.text = bestExecutionTime.ToString ();

			astarModifiedTime = astarModifiedZombie.GetComponent<AStarModifiedZombie> ().GetAstarModifiedTotalDistanceCovered ();
			astarModifiedDistance = astarModifiedZombie.GetComponent<AStarModifiedZombie> ().GetAstarModifiedTotalTimeCovered ();
			astarModifiedNodes = astarModifiedZombie.GetComponent<AStarModifiedZombie> ().GetAstarModifiedTotalNodes ();
			astarModifiedNodesExamined = astarModifiedZombie.GetComponent<AStarModifiedZombie> ().GetAstarModifiedTotalNodesExamined ();
			astarModifiedExecutionTime = astarModifiedZombie.GetComponent<AStarModifiedZombie> ().GetAstarModifiedExecutionTime ();
			Debug.Log ( "Modified Astar " + astarModifiedExecutionTime );

			astarModifiedRankTime.text = astarModifiedTime.ToString ();
			astarModifiedRankDistance.text = astarModifiedDistance.ToString ();
			astarModifiedRankNodes.text = astarModifiedNodes.ToString ();
			astarModifiedRankNodesVisited.text = astarModifiedNodesExamined.ToString ();
			astarModifiedExecution.text = astarModifiedExecutionTime.ToString ();

			dijkstraTime = dijkstraZombie.GetComponent<DijkstraZombie> ().GetDijkstraTotalDistanceCovered ();
			dijkstraDistance = dijkstraZombie.GetComponent<DijkstraZombie> ().GetDijkstraTotalTimeCovered();
			dijkstraNodes = dijkstraZombie.GetComponent<DijkstraZombie> ().GetDijkstraTotalNodes ();
			dijkstraNodesExamined = dijkstraZombie.GetComponent<DijkstraZombie> ().GetDijkstraTotalNodesExamined ();
			dijkstraExecutionTime = dijkstraZombie.GetComponent<DijkstraZombie> ().GetDijkstraExecutionTime ();
			Debug.Log ( "Dijkstra " + dijkstraExecutionTime );

			dijkRankTime.text = dijkstraTime.ToString ();
			dijkstraRankDistance.text = dijkstraDistance.ToString();
			dijkstraRankNodes.text = dijkstraNodes.ToString();
			dijkstraRankNodesVisited.text = dijkstraNodesExamined.ToString ();
			dijkstraExecution.text = dijkstraExecutionTime.ToString ();

			TotalTime[ASTARMODIFIED] = astarModifiedTime;
			TotalTime[ASTAR] = astarTime;
			TotalTime[BFS] = bfsTime;
			TotalTime[DFS] = dfsTime;
			TotalTime[BESTFS] = bestTime;
			TotalTime[DIJKSTRA] = dijkstraTime;

			TotalNodes[ASTARMODIFIED] = astarModifiedNodes;
			TotalNodes[ASTAR] = astarNodes;
			TotalNodes[BFS] = bfsNodes;
			TotalNodes[DFS] = dfsNodes;
			TotalNodes[BESTFS] = bestNodes;
			TotalNodes[DIJKSTRA] = dijkstraNodes;

			TotalDistance[ASTARMODIFIED] = astarModifiedDistance;
			TotalDistance[ASTAR] = astarDistance;
			TotalDistance[BFS] = bfsDistance;
			TotalDistance[DFS] = dfsDistance;
			TotalDistance[BESTFS] = bestDistance;
			TotalDistance[DIJKSTRA] = dijkstraDistance;

			TotalNodesExamined[ASTARMODIFIED] = astarModifiedNodesExamined;
			TotalNodesExamined[ASTAR] = astarNodesExamined;
			TotalNodesExamined[BFS] = bfsNodesExamined;
			TotalNodesExamined[DFS] = dfsNodesExamined;
			TotalNodesExamined[BESTFS] = bestNodesExamined;
			TotalNodesExamined[DIJKSTRA] = dijkstraNodesExamined;

			TotalEfficiency[ASTARMODIFIED] = Mathf.Pow(5f, 9);
			TotalEfficiency[ASTAR] = Mathf.Pow ( 5f, 9 );
			TotalEfficiency[BFS] = Mathf.Pow ( 5f, 9 );
			TotalEfficiency[DFS] = Mathf.Pow ( 5f, 9 );
			TotalEfficiency[BESTFS] = Mathf.Pow ( 5f, 9 );
			TotalEfficiency[DIJKSTRA] = 161 * Mathf.Log(97f);

			astarRankEfficiency.text = TotalEfficiency[ASTAR].ToString ();
			astarModifiedRankEfficiency.text = TotalEfficiency[ASTARMODIFIED].ToString ();
			bfsRankEfficiency.text = TotalEfficiency[BFS].ToString ();
			dfsRankEfficiency.text = TotalEfficiency[DFS].ToString ();
			bestfsRankEfficiency.text = TotalEfficiency[BESTFS].ToString (); 
			dijkstraRankEfficiency.text = TotalEfficiency[DIJKSTRA].ToString ();

			TotalEfficiencyMemory[ASTARMODIFIED] = Mathf.Pow ( 5f, 8 );
			TotalEfficiencyMemory[ASTAR] = Mathf.Pow ( 5f, 8 );
			TotalEfficiencyMemory[BFS] = Mathf.Pow ( 5f, 8 );
			TotalEfficiencyMemory[DFS] = 5f * 8f;
			TotalEfficiencyMemory[BESTFS] = Mathf.Pow ( 5f, 8 );
			TotalEfficiencyMemory[DIJKSTRA] = 97f * 97f;


			astarRankEfficiency1.text = TotalEfficiencyMemory[ASTAR].ToString ();
			astarModifiedRankEfficiency1.text = TotalEfficiencyMemory[ASTARMODIFIED].ToString ();
			bfsRankEfficiency1.text = TotalEfficiencyMemory[BFS].ToString ();
			dfsRankEfficiency1.text = TotalEfficiencyMemory[DFS].ToString ();
			bestfsRankEfficiency1.text = TotalEfficiencyMemory[BESTFS].ToString ();
			dijkstraRankEfficiency1.text = TotalEfficiencyMemory[DIJKSTRA].ToString ();
			//----------------------------------------------------------------------------------------------------------------------------
			//Total Time
			for ( i = 0; i <= 5; i++ ) {
				ArraySort[i] = TotalTime[i];
				TotalTimeRank[i] = 0;
				TotalAlgorithmRankPriority[i] = 0;
				
			}
			for ( i = 0; i <= 5; i++ ) {
				for ( j = 0; j <= 4; j++ ) {
					if ( ArraySort[j] > ArraySort[j + 1] ) {
						temp = ArraySort[j + 1];
						ArraySort[j + 1] = ArraySort[j];
						ArraySort[j] = temp;
					}
				}
			}

			rank = 6;
			for ( i = 0; i <= 5; i++ ) {
				for ( j = 0; j <= 5; j++ ) {
					if ( ArraySort[i] == TotalTime[j] && TotalTimeRank[j] == 0 ) {
						TotalTimeRank[j] = rank;

					}
					else if ( ArraySort[i] == TotalTime[j] && TotalTimeRank[j] != 0 ) {
						rank++;
						break;
					}
				}
				rank--;
			}

			for ( i = 0; i <= 5; i++ ) {
				//Debug.Log ( "total time is "+TotalTime[i] );
				//Debug.Log ( "rank is "+TotalTimeRank[i] );
			}
			//total time ends
			//----------------------------------------------------------------------------------------------------------------------------
			//TotalNodes
			for ( i = 0; i <= 5; i++ ) {
				ArraySort[i] = TotalNodes[i];
				TotalNodesRank[i] = 0;
			}
			for ( i = 0; i <= 5; i++ ) {
				for ( j = 0; j <= 4; j++ ) {
					if ( ArraySort[j] > ArraySort[j + 1] ) {
						temp = ArraySort[j + 1];
						ArraySort[j + 1] = ArraySort[j];
						ArraySort[j] = temp;

					}
				}
			}

			rank = 6;
			for ( i = 0; i <= 5; i++ ) {
				for ( j = 0; j <= 5; j++ ) {
					if ( ArraySort[i] == TotalNodes[j] && TotalNodesRank[j] == 0 ) {
						TotalNodesRank[j] = rank;

					}
					else if ( ArraySort[i] == TotalNodes[j] && TotalNodesRank[j] != 0 ) {
						rank++;
						break;
					}
				}
				rank--;
			}
			//End of TotalNodes
			//----------------------------------------------------------------------------------------------------------------------------
			//Total Distance
			for ( i = 0; i <= 5; i++ ) {
				ArraySort[i] = TotalTime[i];
				TotalDistanceRank[i] = 0;
			}
			for ( i = 0; i <= 5; i++ ) {
				for ( j = 0; j <= 4; j++ ) {
					if ( ArraySort[j] > ArraySort[j + 1] ) {
						temp = ArraySort[j + 1];
						ArraySort[j + 1] = ArraySort[j];
						ArraySort[j] = temp;

					}
				}
			}

			rank = 6;
			for ( i = 0; i <= 5; i++ ) {
				for ( j = 0; j <= 5; j++ ) {
					if ( ArraySort[i] == TotalDistance[j] && TotalDistanceRank[j] == 0 ) {
						TotalDistanceRank[j] = rank;

					}
					else if ( ArraySort[i] == TotalDistance[j] && TotalDistanceRank[j] != 0 ) {
						rank++;
						break;
					}
				}
				rank--;
			}
			//End of TotalDistance
			//----------------------------------------------------------------------------------------------------------------------------
			//TotalEfficiency
			for ( i = 0; i <= 5; i++ ) {
				ArraySort[i] = TotalEfficiency[i];
				TotalEfficiencyRank[i] = 0;
			}
			for ( i = 0; i <= 5; i++ ) {
				for ( j = 0; j <= 4; j++ ) {
					if ( ArraySort[j] > ArraySort[j + 1] ) {
						temp = ArraySort[j + 1];
						ArraySort[j + 1] = ArraySort[j];
						ArraySort[j] = temp;

					}
				}
			}
			rank = 6;
			for ( i = 0; i <= 5; i++ ) {
				for ( j = 0; j <= 5; j++ ) {
					if ( ArraySort[i] == TotalEfficiency[j] && TotalEfficiencyRank[j] == 0 ) {
						TotalEfficiencyRank[j] = rank;

					}
					else if ( ArraySort[i] == TotalEfficiency[j] && TotalEfficiencyRank[j] != 0 ) {
						rank++;
						break;
					}
				}
				rank--;
			}
			//End of TotalEfficiency

			//TotalNodesExamined
			for ( i = 0; i <= 5; i++ ) {
				ArraySort[i] = TotalTime[i];
				TotalNodesExaminedRank[i] = 0;
			}
			for ( i = 0; i <= 5; i++ ) {
				for ( j = 0; j <= 4; j++ ) {
					if ( ArraySort[j] > ArraySort[j + 1] ) {
						temp = ArraySort[j + 1];
						ArraySort[j + 1] = ArraySort[j];
						ArraySort[j] = temp;

					}
				}
			}
			rank = 6;
			for ( i = 0; i <= 5; i++ ) {
				for ( j = 0; j <= 5; j++ ) {
					if ( ArraySort[i] == TotalNodesExamined[j] && TotalNodesExaminedRank[j] == 0 ) {
						TotalNodesExaminedRank[j] = rank;

					}
					else if ( ArraySort[i] == TotalNodesExamined[j] && TotalNodesExaminedRank[j] != 0 ) {
						rank++;
						break;
					}
				}
				rank--;
			}
			//End of TotalNodesExamined

			// sum of ranks ----------------PRIORITY---------------------
			for ( i = 0; i <= 5; i++ ) {
			//	Debug.Log ( "Nodes at "+i+" is "+TotalNodesRank[i] );
			//	Debug.Log ( "Efficiency at "+i+" is "+TotalEfficiencyRank[i] );
				TotalAlgorithmRank[i] = TotalTimeRank[i] + TotalNodesRank[i] + ( int ) ( TotalEfficiencyRank[i] ) + ( int ) ( TotalDistanceRank[i] ) + TotalNodesExaminedRank[i];
				Debug.Log ( "Rank at "+i+" is "+TotalAlgorithmRank[i] );
			}
			//end of sum

			//sorting sum
			for ( i = 0; i <= 5; i++ ) {
				ArraySort[i] = TotalAlgorithmRank[i];
				//TotalTimeRank [i] = 0;
			}
			for ( i = 0; i <= 5; i++ ) {
				for ( j = 0; j <= 4; j++ ) {
					if ( ArraySort[j] < ArraySort[j + 1] ) {
						temp = ArraySort[j + 1];
						ArraySort[j + 1] = ArraySort[j];
						ArraySort[j] = temp;
					}
				}
			}

			//if two or more same values
			/*for ( i = 1; i <= 5; i++ ) {
				if ( ArraySort[0] == ArraySort[i] ) {
					EqualCount++;
				}
			}

			indexOfTie = new int[EqualCount + 1];
			Debug.Log ( "EqualCount is " + EqualCount );
			if ( EqualCount > 0 ) {
				i = 0;
				for ( j = 0; j <= 5; j++ ) {
					if ( ArraySort[0] == TotalAlgorithmRank[j] ) {
						indexOfTie[i] = j;
						i++;
					}
				}
				max0 = TotalTimeRank[indexOfTie[0]];
				
				max1 = TotalNodesRank[indexOfTie[0]];
			
				max2 = ( int ) TotalEfficiencyRank[indexOfTie[0]];
				
				max3 = ( int ) TotalDistanceRank[indexOfTie[0]];
				
				max4 = TotalNodesExaminedRank[indexOfTie[0]];
			
				for ( i = 0; i < EqualCount; i++ ) {
					if ( max0 < TotalTimeRank[indexOfTie[i]] ) {
						max0 = TotalTimeRank[indexOfTie[i]];
						WinCount[0] = indexOfTie[i];
					}
					if ( max1 < TotalNodesRank[indexOfTie[i]] ) {
						max1 = TotalNodesRank[indexOfTie[i]];
						WinCount[1] = indexOfTie[i];
					}
					if ( max2 < TotalEfficiencyRank[indexOfTie[i]] ) {
						max2 = ( int ) TotalEfficiencyRank[indexOfTie[i]];
						WinCount[2] = indexOfTie[i];
					}
					if ( max3 < TotalDistanceRank[indexOfTie[i]] ) {
						max3 = ( int ) TotalDistanceRank[indexOfTie[i]];
						WinCount[3] = indexOfTie[i];
					}
					if ( max4 < TotalNodesExaminedRank[indexOfTie[i]] ) {
						max4 = TotalNodesExaminedRank[indexOfTie[i]];
						WinCount[4] = indexOfTie[i];
					}
				}
				for(i = 0 ; i < EqualCount ; i++ ){
					Debug.Log ( AlgorithmDict[ WinCount[i]]+"  "+WinCount[i] );
				}
				
			}

			else { */

				rank = 6;
				for ( i = 0; i < 6; i++ ) {
					for ( j = 0; j < 6; j++ ) {
						//Debug.Log ( "ArraySort[" + i + "] is " + ArraySort[i] );
						if ( ArraySort[i] == TotalAlgorithmRank[j] && TotalAlgorithmRankPriority[j] == 0 ) {
							//Debug.Log ( "TotalAlgorithmRank[" + j + "] is " + TotalAlgorithmRank[j] );
							TotalAlgorithmRankPriority[j] = rank;
						}
					}
					rank--;
				}

				for ( i = 0; i < 6; i++ ) {
					if ( TotalAlgorithmRankPriority[i] == 6 ) {

						
						Debug.Log ( "Best algorithm is"+AlgorithmDict[i]+" "+i+" ");
						selectedAlgorithm.text = "Algorithm suitable for this path is "+AlgorithmDict[i];
					}
				}
				/*for ( i = 0; i < 6; i++ ) { 
					
					//Debug.Log ( "TotalAlgorithmRankPriority[" + i + "] is " +TotalAlgorithmRank[i]+"="+ TotalAlgorithmRankPriority[i] ); 
				}
			
				 */
			//999}
			done = true;			
		}//end of if condition
	}//end of Update method
}//end main