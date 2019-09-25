using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ZoneSpawnController : MonoBehaviour
{
    public GameObject note;
    public GameObject swipeNote;
    public GameObject zone; // To use for measuring relative zone radius to note position
    public int noteCount;
    
    float t;

    public Vector3 noteScaleRate = new Vector3(.01f, .01f, .01f); // Rate of scale increase
    float originalNoteSize;

    Animator m_Animator;
    Renderer m_Renderer;
    GameObject spawnedNote;
    public AudioSource m_AudioSource;

    Vector3 randomPosition;
    Quaternion randomDirection;

    // For smoothDamp
    Vector3 velocity = Vector3.zero;

    void Start()
    {
        m_Animator = GetComponent<Animator>();
        m_AudioSource = GetComponent<AudioSource>();
        m_AudioSource.Play();

        originalNoteSize = note.transform.localScale.magnitude; // Initial scale of note prefab
        
        // Coroutine
        StartCoroutine(NoteSpawning());
    }

    void Update()
    {
        t += Time.deltaTime * 0.5f; // how fast the note's opacity interpolates to 1
        
        if (spawnedNote.transform.localScale.magnitude < originalNoteSize)
        {
            spawnedNote.transform.localScale += noteScaleRate;
            m_Renderer.material.color = new Color(1, 0.6143571f, 0.3349057f, Mathf.Lerp(0, 1, t));
        }

        // Scale the note by easing in (when you have time)
        // spawnedNote.transform.localScale = Vector3.SmoothDamp(Vector3.zero, new Vector3(5, 5, 5), ref velocity, 0.3f);
    }

    IEnumerator NoteSpawning()
    {
        while (noteCount > 0)
        {
            randomPosition = new Vector3(Random.Range(-1.5f,1.5f), Random.Range(1,1.5f), Random.Range(-1.5f, 1.5f)); // Randomize position vector in cartesian coordinate
            randomDirection = Quaternion.Euler(new Vector3(0, Random.Range(0, 360), Random.Range(0, 180)));

            // Random spawn "tap" or "swipe" note
            switch (Random.Range(1,3))
            {
                case 1:
                    spawnedNote = Instantiate(note, randomPosition, Quaternion.identity, gameObject.transform); // Spawn note at notePosition
                    spawnedNote.transform.localScale = Vector3.zero; // Set spawnedNote scale to 0
                    break;
                case 2:
                    spawnedNote = Instantiate(swipeNote, randomPosition, randomDirection, gameObject.transform); // Spawn note at notePosition
                    spawnedNote.transform.localScale = Vector3.zero; // Set spawnedNote scale to 0
                    break;
            }
            

            m_Renderer = spawnedNote.GetComponent<Renderer>();

            yield return new WaitForSeconds(1); // 60 BPM
            noteCount--;
        }
        
    }
}
