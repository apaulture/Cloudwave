using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MotionNoteController : MonoBehaviour
{
    Vector3 direction;
    Rigidbody m_Rigidbody;

    public float speed;

    void Start()
    {
        m_Rigidbody = GetComponent<Rigidbody>();

        direction = Vector3.back;
    }

    void FixedUpdate()
    {
        transform.Translate(direction * Time.fixedDeltaTime * speed);
        // m_Rigidbody.AddForce(direction * speed * Time.fixedDeltaTime);
    }
}
