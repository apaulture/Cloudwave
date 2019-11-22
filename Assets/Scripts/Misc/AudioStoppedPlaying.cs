using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioStoppedPlaying : MonoBehaviour
{
    public GameObject scoreBoard;
    public TextMesh rankingText;
    public TextMesh collectedText;
    public TextMesh totalText;
    public GameObject elevatorgate;

    AudioSource m_AudioSource;

    string message;
    float percentage;
    
    void Start()
    {
        m_AudioSource = GetComponent<AudioSource>();
    }

    void Update()
    {
        percentage = (NoteController.notesCollected - 15 / NoteController.totalNotes);
        // print("Collected " + NoteController.notesCollected + " / " + NoteController.totalNotes + " | " + percentage + "%");

        // Show scoreboard after song has finished playing
        if (!m_AudioSource.isPlaying)
        {
            if (percentage >= 1)
            {
                message = "S";
            }
            else if (percentage >= .9f)
            {
                message = "A";
            }
            else if (percentage >= .8f)
            {
                message = "B";
            }
            else if (percentage >= .7f)
            {
                message = "C";
            }
            else if (percentage >= .6f)
            {
                message = "D";
            }
            else
            {
                message = "F";
            }

            scoreBoard.SetActive(true);
            rankingText.text = message;
            collectedText.text = (NoteController.notesCollected - 15).ToString();
            totalText.text = " / " + NoteController.totalNotes.ToString();
            elevatorgate.GetComponent<Animator>().SetBool("SongEnded", true);
        }
    }
}
