using System.Collections;
using System.Collections.Generic;
using UnityEngine;



public class OpacityAdjuster : MonoBehaviour
{
    float m_Opacity;
    float t;
    Renderer m_Renderer;

    // Start is called before the first frame update
    void Start()
    {
        m_Renderer = GetComponent<Renderer>();
        m_Renderer.material.color = new Color(1,1,1,0.5f);
        m_Opacity = 0.5f;
    }

    // Update is called once per frame
    void Update()
    {
    }
}
