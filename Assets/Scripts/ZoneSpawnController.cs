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

    GameObject spawnedNote; // Instantiated note
    Vector3 randomPosition;
    Quaternion randomDirection;

    // Components
    Renderer m_Renderer;

    void Start()
    {
        // Coroutine
        StartCoroutine(NoteSpawning());
        
    }

    void Update()
    {

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
                    // Play spawn animation here
                    break;
                case 1:
                    spawnedNote = Instantiate(swipe, randomPosition, randomDirection); // Spawn note at notePosition
                    spawnedNote.transform.name = swipe.name;
                    // Play spawn animation here
                    break;
                case 2:
                    spawnedNote = Instantiate(hold, randomPosition, randomDirection); // Spawn note at notePosition
                    spawnedNote.transform.name = hold.name;
                    // Play spawn animation here
                    break;
            }

            yield return new WaitForSeconds(2);
            noteCount--;
        }

        m_Renderer = spawnedNote.GetComponent<Renderer>();
    }
}