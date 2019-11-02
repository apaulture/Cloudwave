using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// [ExecuteInEditMode]
public class SpawnController : MonoBehaviour
{
    // Note type
    public GameObject tap;
    public GameObject swipe;
    public GameObject hold;

    public AudioClip clip1;
    public AudioClip clip2;
    public AudioClip clip3;
    public AudioClip clip4;
    public AudioClip clip5;

    public float bpm;
    public float timeBetweenNotes;
    float secsInBetweenBeats;
    public int numberOfNotes;

    public enum Note { Tap, Swipe, Hold };
    public enum Clip { Clip1, Clip2, Clip3, Clip4, Clip5 };

    public float initialWait;

    public Note note1;
    public Vector3 position1;
    public Clip playClip1;
    public float wait1;

    public Note note2;
    public Vector3 position2;
    public Clip playClip2;
    public float wait2;

    public Note note3;
    public Vector3 position3;
    public Clip playClip3;
    public float wait3;

    public Note note4;
    public Vector3 position4;
    public Clip playClip4;
    public float wait4;

    public Note note5;
    public Vector3 position5;
    public Clip playClip5;
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
                    case Clip.Clip1:
                        note1source.clip = clip1;
                        break;
                    case Clip.Clip2:
                        note1source.clip = clip2;
                        break;
                    case Clip.Clip3:
                        note1source.clip = clip3;
                        break;
                    case Clip.Clip4:
                        note1source.clip = clip4;
                        break;
                    case Clip.Clip5:
                        note1source.clip = clip5;
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
                AudioSource note2source = spawnedNote.GetComponent<AudioSource>();
                switch (playClip2)
                {
                    case Clip.Clip1:
                        note2source.clip = clip1;
                        break;
                    case Clip.Clip2:
                        note2source.clip = clip2;
                        break;
                    case Clip.Clip3:
                        note2source.clip = clip3;
                        break;
                    case Clip.Clip4:
                        note2source.clip = clip4;
                        break;
                    case Clip.Clip5:
                        note2source.clip = clip5;
                        break;
                }

                note2source.Play();
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
                AudioSource note3source = spawnedNote.GetComponent<AudioSource>();
                switch (playClip3)
                {
                    case Clip.Clip1:
                        note3source.clip = clip1;
                        break;
                    case Clip.Clip2:
                        note3source.clip = clip2;
                        break;
                    case Clip.Clip3:
                        note3source.clip = clip3;
                        break;
                    case Clip.Clip4:
                        note3source.clip = clip4;
                        break;
                    case Clip.Clip5:
                        note3source.clip = clip5;
                        break;
                }

                note3source.Play();
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
                AudioSource note4source = spawnedNote.GetComponent<AudioSource>();
                switch (playClip4)
                {
                    case Clip.Clip1:
                        note4source.clip = clip1;
                        break;
                    case Clip.Clip2:
                        note4source.clip = clip2;
                        break;
                    case Clip.Clip3:
                        note4source.clip = clip3;
                        break;
                    case Clip.Clip4:
                        note4source.clip = clip4;
                        break;
                    case Clip.Clip5:
                        note4source.clip = clip5;
                        break;
                }

                note4source.Play();
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
                AudioSource note5source = spawnedNote.GetComponent<AudioSource>();
                switch (playClip5)
                {
                    case Clip.Clip1:
                        note5source.clip = clip1;
                        break;
                    case Clip.Clip2:
                        note5source.clip = clip2;
                        break;
                    case Clip.Clip3:
                        note5source.clip = clip3;
                        break;
                    case Clip.Clip4:
                        note5source.clip = clip4;
                        break;
                    case Clip.Clip5:
                        note5source.clip = clip5;
                        break;
                }

                note5source.Play();
                break;
            case Note.Swipe:
                spawnedNote = Instantiate(swipe, position5, Quaternion.identity, transform);
                break;
            case Note.Hold:
                spawnedNote = Instantiate(hold, position5, Quaternion.identity, transform);
                break;
        }

        yield return new WaitForSeconds(4);

        // Sixth note spawns here
        for (int i = numberOfNotes; i > 0; i--)
        {
            yield return new WaitForSeconds(timeBetweenNotes);
            float randomX = Random.Range(-0.5f,0.5f);
            Vector3 position = new Vector3(randomX,1.1f,0.5f);

            spawnedNote = Instantiate(tap, position, Quaternion.identity, transform);
            AudioSource note1source = spawnedNote.GetComponent<AudioSource>();
            note1source.clip = clip1;
            note1source.Play();
            

            
        }
        

    }
}