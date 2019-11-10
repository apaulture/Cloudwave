using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioSyncer : MonoBehaviour
{
    public float bias; // what spectrum value triggers "beat"
    public float timeStep; // interval between beats
    public float timeToBeat; // length of time for the object to scale up
    public float restRate; // how fast object go to rest

    float m_PreviousAudioValue; // in current frame, did this value went above the bias? if it did, then we have a beat!
    float m_AudioValue;
    float m_Timer; // to keep track of timeStep interval
    

    protected bool m_IsBeat; // is current object in "beating" state?

    private void Start()
    {
        // timeStep = (60.0f / bpm) * beatIntervalRate;
    }

    public virtual void OnBeat()
    {
        m_Timer = 0;
        m_IsBeat = true;
    }


    public virtual void OnUpdate()
    {
        m_PreviousAudioValue = m_AudioValue;
        m_AudioValue = AudioSpectrum.spectrumValue;

        if (m_PreviousAudioValue > bias && m_AudioValue <= bias)
        {
            if (m_Timer > timeStep)
                OnBeat();
        }

        if (m_PreviousAudioValue <= bias && m_AudioValue > bias)
        {
            if (m_Timer > timeStep)
                OnBeat();
        }

        m_Timer += Time.deltaTime;
    }
    
    void Update()
    {
        OnUpdate();
    }
}
