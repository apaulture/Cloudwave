using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ElevatorButtonController : MonoBehaviour
{
    Material m_Material;
    AudioSource audioSource;
    public GameObject controller;
    AudioSource otherAudioSource;

    void Start()
    {
        m_Material = GetComponent<Renderer>().material;
        audioSource = GetComponent<AudioSource>();
        otherAudioSource = controller.GetComponent<AudioSource>();
    }
    private void OnTriggerEnter(Collider other)
    {
        // Without headset
        if (other.name == "VirtualHand")
        {
            m_Material.SetColor("_Color", new Color(0, 255, 0, 0.78f));
            audioSource.Play();
            ElevatorMotionController.isActivated = true;
        }

        if (other.gameObject.name == "LeftHandAnchor" || other.gameObject.name == "RightHandAnchor")
        {
            ElevatorMotionController.isActivated = true;
            m_Material.SetColor("_Color", new Color(0, 255, 0, 0.78f));

            otherAudioSource.Stop();
            audioSource.Play();
        }
    }
}
