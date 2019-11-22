using System.Collections;
using System;
using System.Collections.Generic;
using UnityEngine;

public class DistanceController : MonoBehaviour
{
    public GameObject player;

    Renderer m_Renderer;
    float distanceFromPlayer;

    // Start is called before the first frame update
    void Start()
    {
        m_Renderer = GetComponent<Renderer>();
        
    }

    // Update is called once per frame
    void Update()
    {
        distanceFromPlayer = Vector3.Distance(player.transform.position, transform.position);

        // 1.5 to 3.29, 1.5 opacity = 1, 3.29 = barely visible
        m_Renderer.material.color = new Color(1, 1, 1, 1.5f/distanceFromPlayer);
    }
}
