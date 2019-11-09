using UnityEngine;
using System.Collections;

public class AudioSyncScale : AudioSyncer
{
    public Vector3 beatScale;
    public Vector3 restScale;
    public GameObject note;
    

    Renderer m_Renderer;
    bool ringLit;

    private void Start()
    {
        m_Renderer = GetComponent<Renderer>();
    }

    public override void OnUpdate()
    {
        base.OnUpdate();

        if (m_IsBeat) return; // stop here if the note is currently beating

        transform.localScale = Vector3.Lerp(transform.localScale, restScale, timeToRest * Time.deltaTime); // if not, lerp scale to rest scale

        if (ringLit)
        {
            Color restColor = Color32.Lerp(Color.white, Color.black, Time.time);
            m_Renderer.material.SetColor("_EmissionColor", restColor);
        }
    }

    public override void OnBeat()
    {
        base.OnBeat();

        
        StopCoroutine("MoveToScale");
        StartCoroutine("MoveToScale", beatScale);
        m_Renderer.material.SetColor("_EmissionColor", Color.white);

        Instantiate(note, transform.position, Quaternion.identity);
        

        /*
        StopCoroutine("MoveToScale");

        int randomNum = Random.Range(1, 3);
        if (randomNum == 1 && transform.name == "Diaphragm1")
        {
            
            StartCoroutine("MoveToScale", beatScale);
            m_Renderer.material.SetColor("_EmissionColor", Color.white);

            Instantiate(note, transform.position, Quaternion.identity);
        }
        else if (randomNum == 2 && transform.name == "Diaphragm2")
        {
            
            StartCoroutine("MoveToScale", beatScale);
            m_Renderer.material.SetColor("_EmissionColor", Color.white);
            Instantiate(note, transform.position, Quaternion.identity);
        }
        */



        // print(DiaphragmController.notes);
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

        m_IsBeat = false;
    }
}

/*
 *
 * string randomDiaphragm = "Diaphragm" + randomNum;
        print(randomDiaphragm);
        switch (randomDiaphragm)
        {
            case "Diaphragm1":
                if (transform.name == "Diaphragm1")
                {
                    Instantiate(note, transform.position, Quaternion.identity);
                    
                }
                break;
            case "Diaphragm2":
                if (transform.name == "Diaphragm2")
                {
                    Instantiate(note, transform.position, Quaternion.identity);

                }
                break;
        }
*/