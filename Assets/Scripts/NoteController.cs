using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NoteController : MonoBehaviour
{
    public float vibrationTime;

    Animator m_Animator;
    ScoreManager scoreManager;

    void Start()
    {
        m_Animator = GetComponent<Animator>();
        scoreManager = GameObject.Find("ScoreManager").GetComponent<ScoreManager>();

        StartCoroutine(SetInactiveAfterMissing());
    }

    private void OnTriggerEnter(Collider other)
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

        // Behavior of note after touched
        switch (gameObject.tag)
        {
            case "Tap":
                m_Animator.SetBool("IsTouched", true); // play touch animation
                StartCoroutine(SetInactiveAfterTouching());
                break;
            case "Arrow":
                m_Animator.SetBool("IsTouched", true); // play touch animation

                break;
            case "Hold":
                m_Animator.SetBool("IsHeld", true);
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

    IEnumerator SetInactiveAfterMissing()
    {
        yield return new WaitForSeconds(2.33f); // set this time to after the note spawn and missed animation has played
        gameObject.SetActive(false);
    }

    IEnumerator SetInactiveAfterTouching()
    {
        // yield return new WaitForSeconds(vibrationTime); // How long to vibrate?
        // OVRInput.SetControllerVibration(0, 0, OVRInput.Controller.LTouch);
        yield return new WaitForSeconds(0.5f);

        gameObject.SetActive(false);
    }

    IEnumerator VibrationTime()
    {
        yield return new WaitForSeconds(vibrationTime);
    }
}
