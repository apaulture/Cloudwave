using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NoteController : MonoBehaviour
{
    public float vibrationTime;
    public AudioClip tapSound;
    public AudioClip swipeSound;
    public AudioClip holdSound;
    public ParticleSystem heldParticle;
    float holdNoteTime;

    public static float notesCollected;
    public static float totalNotes;

    Animator m_Animator;
    AudioSource m_AudioSource;
    ScoreManager scoreManager;

    void Start()
    {
        m_Animator = GetComponent<Animator>();
        m_AudioSource = GetComponent<AudioSource>();
        scoreManager = GameObject.Find("ScoreManager").GetComponent<ScoreManager>();

        StartCoroutine(SetInactiveAfterMissing());
    }

    private void OnTriggerEnter(Collider other)
    {
        // Touched with which hand?
        switch (other.gameObject.name)
        {
            case "LeftHandAnchor":
                OVRInput.SetControllerVibration(1, 1, OVRInput.Controller.LTouch);
                break;
            case "RightHandAnchor":
                OVRInput.SetControllerVibration(1, 1, OVRInput.Controller.RTouch);
                break;
        }

        // Behavior of note after touched
        switch (gameObject.tag)
        {
            case "Tap":
                
                m_Animator.SetBool("IsTouched", true); // play touch animation
                scoreManager.addPoint();
                m_AudioSource.clip = tapSound;
                m_AudioSource.Play();

                
                
                StartCoroutine(SetInactiveAfterTouching());
                break;
            case "Arrow":
                m_Animator.SetBool("IsTouched", true); // play touch animation
                scoreManager.addPoint();
                m_AudioSource.clip = tapSound;
                m_AudioSource.Play();

                StartCoroutine(SetInactiveAfterTouching());
                break;
            case "Hold":
                
                m_AudioSource.clip = holdSound;
                m_AudioSource.Play();
                break;
        }

        notesCollected++;
    }

    // For hold note
    private void OnTriggerStay(Collider other)
    {
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
            case "Hold":
                
                m_Animator.SetBool("IsHeld", true);
                
                break;
        }

        holdNoteTime += Time.deltaTime;
        if (holdNoteTime > 0.8f)
        {
            scoreManager.addPoint();
            Vector3 position = gameObject.transform.position;
            Instantiate(heldParticle, position, Quaternion.identity, transform.parent);
            gameObject.SetActive(false);
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

        switch (gameObject.tag)
        {
            case "Hold":
                
                m_Animator.SetBool("IsHeld", false);
                break;
        }
    }


    IEnumerator SetInactiveAfterMissing()
    {
        yield return new WaitForSeconds(3.33f); // set this time to after the note spawn and missed animation has played
        gameObject.SetActive(false);
    }

    IEnumerator SetInactiveAfterTouching()
    {
        // yield return new WaitForSeconds(vibrationTime); // How long to vibrate?
        // OVRInput.SetControllerVibration(0, 0, OVRInput.Controller.LTouch);
        yield return new WaitForSeconds(.5f);

        gameObject.SetActive(false);
    }

    IEnumerator VibrationTime()
    {
        yield return new WaitForSeconds(vibrationTime);
    }
}
