using UnityEngine;
using System.Collections;

public class StartAll : MonoBehaviour {

	public GameObject bfs;
	public GameObject dfs;
	public GameObject astar;
	public GameObject dijk;
	public GameObject bestfs;
	public GameObject astarModified;

	public void Enable () {

		bfs.GetComponent<BFSZombie> ().enabled = true;
		dfs.GetComponent<DFSZombie> ().enabled = true;
		astar.GetComponent<AstarZombie> ().enabled = true;
		dijk.GetComponent<DijkstraZombie> ().enabled = true;
		bestfs.GetComponent<BestFSZombie> ().enabled = true;
		astarModified.GetComponent<AStarModifiedZombie> ().enabled = true;
	}
}

//start