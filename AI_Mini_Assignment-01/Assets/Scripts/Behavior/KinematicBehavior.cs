using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KinematicBehavior : MonoBehaviour {

    private Kinematic char_kinematic;
    private KinematicSteering ks;
    private DynoSteering ds;
    private KinematicSteeringOutput kso;
    private KinematicSeek seek;
    private KinematicArrive arrive;

    private KinematicSteering seeking_output;   //this chut only contains position and orientation
    private Vector3 new_velocity;   

    // Use this for initialization
    void Start () {
        char_kinematic = GetComponent<Kinematic>();
        seek = GetComponent<KinematicSeek>();
        arrive = GetComponent<KinematicArrive>();
    }
	


	void Update () {
        ks = new KinematicSteering();
        ds = new DynoSteering();

        //keep checking we reached the goal or not...
        seeking_output = arrive.getSteering();

        //based on distance between the boid and the goal, vary the velocity
        char_kinematic.setVelocity(seeking_output.velc);

        //set the orientation of the boid based on its velocity
        float new_orient = char_kinematic.getNewOrientation(seeking_output.velc);
        char_kinematic.setOrientation(new_orient);
        char_kinematic.setRotation(0f);

        // Update Kinematic Steering
        kso = char_kinematic.updateSteering(ds, Time.deltaTime);
        
        transform.position = new Vector3(kso.position.x, transform.position.y, kso.position.z);
        transform.rotation = Quaternion.Euler(0f, kso.orientation * Mathf.Rad2Deg, 0f);
    }

    private void kinematicSeekBehavior()
    {
        ds = new DynoSteering();

        // Decide on behavior
        seeking_output = seek.getSteering();
        char_kinematic.setVelocity(seeking_output.velc);
        // Manually set orientation for now
        float new_orient = char_kinematic.getNewOrientation(seeking_output.velc);
        char_kinematic.setOrientation(new_orient);
        char_kinematic.setRotation(0f);

        // Update Kinematic Steering
        kso = char_kinematic.updateSteering(ds, Time.deltaTime);

        transform.position = new Vector3(kso.position.x, transform.position.y, kso.position.z);
        transform.rotation = Quaternion.Euler(0f, kso.orientation * Mathf.Rad2Deg, 0f);
    }
}
