using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NoteController : MonoBehaviour
{
    public AudioClip tapSound;

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

        if (gameObject.name == "Tap(Clone)")
        {
            m_Animator.SetBool("IsSpeakerNote", true);
        }
        

        if (gameObject.name == "Body(Clone)")
        {
            m_Animator.SetBool("IsBodySpeakerNote", true);
        }

        StartCoroutine(SetInactiveAfterMissing());
    }

    private void OnTriggerEnter(Collider other)
    {
        switch (gameObject.tag)
        {
            case "Tap":
                //if (other.gameObject.name == "LeftHandAnchor" || other.gameObject.name == "RightHandAnchor")
                {
                    m_Animator.SetBool("IsTouched", true); // play touch animation
                    scoreManager.addPoint();
                    m_AudioSource.clip = tapSound;
                    m_AudioSource.Play();
                    notesCollected++;


                    StartCoroutine(SetInactiveAfterTouching());
                }
                
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
}
