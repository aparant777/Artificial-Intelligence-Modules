using UnityEngine;
using System.Collections;
using System.Collections.Generic;
public class DecisionSystem : MonoBehaviour {

	int Dijkstra = 0, Astar = 1, Bfs = 2, Dfs = 3, Bestfs = 4;
	float[] ArraySort;
	int[] indexOfTie;
	int[] WinCount;
	int i, j;
	float temp;
	int rank = 5, EqualCount = 0, max0, max1, max2, max3, max4;
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

	void Ranking () {
		//Total Time
		for ( i = 0; i < 5; i++ ) {
			ArraySort[i] = TotalTime[i];
			TotalTimeRank[i] = 0;
		}
		for ( i = 0; i < 5; i++ ) {
			for ( j = 0; j < 4; j++ ) {
				if ( ArraySort[j] > ArraySort[j + 1] ) {
					temp = ArraySort[j + 1];
					ArraySort[j + 1] = ArraySort[j];
					ArraySort[j] = temp;
				}
			}
		}
		rank = 5;
		for ( i = 0; i < 5; i++ ) {
			for ( j = 0; j < 5; j++ ) {
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
		//End of total time

		//TotalNodes
		for ( i = 0; i < 5; i++ ) {
			ArraySort[i] = TotalNodes[i];
			TotalNodesRank[i] = 0;
		}
		for ( i = 0; i < 5; i++ ) {
			for ( j = 0; j < 4; j++ ) {
				if ( ArraySort[j] > ArraySort[j + 1] ) {
					temp = ArraySort[j + 1];
					ArraySort[j + 1] = ArraySort[j];
					ArraySort[j] = temp;

				}
			}
		}
		rank = 5;
		for ( i = 0; i < 5; i++ ) {
			for ( j = 0; j < 5; j++ ) {
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

		//TotalEfficiency
		for ( i = 0; i < 5; i++ ) {
			ArraySort[i] = TotalEfficiency[i];
			TotalEfficiencyRank[i] = 0;
		}
		for ( i = 0; i < 5; i++ ) {
			for ( j = 0; j < 4; j++ ) {
				if ( ArraySort[j] > ArraySort[j + 1] ) {
					temp = ArraySort[j + 1];
					ArraySort[j + 1] = ArraySort[j];
					ArraySort[j] = temp;

				}
			}
		}
		rank = 5;
		for ( i = 0; i < 5; i++ ) {
			for ( j = 0; j < 5; j++ ) {
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

		//Total Distance
		for ( i = 0; i < 5; i++ ) {
			ArraySort[i] = TotalTime[i];
			TotalDistanceRank[i] = 0;
		}
		for ( i = 0; i < 5; i++ ) {
			for ( j = 0; j < 4; j++ ) {
				if ( ArraySort[j] > ArraySort[j + 1] ) {
					temp = ArraySort[j + 1];
					ArraySort[j + 1] = ArraySort[j];
					ArraySort[j] = temp;

				}
			}
		}
		rank = 5;
		for ( i = 0; i < 5; i++ ) {
			for ( j = 0; j < 5; j++ ) {
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

		//TotalNodesExamined
		for ( i = 0; i < 5; i++ ) {
			ArraySort[i] = TotalTime[i];
			TotalNodesExaminedRank[i] = 0;
		}
		for ( i = 0; i < 5; i++ ) {
			for ( j = 0; j < 4; j++ ) {
				if ( ArraySort[j] > ArraySort[j + 1] ) {
					temp = ArraySort[j + 1];
					ArraySort[j + 1] = ArraySort[j];
					ArraySort[j] = temp;

				}
			}
		}
		rank = 5;
		for ( i = 0; i < 5; i++ ) {
			for ( j = 0; j < 5; j++ ) {
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

		// sum of ranks
		for ( i = 0; i < 5; i++ ) {
			TotalAlgorithmRank[i] = TotalTimeRank[i] + TotalNodesRank[i] + (int)(TotalEfficiencyRank[i]) + (int)(TotalDistanceRank[i]) + TotalNodesExaminedRank[i];
		}
		//end of sum

		//sorting sum
		for ( i = 0; i < 5; i++ ) {
			ArraySort[i] = TotalAlgorithmRank[i];
			//TotalTimeRank [i] = 0;
		}
		for ( i = 0; i < 5; i++ ) {
			for ( j = 0; j < 4; j++ ) {
				if ( ArraySort[j] < ArraySort[j + 1] ) {
					temp = ArraySort[j + 1];
					ArraySort[j + 1] = ArraySort[j];
					ArraySort[j] = temp;

				}
			}
		}
		//if two or more same values
		for ( i = 1; i < 5; i++ ) {
			if ( ArraySort[0] == ArraySort[i] ) {
				EqualCount++;
			}
		}
		if ( EqualCount > 0 ) {
			i = 0;
			for ( j = 0; j < 5; j++ ) {
				if ( ArraySort[0] == TotalAlgorithmRank[j] ) {
					indexOfTie[i] = j;
					i++;
				}
			}
			max0 = TotalTimeRank[indexOfTie[0]];
			max1 = TotalNodesRank[indexOfTie[0]];
			max2 = (int)TotalEfficiencyRank[indexOfTie[0]];
			max3 = (int)TotalDistanceRank[indexOfTie[0]];
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
					max2 = (int)TotalEfficiencyRank[indexOfTie[i]];
					WinCount[2] = indexOfTie[i];
				}
				if ( max3 < TotalDistanceRank[indexOfTie[i]] ) {
					max3 = (int)TotalDistanceRank[indexOfTie[i]];
					WinCount[3] = indexOfTie[i];
				}
				if ( max4 < TotalNodesExaminedRank[indexOfTie[i]] ) {
					max4 = TotalNodesExaminedRank[indexOfTie[i]];
					WinCount[4] = indexOfTie[i];
				}
			}
		}

		else {

			rank = 5;
			for ( i = 0; i < 5; i++ ) {
				for ( j = 0; j < 5; j++ ) {
					if ( ArraySort[i] == TotalAlgorithmRank[j] && TotalAlgorithmRankPriority[j] == 0 ) {
						TotalAlgorithmRankPriority[j] = rank;
					}
				}
				rank--;
			}
		}
		// end of sorting sum a
	}
}