using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SteeringBehavior_Wandering : MonoBehaviour {

    #region Attributes
    // Wander circle radius
    [Tooltip("Radius of wander circle in front of character")]
    [SerializeField]
    private float m_WanderRadius = 5;

    // Wander distance
    [Tooltip("Distane between character and wander circle")]
    [SerializeField]
    private float m_WanderDistance = 5;

    // Wander angle
    //private float   m_WanderAngle           = 0;
    // Wander distance
    [Tooltip("Speed of the boid")]
    [SerializeField]
    private float m_MaxSpeed = 5;

    // Wander angle change
    //[Tooltip("Angle variation for wander")]
    //[SerializeField]
    //private float   m_WanderAngleChange     = 1;

    // Random point frequency
    [Tooltip("Frequency in seconds to generate a new random point")]
    [SerializeField]
    private float m_RandomPointFrequency = 1;

    // Timer
    private float m_Timer = 0;

    // Random point
    private Vector3 m_RandomPoint = Vector3.zero;

    // Wander circle position
    private Vector3 m_WanderCirclePosition = Vector3.zero;

    // Wander offset
    //private Vector3 m_WanderOffset          = Vector3.zero;

    // Desired velocity
    private Vector3 m_DesiredVelocity = Vector3.zero;

    private bool wanderBehaviorEnabled = true;
    private Vector3 CurrentSafePoint = Vector3.zero;


    #endregion

    public  void PerformSteeringBehavior()
    {


        m_WanderCirclePosition = transform.position + transform.forward * m_WanderDistance;


        Vector3 lookAtGoal = new Vector3(m_RandomPoint.x,
                                           transform.position.y,
                                           m_RandomPoint.z);
        Vector3 direction = lookAtGoal - transform.position;

        transform.rotation = Quaternion.Slerp(this.transform.rotation,
                                              Quaternion.LookRotation(direction),
                                              Time.deltaTime * 1.0f);


        transform.Translate(0,0, m_MaxSpeed * Time.deltaTime);

        // Update timer

        UpdateTimer();

    }

    private void Update()
    {
        if (wanderBehaviorEnabled)
            PerformSteeringBehavior();
        else
           MoveToSafeLocation(CurrentSafePoint);


    }

    private void UpdateTimer()
    {
        m_Timer += Time.deltaTime;
        if (m_Timer > m_RandomPointFrequency)
        { 
            m_RandomPoint = Random.insideUnitCircle * m_WanderRadius;
            m_RandomPoint.z = m_RandomPoint.y;
            m_RandomPoint.y = 0;
            m_RandomPoint += m_WanderCirclePosition;
            m_Timer = 0;

        }
    }

    public void ToggleWanderBehavior(Vector3 location = default(Vector3))
    {
        wanderBehaviorEnabled = false;
        CurrentSafePoint = location;
    }

    public void MoveToSafeLocation(Vector3 location)
    {

        Vector3 lookAtGoal = new Vector3(location.x,
                                          transform.position.y,
                                          location.z);
        Vector3 direction = lookAtGoal - transform.position;

        transform.rotation = Quaternion.Slerp(this.transform.rotation,
                                              Quaternion.LookRotation(direction),
                                              Time.deltaTime * 1.0f);
        transform.Translate(0, 0, m_MaxSpeed * 0.5f * Time.deltaTime);

        if ((transform.position - location).magnitude < 3.0f)
            wanderBehaviorEnabled = true;
    }
}
