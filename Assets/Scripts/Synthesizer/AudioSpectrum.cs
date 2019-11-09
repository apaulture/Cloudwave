using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioSpectrum : MonoBehaviour
{
    float[] m_AudioSpectrum;
    public static float spectrumValue { get; private set; }
    
    void Start()
    {
        m_AudioSpectrum = new float[128];
    }

    // Update is called once per frame
    void Update()
    {
        AudioListener.GetSpectrumData(m_AudioSpectrum, 0, FFTWindow.BlackmanHarris);

        if (m_AudioSpectrum != null && m_AudioSpectrum.Length > 0)
        {
            spectrumValue = m_AudioSpectrum[0] * 150;
        }
    }
}
