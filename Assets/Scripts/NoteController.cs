using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NoteController : MonoBehaviour
{
    Renderer m_Renderer;
    Animator m_Animator;
    Collider m_ParentCollider;

    void Start()
    {
        m_Renderer = GetComponent<Renderer>();
        m_Animator = GetComponent<Animator>();
        m_ParentCollider = GetComponentInParent<Collider>();
    }

    private void Update()
    {
        if (this.gameObject.name == "Swipe")
        {
            m_ParentCollider.enabled = !m_ParentCollider.enabled;
            if (gameObject.activeSelf == false)
            {
                print("fuck you");
                m_ParentCollider.enabled = true;
                m_ParentCollider.enabled = !m_ParentCollider.enabled;
            }
        }
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
                    
                    break;
                case "Hold":
                    m_Animator.SetBool("IsHeld", true);
                    break;
                case "Swipe":
                    
                    
                    m_Animator.SetBool("IsTouched", true);
                    
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
        m_ParentCollider.enabled = !m_ParentCollider.enabled;
        yield return new WaitForSeconds(.3f);
        
        gameObject.SetActive(false);
    }
}
