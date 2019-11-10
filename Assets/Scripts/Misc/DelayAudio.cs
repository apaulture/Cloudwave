using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DelayAudio : MonoBehaviour
{
    AudioSource m_AudioSource;
    public float timeDelayed;

    // Start is called before the first frame update
    void Start()
    {
        m_AudioSource = GetComponent<AudioSource>();
        m_AudioSource.PlayDelayed(timeDelayed);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
