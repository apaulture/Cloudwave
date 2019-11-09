using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnControllerTest : MonoBehaviour
{
    public int bpm;
    public float initialWait;
    public float reachDistance = 0.7f;
    public GameObject[] noteTypes = new GameObject[3];

    public int[] planeDegree;
    public int[] heightDegree;
    public enum Note { Tap, Swipe, Hold };
    public Note[] noteType;

    public float[] waitMultiplier;

    float wait;

    private void Awake()
    {
        // Wait time between notes based on bpm
        wait = (60 / bpm) - .01f;
    }

    void Start()
    {
        StartCoroutine(SpawnNotes());

        
    }

    IEnumerator SpawnNotes()
    {
        yield return new WaitForSeconds(initialWait);

        Vector3 position;
        for (int i = 0; i < waitMultiplier.Length; i++)
        {
            print("Spawning note at time: " + Time.time);


            position = new Vector3(Mathf.Cos(planeDegree[i] * Mathf.Deg2Rad), 0, Mathf.Sin(planeDegree[i] * Mathf.Deg2Rad));
            position *= reachDistance; // radial distance from origin

            switch (noteType[i])
            {
                case Note.Tap:
                    Instantiate(noteTypes[0], position, Quaternion.identity, transform);
                    break;
                case Note.Swipe:
                    Instantiate(noteTypes[1], position, Quaternion.identity, transform);
                    break;
                case Note.Hold:
                    Instantiate(noteTypes[2], position, Quaternion.identity, transform);
                    break;
            }
            yield return new WaitForSeconds(wait * waitMultiplier[i]);
        }
    }

    
}
