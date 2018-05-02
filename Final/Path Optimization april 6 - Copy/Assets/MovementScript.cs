using UnityEngine;
using System.Collections;

public class MovementScript : MonoBehaviour {

	Vector3 point;
	public GameObject dfsZombie;
	public GameObject bfsZombie;
	public GameObject astarModifiedZombie;
	public GameObject bestfsZombie;
	public GameObject dijkstraZombie;

	void Start () {
		dfsZombie = GameObject.FindGameObjectWithTag ( "DFSZombie" );
		bfsZombie = GameObject.FindGameObjectWithTag ( "BFSZombie" );
		astarModifiedZombie = GameObject.FindGameObjectWithTag ( "AModifiedZombie" );
		bestfsZombie = GameObject.FindGameObjectWithTag ( "BestFSZombie" );
		dijkstraZombie = GameObject.FindGameObjectWithTag ( "DijkZombie" );
	}
	void OnMouseDrag () {
		point = Camera.main.ScreenToWorldPoint ( Input.mousePosition );
		point.y = transform.position.y;
		transform.position = point;
		dfsZombie.transform.position = point + new Vector3(435f,0f,-155f);
		bfsZombie.transform.position = point + new Vector3 ( 435f, 0f, 3f );
		astarModifiedZombie.transform.position = point + new Vector3 ( 230f, 0f, 1f );
		bestfsZombie.transform.position = point + new Vector3 ( 230f, 0f, -155f );
		dijkstraZombie.transform.position = point + new Vector3 ( 0f, 0f, -155f );
	}
}
