using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ZoneSpawnController : MonoBehaviour
{
    // Note type
    public GameObject tap;
    public GameObject swipe;
    public GameObject hold;

    public int noteCount; // Number of notes to spawn
    public Vector3 noteScaleRate = new Vector3(.01f, .01f, .01f); // Rate of scale increase

    float t;
    float originalNoteSize;
    GameObject spawnedNote; // Instantiated note
    Vector3 randomPosition;
    Quaternion randomDirection;

    // Components
    Renderer m_Renderer;

    void Start()
    {
        originalNoteSize = tap.transform.localScale.magnitude;
        
        // Coroutine
        StartCoroutine(NoteSpawning());
        
    }

    void Update()
    {
        t += Time.deltaTime * 0.1f;
        if (spawnedNote.transform.localScale.magnitude < originalNoteSize)
        {
            
            spawnedNote.transform.localScale += noteScaleRate;
            m_Renderer.material.color = new Color(1, 0.6143571f, 0.3349057f, Mathf.Lerp(0, 1, t));
            //m_Renderer.material.SetColor("_Color", new Color(1, 0, 0, Mathf.Lerp(0, 1, Time.deltaTime * 0.5f)));
        }
        print("Spawned note size: " + spawnedNote.transform.localScale.magnitude);
    }

    IEnumerator NoteSpawning()
    {
        while (noteCount > 0)
        {
            randomPosition = new Vector3(Random.Range(-1.5f,1.5f), Random.Range(0.25f,1.5f), Random.Range(-1.5f, 1.5f)); // Randomize position vector in cartesian coordinate
            randomDirection = Quaternion.Euler(new Vector3(0, Random.Range(0, 360), Random.Range(0, 180)));

            // Random spawn "tap" or "swipe" note
            switch (Random.Range(0,3))
            {
                case 0:
                    spawnedNote = Instantiate(tap, randomPosition, Quaternion.identity); // Spawn note at notePosition
                    spawnedNote.transform.name = tap.name;
                    spawnedNote.transform.localScale = Vector3.zero; // Set spawnedNote scale to 0
                    break;
                case 1:
                    spawnedNote = Instantiate(swipe, randomPosition, randomDirection); // Spawn note at notePosition
                    spawnedNote.transform.name = swipe.name;
                    spawnedNote.transform.localScale = Vector3.zero; // Set spawnedNote scale to 0
                    break;
                case 2:
                    spawnedNote = Instantiate(hold, randomPosition, randomDirection); // Spawn note at notePosition
                    spawnedNote.transform.name = hold.name;
                    spawnedNote.transform.localScale = Vector3.zero; // Set spawnedNote scale to 0
                    break;
            }


            m_Renderer = spawnedNote.GetComponent<Renderer>();

            yield return new WaitForSeconds(2);
            noteCount--;
        }
        
    }
}