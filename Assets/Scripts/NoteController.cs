using System.Collections;
using System.Collections.Generic;
using UnityEngine;
//using UnityEngine.SceneManagement;

public class NoteController : MonoBehaviour
{
    Renderer m_Renderer;
    Animator m_Animator;

    void Start()
    {
        
        
        m_Renderer = GetComponent<Renderer>();
        m_Animator = GetComponent<Animator>();
    }

    private void OnTriggerEnter(Collider other)
    {
        //if (other.gameObject.CompareTag("Hand"))
        //{
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

            switch (gameObject.tag)
            {
                case "Note":
                    m_Animator.SetBool("IsTouched", true); // play touch animation
                    //StartCoroutine(Wait());
                    //SceneManager.LoadScene("Paul");
                    break;
                case "Arrow":
                    m_Animator.SetBool("IsTouched", true); // play touch animation
                    break;
                case "Hold":
                    m_Animator.SetBool("IsHeld", true);
                    break;
            }
        //}

        StartCoroutine(WaitAfterAnimation());

        

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
        yield return new WaitForSeconds(.3f);
        
        //gameObject.SetActive(false);
    }

   // IEnumerator Wait()
    //{
        //yield return new WaitForSeconds(2);
    //}
}
