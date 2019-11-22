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
    float currentVelocity;


    void Start()
    {
        m_Rigidbody = GetComponent<Rigidbody>();
    }

    void FixedUpdate()
    {
        
        velocity = m_Rigidbody.velocity.magnitude;
        print(TriggerSun.titleTriggered);
        if (isActivated & stopGoingUp)
        {
            m_Rigidbody.velocity = new Vector3(0, (1 + timeAcceleration) * upSpeed, 0);
            timeAcceleration += Time.fixedDeltaTime;
            currentVelocity = (1 + timeAcceleration) * upSpeed;
        }

        if (TriggerSun.titleTriggered)
        {
            
            stopGoingUp = false;
            
            timeDececeleration += Time.fixedDeltaTime;
            if (velocity > 0 && timeDececeleration < 9.39f)
            {
                m_Rigidbody.AddForce(new Vector3(0, -1, 0));
            }
            

            /*
             * timeDececeleration += Time.fixedDeltaTime;
            if (velocity > 0 && timeDececeleration < 9.39f)
            {
                m_Rigidbody.velocity = new Vector3(0,currentVelocity - 1,0);
            }
            */
            
        }
    }
}
