using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Song : MonoBehaviour
{
    public float bpm;
    public AudioClip song;
    public Spawner temp;
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
            System.Random rnd = new System.Random();
            temp.spawnNote(new Vector3(rnd.Next(-3, 3), rnd.Next(-2, 0), 0));
            nextNoteTime += 60 / bpm;
        }
    }
}
