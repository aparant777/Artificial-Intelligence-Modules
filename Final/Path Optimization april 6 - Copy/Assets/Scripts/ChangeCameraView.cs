using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using UnityEngine.EventSystems;

public class ChangeCameraView : MonoBehaviour {

	public Camera camera;
	public Camera secondaryCamera;

	public Text labelAstar;
	public Text labelAstarModifeid;
	public Text labelBfs;
	public Text labelDfs;
	public Text labelBestfs;
	public Text labelDijkstra;

	void Start () {
		camera.enabled = true;
		secondaryCamera.enabled = false;
		labelAstar.enabled = false;
		labelAstarModifeid.enabled = false;
		labelBestfs.enabled = false;
		labelBfs.enabled = false;
		labelDfs.enabled = false;
		labelDijkstra.enabled = false;
	}


	public void ChangeToAll () {
		secondaryCamera.enabled = true;
		camera.enabled = false;

		labelAstar.enabled = true;
		labelAstarModifeid.enabled = true;
		labelBestfs.enabled = true;
		labelBfs.enabled = true;
		labelDfs.enabled = true;
		labelDijkstra.enabled = true;
		
	}

	public void ChangeToOne () {

		camera.enabled = true;
		secondaryCamera.enabled = false;

		labelAstar.enabled = false;
		labelAstarModifeid.enabled = false;
		labelBestfs.enabled = false;
		labelBfs.enabled = false;
		labelDfs.enabled = false;
		labelDijkstra.enabled = false;
	}
}
