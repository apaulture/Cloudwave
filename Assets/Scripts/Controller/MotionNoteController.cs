using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MotionNoteController : MonoBehaviour
{
    Vector3 direction;
    Animator m_Animator;
    float speed;

    void Start()
    {
        m_Animator = GetComponent<Animator>();

        direction = Vector3.back;
        speed = NoteMotionController.noteSpeed;

        // If the note's velocity is greater than 0, the note is coming from the speaker so play animation based on its velocity
        if (speed > 0)
        {
            m_Animator.SetBool("IsSpeakerNote", true);
        }
        else if (speed == 0)
        {
            m_Animator.SetBool("IsSpeakerNote", false);
        }
    }

    void FixedUpdate()
    {
        transform.Translate(direction * Time.fixedDeltaTime * speed);
    }
}
