using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ElevatorMotionController : MonoBehaviour
{
    Rigidbody m_Rigidbody;
    public float upSpeed;
    public static bool isActivated;

    bool stopGoingUp = true;
    float velocity;
    float timeAcceleration;
    float timeDececeleration;
    
    void Start()
    {
        m_Rigidbody = GetComponent<Rigidbody>();
    }

    void FixedUpdate()
    {
        velocity = m_Rigidbody.velocity.magnitude;
        if (isActivated & stopGoingUp)
        {
            m_Rigidbody.velocity = new Vector3(0, (1 + timeAcceleration) * upSpeed, 0);
            timeAcceleration += Time.deltaTime;
            
        }

        if (TriggerSun.titleTriggered)
        {
            stopGoingUp = false;

            timeDececeleration += Time.deltaTime;
            if (velocity > 0 && timeDececeleration < 9.39f)
            {
                m_Rigidbody.AddForce(new Vector3(0, -1, 0));
            }
            
            
        }
    }
}
