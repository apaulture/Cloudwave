using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioSpectrum : MonoBehaviour
{
    float[] m_AudioSpectrum;
    AudioSource m_AudioSource;
    public static float spectrumValue { get; private set; }
    
    void Start()
    {
        m_AudioSpectrum = new float[128];
        m_AudioSource = GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {
        m_AudioSource.GetSpectrumData(m_AudioSpectrum, 0, FFTWindow.BlackmanHarris);

        if (m_AudioSpectrum != null && m_AudioSpectrum.Length > 0)
        {
            spectrumValue = m_AudioSpectrum[0] * 250;
        }
    }
}
