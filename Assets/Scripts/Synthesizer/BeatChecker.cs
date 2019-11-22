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
    public float bias = 1.25f;

    // From audiosyncscale
    public Vector3 beatScale;
    public Vector3 restScale;
    public GameObject note;
    public Color32 leftBodyColor;
    public Color32 rightBodyColor;
    public Color32 leftHandsColor;
    public Color32 rightHandsColor;
    Color restColor;

    Renderer m_Renderer;
    bool ringLit;

    
    public float timeStep; // interval between beats
    public float timeToBeat; // length of time for the object to scale up
    public float restRate; // how fast object go to rest
    protected bool m_IsBeat;
    float m_Timer;

    void Start()
    {
        m_Renderer = GetComponent<Renderer>();
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
            if(peaks[i].spectralFlux >= runningTotal / counter * bias)
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
        if(next < beatTimes.Count)
            {
            transform.localScale = Vector3.Lerp(transform.localScale, restScale, restRate * Time.deltaTime); // if not, lerp scale to rest scale

            // from audiosyncscale
            if (ringLit)
            {
                switch (transform.tag)
                {
                    case "Hand":
                        restColor = Color32.Lerp(leftHandsColor, Color.black, Time.time);
                        break;
                    case "Body":
                        restColor = Color32.Lerp(leftBodyColor, Color.black, Time.time);
                        break;
                }

                m_Renderer.material.SetColor("_EmissionColor", restColor);
            }



            if (!ready)
            {
                playTime = Time.time;
            }
            if (ready && beatTimes[next] <= Time.time - playTime)
            {

                // Randomize spawn position of notes
                Vector3 position = transform.position;
                position.x += Random.Range(-0.2f, 0.2f);
                position.y += Random.Range(-0.2f, 0.2f);
                Vector3 positionBody = transform.position;


                Instantiate(note, position, Quaternion.identity, transform.parent);
                StopCoroutine("MoveToScale");
                StartCoroutine("MoveToScale", beatScale);
                m_Renderer.material.SetColor("_EmissionColor", leftHandsColor);
                NoteController.totalNotes++;

                next++;
            }
        }
    }

    IEnumerator MoveToScale(Vector3 _target)
    {
        Vector3 _current = transform.localScale;
        Vector3 _initial = _current;

        float _timer = 0;

        while (_current != _target)
        {
            _current = Vector3.Lerp(_initial, _target, _timer / timeToBeat); // lerp the scale from initial to target scale
            _timer += Time.deltaTime;

            transform.localScale = _current; // Adjust the transform local scale up to the value produced by lerp



            yield return null;
        }

        ringLit = true;

        // m_IsBeat = false;

    }
}
