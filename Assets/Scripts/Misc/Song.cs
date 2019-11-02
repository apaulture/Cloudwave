using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Song : MonoBehaviour
{
    public float bpm;
    public AudioClip song;
    public GameObject temp;
    private float timeCounter;
    private float nextNoteTime;


    // Start is called before the first frame update
    void Start()
    {
        timeCounter = 0f;
    }

    // Update is called once per frame
    void Update()
    {
        timeCounter += Time.deltaTime;
        if(timeCounter >= nextNoteTime)
        {
            // temp.spawnNote();
            nextNoteTime += 60 / bpm;
        }
    }
}
