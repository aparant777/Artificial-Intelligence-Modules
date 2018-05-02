using UnityEngine;
using System.Collections;

public class DisableAll : MonoBehaviour {

	public GameObject bfs;
	public GameObject dfs;
	public GameObject astar;
	public GameObject dijk;
	public GameObject bestfs;
	public GameObject astarModified;

	public void Disable () {
		bfs.GetComponent<BFSZombie> ().enabled = false;
		dfs.GetComponent<DFSZombie> ().enabled = false;
		astar.GetComponent<AstarZombie> ().enabled = false;
		dijk.GetComponent<DijkstraZombie> ().enabled = false;
		bestfs.GetComponent<BestFSZombie> ().enabled = false;
		astarModified.GetComponent<AStarModifiedZombie> ().enabled = true;
	}
}
//disable