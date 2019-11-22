using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BeatChecker : MonoBehaviour
{
    public float fluxThreshold;
    public List<float> beatTimes;
    public int totalNotes;
    public float nextTime;
    bool ready = false;
    public SongController songController;
    float playTime;
    int next = 0;

    void Start()
    {
        
    }
    public void FindTheGoodBeats(List<SpectralFluxInfo> songData)
    {
        int count = 0;

        List<SpectralFluxInfo> peaks = new List<SpectralFluxInfo>();

        foreach (SpectralFluxInfo pointInfo in songData)
        {
            if (pointInfo.isPeak)
            {
                count++;
                peaks.Add(pointInfo);
            }
        }
        ///////////////////////////////

        for (int i = 0; i < peaks.Count; i++)
        {
            float noteTime = peaks[i].time;
            float runningTotal = peaks[i].spectralFlux;
            int j = i - 1;
            int counter = 1;
            while(j >= 0 && noteTime <= peaks[j].time + 4)
            {
                runningTotal += peaks[j].spectralFlux;
                counter++;
                j--;
            }
            j = i + 1;
            while (j < peaks.Count && noteTime + 4 >= peaks[j].time)
            {
                runningTotal += peaks[j].spectralFlux;
                counter++;
                j++;
            }
            if(peaks[i].spectralFlux >= runningTotal / counter * 1.25)
            {
                beatTimes.Add(noteTime);
            }
        }

        //////////////////////////////

        /*
        fluxThreshold = runningTotal / count ;
        foreach(SpectralFluxInfo pointInfo in peaks)
        {
            if (pointInfo.spectralFlux >= fluxThreshold)
                beatTimes.Add(pointInfo.time);
        }
        */

        Debug.Log("HERE SHE COMES");
        /*
        foreach(float time in beatTimes)
        {
            Debug.Log("" + time);
        }
        Debug.Log("" + beatTimes);
        */
        songController.Play();
        ready = true;
    }

    // Update is called once per frame
    void Update()
    {
        if(!ready)
        {
            playTime = Time.time;
        }
        if (ready && beatTimes[next] <= Time.time - playTime)
        {
            Debug.Log("Item # " + next + " is being read as " + beatTimes[next] + " which is larger than " + Time.time + " minus " + playTime);
            transform.SetPositionAndRotation(new Vector3(0f, 0f, 0f), new Quaternion(0f, 0f, 0f, 0f));
            next++;
        }
    }
    
}
