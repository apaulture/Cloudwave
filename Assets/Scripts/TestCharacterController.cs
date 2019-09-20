using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// For basic game testing without a VR headset

public class TestCharacterController : MonoBehaviour
{
    Rigidbody m_Rigidbody;

    public float velocity;

    void Start()
    {
        m_Rigidbody = GetComponent<Rigidbody>();
    }

    private void FixedUpdate()
    {
        float m_Horizontal = Input.GetAxis("Horizontal");
        float m_Vertical = Input.GetAxis("Vertical");

        Vector3 m_Movement = new Vector3(m_Horizontal, 0f, m_Vertical);

        m_Rigidbody.AddForce(m_Movement * velocity);
    }
}
