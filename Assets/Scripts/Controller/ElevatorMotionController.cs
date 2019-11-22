using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ElevatorMotionController : MonoBehaviour
{
    public float upSpeed;
    public static bool isActivated;

    bool stopGoingUp = true;
    Vector3 velocity = new Vector3(0f, 0f, 0f);
    float timeAcceleration;
    float timeDececeleration;
    float currentVelocity;

    bool isAccelerating = true;
    bool isDecelerating = false;


    void Start()
    {

    }

    void Update()
    {
        transform.Translate(velocity * Time.deltaTime);

        if (isActivated)
        {
            if(isAccelerating)
            {
                velocity.y += upSpeed * Time.deltaTime;
                if(velocity.y >= 5.4f)
                {
                    velocity.y = 5.4f;
                    isAccelerating = false;
                }
            }
            else if(isDecelerating)
            {
                velocity.y -= 0.32f * Time.deltaTime;
                if (velocity.y <= 0f)
                {
                    velocity.y = 0f;
                    isDecelerating = false;
                }
            }
        }


        if (TriggerSun.titleTriggered)
        {
            isDecelerating = true;
        }
    }
}

/*
 * 
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
            
            
        }
    }
*/