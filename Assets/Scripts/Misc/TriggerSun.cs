using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// Sunrise when the player/elevator touches this zone

public class TriggerSun : MonoBehaviour
{
    public GameObject sun;
    public Animator m_Animator;
    
    void Start()
    {
        m_Animator = sun.GetComponent<Animator>();
    }

    private void OnTriggerEnter(Collider other)
    {
        m_Animator.SetBool("SunUp", true);
    }
}
