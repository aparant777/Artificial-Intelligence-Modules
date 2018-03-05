using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnBreadcrumbs : MonoBehaviour {

    public GameObject breadcrumb;
    public float timeToSpawnFirst;
    public float rateOfSpawn;

	void Start () {
        InvokeRepeating("Spawn_Breadcrumb", timeToSpawnFirst, rateOfSpawn);
	}

    void Spawn_Breadcrumb(){
        Instantiate(breadcrumb, gameObject.transform.position, Quaternion.identity);
    }
}
