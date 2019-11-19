using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BeatChecker : MonoBehaviour
{
    public float fluxThreshold;
    public List<float> beatTimes;
    public int totalNotes;
    public float nextTime;

    void FindTheGoodBeats(List<SpectralFluxInfo> songData)
    {
        float runningTotal = 0f;
        int count = 0;

        List<SpectralFluxInfo> peaks = new List<SpectralFluxInfo>();

        foreach(SpectralFluxInfo pointInfo in songData)
        {
            if(pointInfo.isPeak)
            {
                runningTotal += pointInfo.spectralFlux;
                count++;
                peaks.Add(pointInfo);
            }
        }
        fluxThreshold = runningTotal / count;
        foreach(SpectralFluxInfo pointInfo in peaks)
        {
            if (pointInfo.spectralFlux >= fluxThreshold)
                beatTimes.Add(pointInfo.time);
        }
    }

    // Update is called once per frame
    void Update()
    {
        if (beatTimes[0] >= Time.time)
        {
            transform.SetPositionAndRotation(new Vector3(0f, 0f, 0f), new Quaternion(0f, 0f, 0f, 0f));
            beatTimes.Remove(beatTimes[0]);
        }
    }
}
