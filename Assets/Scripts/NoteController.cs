using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NoteController : MonoBehaviour
{
    Renderer m_Renderer;
    Animator m_Animator;

    void Start()
    {
        m_Renderer = GetComponent<Renderer>();
        m_Animator = GetComponent<Animator>();

    }

    private void Update()
    {
        
        
    }

    private void OnTriggerEnter(Collider other)
    {
        //if (other.gameObject.CompareTag("Hand"))
        {
            // Touched with which hand?
            switch (other.gameObject.name)
            {
                case "LeftHandAnchor":
                    OVRInput.SetControllerVibration(0.2f, 0.2f, OVRInput.Controller.LTouch);
                    break;
                case "RightHandAnchor":
                    OVRInput.SetControllerVibration(0.2f, 0.2f, OVRInput.Controller.RTouch);
                    break;
            }

            switch (gameObject.transform.name)
            {
                case "Tap":
                    m_Animator.SetBool("IsTouched", true); // play touch animation
                    print("You touched a tap note!");
                    break;
                case "Hold":
                    m_Animator.SetBool("IsHeld", true);
                    break;
                case "Swipe":
                    m_Animator.SetBool("IsTouched", true);
                    print("You touched a swipe note!");
                    break;
            }
        }

        StartCoroutine(WaitAfterAnimation());
        
    }

    private void OnTriggerStay(Collider other)
    {
        if (gameObject.transform.name == "Hold")
        {
            
            
            m_Renderer.material.SetColor("_Color", new Color(1, 0, 0, Mathf.Lerp(0, 1, Time.deltaTime * 0.5f)));
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

    IEnumerator WaitAfterAnimation()
    {
        yield return new WaitForSeconds(2f);
        gameObject.SetActive(false);
    }
}
