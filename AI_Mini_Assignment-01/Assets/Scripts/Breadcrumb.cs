using UnityEngine;

public class Breadcrumb : MonoBehaviour {
    public float timeToDestroy;

	void Start () { 
        if(!(timeToDestroy < 0.0f))
            Invoke("DestroyBeadcrumb",timeToDestroy); }
    
    void DestroyBeadcrumb() { Destroy(gameObject); }
}
