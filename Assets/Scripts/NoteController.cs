using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NoteController : MonoBehaviour
{
    public float vibrationTime;
    public AudioClip clip1;
    public AudioClip clip2;
    public ParticleSystem heldParticle;
    float holdNoteTime;

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
                scoreManager.addPoint();

                // Randomly choose a clip to play when tap note is touched

                int randomClip = Random.Range(1, 3);
                switch (randomClip)
                {
                    case 1:
                        //m_AudioSource.clip = clip1;
                        break;
                    case 2:
                        //m_AudioSource.clip = clip2;
                        break;
                }

                // Play "clip x" when touched
                //m_AudioSource.Play();

                StartCoroutine(SetInactiveAfterTouching());
                break;
            case "Arrow":
                m_Animator.SetBool("IsTouched", true); // play touch animation

                break;
        }
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
