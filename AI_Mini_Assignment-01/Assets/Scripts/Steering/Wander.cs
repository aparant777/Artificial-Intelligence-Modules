using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Wander : MonoBehaviour {

    public Vector3 targetPosition;
    public Transform targetTransform;

    public float movementSpeed;
    public float rotationSpeed;
    public float minX, maxX, minZ, maxZ;

    public Quaternion targetRotation;
    public bool hasBoidCollided = false;

   // public Rigidbody rigidbody;
    public Vector3 previousVelocity;

    void Start() {

        minX = -45.0f;
        maxX = 45.0f;

        minZ = -45.0f;
        maxZ = 45.0f;

        //Vector3 differentialPosition = transform.position - GetNextPosition();
        //differentialPosition.Normalize();

        //rigidbody.velocity = differentialPosition * movementSpeed * Time.deltaTime;
        //previousVelocity = Vector3.forward;       

    }
   
   
  

    void Update(){
        if (Vector3.Distance(targetPosition, transform.position) <= 5.0f){
           // GetNextPosition();
        }


        targetRotation = Quaternion.LookRotation(targetPosition - transform.position);
        transform.rotation = Quaternion.Slerp(transform.rotation, targetRotation, rotationSpeed * Time.deltaTime);

        transform.Translate(new Vector3(0,0,movementSpeed * Time.deltaTime));
    }

    /*

    void OnCollisionEnter(Collision collision) {
   
        hasBoidCollided = true;
        Vector3 normal = collision.contacts[0].normal;
        Vector3 velocity = gameObject.transform.forward;

        //targetRotation = Quaternion.AngleAxis(180, collision.contacts[0].normal);
        //targetRotation = Quaternion.Euler();
        transform.rotation = Quaternion.Euler(new Vector3(0, 45, 0));

        Debug.Log(targetRotation);

        //targetRotation =  Quaternion.LookRotation(Vector3.Reflect(collision.gameObject.transform.position, collision.contacts[0].normal));
    }
    */

    Vector3 GetNextPosition(){
        targetPosition = new Vector3(Random.Range(minX,maxX), gameObject.transform.position.y, Random.Range(minZ,maxZ));
        return targetPosition;
    }
}