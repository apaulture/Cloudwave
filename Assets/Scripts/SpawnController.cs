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

    public enum Note { Tap, Swipe, Hold };

    public Note note1;
    public Vector3 position1;
    public float wait1;

    public Note note2;
    public Vector3 position2;
    public float wait2;

    public Note note3;
    public Vector3 position3;

    GameObject spawnedNote; // Instantiated note
    SwipeController swipeNote;

    void Start()
    {
        swipeNote = swipe.GetComponent<SwipeController>();

        StartCoroutine(NoteSpawning());
    }

    void Update()
    {

    }

    IEnumerator NoteSpawning()
    {
        switch (note1)
        {
            case Note.Tap:
                spawnedNote = Instantiate(tap, position1, Quaternion.identity, transform);
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
    }
}