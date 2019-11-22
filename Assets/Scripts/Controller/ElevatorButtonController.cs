using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ElevatorButtonController : MonoBehaviour
{
    Material m_Material;
    AudioSource audioSource;
    public GameObject controller;
    AudioSource otherAudioSource;
    public Collider playerCollider;
    float playTime;
    bool buttonTouched;

    void Start()
    {
        m_Material = GetComponent<Renderer>().material;
        audioSource = GetComponent<AudioSource>();
        otherAudioSource = controller.GetComponent<AudioSource>();
    }

    private void Update()
    {
        if (buttonTouched)
        {
            playTime += Time.deltaTime;
        }

        if (playTime > 102)
        {
            audioSource.volume -= Time.deltaTime * 0.3f;
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        // Without headset
        if (other.name == "VirtualHand")
        {
            m_Material.SetColor("_Color", new Color(0, 255, 0, 0.78f));
            audioSource.PlayDelayed(0.4f);
            playerCollider.enabled = false;
            ElevatorMotionController.isActivated = true;
        }

        if (other.gameObject.name == "LeftHandAnchor" || other.gameObject.name == "RightHandAnchor")
        {
            buttonTouched = true;
            ElevatorMotionController.isActivated = true;
            m_Material.SetColor("_Color", new Color(0, 255, 0, 0.78f));
            playerCollider.enabled = false;
            otherAudioSource.Stop();
            audioSource.PlayDelayed(0.4f);
            GetComponent<Collider>().enabled = false;
        }
    }
}
