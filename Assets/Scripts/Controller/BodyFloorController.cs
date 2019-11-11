using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BodyFloorController : MonoBehaviour
{
    Renderer m_Renderer;
    public Color32 leftColor;
    public Color32 rightColor;
    
    void Start()
    {
        m_Renderer = GetComponent<Renderer>();
    }

    private void OnTriggerEnter(Collider other)
    {
        if (gameObject.name == "Left")
        {
            m_Renderer.material.SetColor("_EmissionColor", leftColor);
        }

        if (gameObject.name == "Right")
            m_Renderer.material.SetColor("_EmissionColor", rightColor);
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            m_Renderer.material.SetColor("_EmissionColor", Color.black);
        }
        
    }
}
