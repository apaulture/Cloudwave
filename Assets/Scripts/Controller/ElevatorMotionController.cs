using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ElevatorMotionController : MonoBehaviour
{
    Rigidbody m_Rigidbody;
    public float upSpeed;
    public static bool isActivated;

    float timeAcceleration;
    
    // Start is called before the first frame update
    void Start()
    {
        m_Rigidbody = GetComponent<Rigidbody>();
        
        // m_Rigidbody.velocity += new Vector3(0,1,0);
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        if (isActivated)
        {
            m_Rigidbody.velocity = new Vector3(0, (1 + timeAcceleration) * upSpeed, 0);
            timeAcceleration += Time.deltaTime;
            
        }
    }
}
