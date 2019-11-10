using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioStoppedPlaying : MonoBehaviour
{
    AudioSource m_AudioSource;
    public GameObject text;
    public TextMesh rankingText;
    public TextMesh collectedText;
    public TextMesh totalText;
    string message;
    float percentage;
    // Start is called before the first frame update
    void Start()
    {
        m_AudioSource = GetComponent<AudioSource>();

        




    }

    // Update is called once per frame
    void Update()
    {
        percentage = (NoteController.notesCollected / NoteController.totalNotes);
        // print("Collected " + NoteController.notesCollected + " / " + NoteController.totalNotes + " | " + percentage + "%");

        if (!m_AudioSource.isPlaying)
        {
            if (percentage >= 1)
            {
                message = "Nerd";
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
                message = "You suck balls";
            }

            text.SetActive(true);
            rankingText.text = message;
            collectedText.text = NoteController.notesCollected.ToString();
            totalText.text = "/ " + NoteController.totalNotes.ToString();
        }
    }
}
