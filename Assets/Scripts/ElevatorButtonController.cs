using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ElevatorButtonController : MonoBehaviour
{
    Material m_Material;
    AudioSource audioSource;
    public GameObject controller;
    AudioSource otherAudioSource;


    // Start is called before the first frame update
    void Start()
    {
        m_Material = GetComponent<Renderer>().material;
        m_Material.SetColor("_Color", new Color(255, 0, 0, 0.78f));
        audioSource = GetComponent<AudioSource>();
        otherAudioSource = controller.GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter(Collider other)
    {
        // Without headset
        if (other.name == "VirtualHand")
        {
            m_Material.SetColor("_Color", new Color(0, 255, 0, 0.78f));
            audioSource.Play();
            Up.isActivated = true;
        }

        // For VR testing
        switch (other.gameObject.name)
        {
            case "LeftHandAnchor":
                Up.isActivated = true;
                m_Material.SetColor("_Color", new Color(0, 255, 0, 0.78f));

                otherAudioSource.Stop();
                audioSource.Play();
                
                OVRInput.SetControllerVibration(0.2f, 0.2f, OVRInput.Controller.LTouch);
                break;
            case "RightHandAnchor":
                Up.isActivated = true;
                m_Material.SetColor("_Color", new Color(0, 255, 0, 0.78f));

                otherAudioSource.Stop();
                audioSource.Play();
                
                OVRInput.SetControllerVibration(0.2f, 0.2f, OVRInput.Controller.RTouch);
                break;
        }
        
    }

    private void OnTriggerExit(Collider other)
    {
        switch (other.gameObject.name)
        {
            case "LeftHandAnchor":
                OVRInput.SetControllerVibration(0, 0, OVRInput.Controller.LTouch);
                break;
            case "RightHandAnchor":
                OVRInput.SetControllerVibration(0, 0, OVRInput.Controller.RTouch);
                break;
        }
    }
}
