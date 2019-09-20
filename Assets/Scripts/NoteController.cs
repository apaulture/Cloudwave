using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NoteController : MonoBehaviour
{
    Renderer m_Renderer;
    Material m_Material;
    AudioSource m_AudioSource;
    Animator m_Animator;

    void Start()
    {
        m_Renderer = GetComponent<Renderer>();
        m_Material = m_Renderer.material;
        m_AudioSource = GetComponent<AudioSource>();
        m_Animator = GetComponent<Animator>();
    }

    private void OnTriggerEnter(Collider other)
    {
        m_Animator.SetBool("IsTouched", true);


        if (other.gameObject.CompareTag("Hand"))
        {
            PlayNote();

            // Touched with which hand?
            switch (other.gameObject.name)
            {
                case "LeftHandAnchor":
                    OVRInput.SetControllerVibration(0.5f, 1f, OVRInput.Controller.LTouch);
                    break;
                case "RightHandAnchor":
                    OVRInput.SetControllerVibration(1f, 1f, OVRInput.Controller.RTouch);
                    break;
            }
        }
    }

    void PlayNote()
    {
        m_AudioSource.Play();
    }
}
