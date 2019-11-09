using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MotionNoteController : MonoBehaviour
{
    Vector3 direction;
    Rigidbody m_Rigidbody;
    Animator m_Animator;

    public float speed;

    void Start()
    {
        m_Animator = GetComponent<Animator>();
        m_Rigidbody = GetComponent<Rigidbody>();

        direction = Vector3.back;

        if (speed > 0)
        {
            m_Animator.SetBool("IsSpeakerNote", true);
        }
        else if (speed == 0)
        {
            m_Animator.SetBool("IsSpeakerNote", false);
        }
    }

    void FixedUpdate()
    {
        transform.Translate(direction * Time.fixedDeltaTime * speed);
        // m_Rigidbody.AddForce(direction * speed * Time.fixedDeltaTime);
    }
}
