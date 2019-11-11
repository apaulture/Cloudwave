using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class StartController2 : MonoBehaviour
{
    public GameObject audioController;
    public GameObject audioDelay;
    public GameObject gameBoundary;
    public GameObject boundaryLight;
    Animator m_Animator;
    
    void Start()
    {
        m_Animator = GetComponent<Animator>();
        m_Animator.SetBool("IsStartButton", true);
    }

    private void OnTriggerEnter(Collider other)
    {
        // Start haptic feedback when touching
        switch (other.gameObject.name)
        {
            case "LeftHandAnchor":
                OVRInput.SetControllerVibration(0.2f, 0.2f, OVRInput.Controller.LTouch);
                break;
            case "RightHandAnchor":
                OVRInput.SetControllerVibration(0.2f, 0.2f, OVRInput.Controller.RTouch);
                break;
        }

        // Start music
        audioController.SetActive(true);
        audioDelay.SetActive(true);

        // Activate dance ring and aura
        boundaryLight.SetActive(true);
        gameBoundary.GetComponent<Renderer>().material.SetColor("_EmissionColor", new Color(0.1854097f, 0.5566038f, 0.1759078f));

        // Start button touched animation
        m_Animator.SetBool("IsTouched", true);
        StartCoroutine(SetInactiveAfterTouching());
    }

    private void OnTriggerExit(Collider other)
    {
        // End haptic feedback after touching
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

    IEnumerator SetInactiveAfterTouching()
    {
        yield return new WaitForSeconds(0.3f);
        gameObject.SetActive(false);
    }
}
