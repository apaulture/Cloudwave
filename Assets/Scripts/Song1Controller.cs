using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// [ExecuteInEditMode]
public class Song1Controller : MonoBehaviour
{
    // Note type
    public GameObject tap;
    public GameObject swipe;
    public GameObject hold;

    public AudioClip clip1;
    public AudioClip clip2;

    public float bpm;
    public float timeBetweenNotes;
    float secsInBetweenBeats;
    public int numberOfNotes;

    public enum Note { Tap, Swipe, Hold };
    public enum Clip { C4, C6 };

    public float initialWait;

    public Note note1;
    public Vector3 position1;
    public Clip playClip1;
    public float wait1;

    public Note note2;
    public Vector3 position2;
    public float wait2;

    public Note note3;
    public Vector3 position3;
    public float wait3;

    public Note note4;
    public Vector3 position4;
    public float wait4;

    public Note note5;
    public Vector3 position5;
    public float wait5;

    GameObject spawnedNote; // Instantiated note
    SwipeController swipeNote;

    void Start()
    {
        swipeNote = swipe.GetComponent<SwipeController>();
        secsInBetweenBeats = 60.0f / bpm;

        StartCoroutine(NoteSpawning());
    }

    void Update()
    {

    }

    IEnumerator NoteSpawning()
    {
        yield return new WaitForSeconds(initialWait);

        switch (note1)
        {
            case Note.Tap:
                spawnedNote = Instantiate(tap, position1, Quaternion.identity, transform);
                AudioSource note1source = spawnedNote.GetComponent<AudioSource>();
                switch (playClip1)
                {
                    case Clip.C4:
                        note1source.clip = clip1;
                        break;
                    case Clip.C6:
                        note1source.clip = clip2;
                        break;
                }

                note1source.Play();

                break;
            case Note.Swipe:
                spawnedNote = Instantiate(swipe, position1, Quaternion.identity, transform);

                break;
            case Note.Hold:
                spawnedNote = Instantiate(hold, position1, Quaternion.identity, transform);
                break;
        }

        yield return new WaitForSeconds(wait1);

        switch (note2)
        {
            case Note.Tap:
                spawnedNote = Instantiate(tap, position2, Quaternion.identity, transform);
                break;
            case Note.Swipe:
                spawnedNote = Instantiate(swipe, position2, Quaternion.identity, transform);
                break;
            case Note.Hold:
                spawnedNote = Instantiate(hold, position2, Quaternion.identity, transform);
                break;
        }

        yield return new WaitForSeconds(wait2);

        switch (note3)
        {
            case Note.Tap:
                spawnedNote = Instantiate(tap, position3, Quaternion.identity, transform);
                break;
            case Note.Swipe:
                spawnedNote = Instantiate(swipe, position3, Quaternion.identity, transform);
                break;
            case Note.Hold:
                spawnedNote = Instantiate(hold, position3, Quaternion.identity, transform);
                break;
        }

        yield return new WaitForSeconds(wait3);

        switch (note4)
        {
            case Note.Tap:
                spawnedNote = Instantiate(tap, position4, Quaternion.identity, transform);
                break;
            case Note.Swipe:
                spawnedNote = Instantiate(swipe, position4, Quaternion.identity, transform);
                break;
            case Note.Hold:
                spawnedNote = Instantiate(hold, position4, Quaternion.identity, transform);
                break;
        }

        yield return new WaitForSeconds(wait4);

        switch (note5)
        {
            case Note.Tap:
                spawnedNote = Instantiate(tap, position5, Quaternion.identity, transform);
                break;
            case Note.Swipe:
                spawnedNote = Instantiate(swipe, position5, Quaternion.identity, transform);
                break;
            case Note.Hold:
                spawnedNote = Instantiate(hold, position5, Quaternion.identity, transform);
                break;
        }



        // Sixth note spawns here
        for (int i = numberOfNotes; i > 0; i--)
        {
            yield return new WaitForSeconds(timeBetweenNotes);
            float randomX = Random.Range(-0.5f, 0.5f);
            Vector3 position = new Vector3(randomX, 1.1f, 0.5f);

            Instantiate(tap, position, Quaternion.identity, transform);


        }


    }
}