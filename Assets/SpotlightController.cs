using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpotlightController : MonoBehaviour
{
    Animator m_Animator;

    // Start is called before the first frame update
    void Start()
    {
        m_Animator = GetComponent<Animator>();
        int randomSway = Random.Range(0, 4); // four types of sway?
        m_Animator.SetInteger("Random", randomSway);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
