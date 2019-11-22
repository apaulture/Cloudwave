using UnityEngine;
using System.Collections;

public class AudioSyncScale : AudioSyncer
{
    public Vector3 beatScale;
    public Vector3 restScale;
    public GameObject note;
    public Color32 leftBodyColor;
    public Color32 rightBodyColor;
    public Color32 leftHandsColor;
    public Color32 rightHandsColor;
    public Color32 restColor1;
    Color restColor;

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

        transform.localScale = Vector3.Lerp(transform.localScale, restScale, restRate * Time.deltaTime); // if not, lerp scale to rest scale

        if (ringLit)
        {
            switch (transform.tag)
            {
                case "Hand":
                    restColor = Color32.Lerp(leftHandsColor, restColor1, Time.time);
                    break;
                case "Body":
                    restColor = Color32.Lerp(leftBodyColor, restColor1, Time.time);
                    break;
            }

            m_Renderer.material.SetColor("_EmissionColor", restColor);
        }
    }

    public override void OnBeat()
    {
        base.OnBeat();

        // Randomize spawn position of notes
        Vector3 position = transform.position;
        position.x += Random.Range(-0.2f, 0.2f);
        position.y += Random.Range(-0.2f, 0.2f);
        Vector3 positionBody = transform.position;

        


        
        int bodyPosition = Random.Range(1, 4);

        if (bodyPosition == 1)
        {
            
                int leftPosition = Random.Range(1, 6);
                if (leftPosition <= 2 && transform.name == "LBLH")
                {
                    Instantiate(note, position, Quaternion.identity, transform.parent);
                    StopCoroutine("MoveToScale");
                    StartCoroutine("MoveToScale", beatScale);
                    m_Renderer.material.SetColor("_EmissionColor", leftHandsColor);
                    NoteController.totalNotes++;
                }
                else if (leftPosition == 3 && transform.name == "LB")
                {
                    Instantiate(note, positionBody, Quaternion.Euler(0, 90 - 1.977f, 90), transform.parent);
                    StopCoroutine("MoveToScale");
                    StartCoroutine("MoveToScale", beatScale);
                    m_Renderer.material.SetColor("_EmissionColor", leftBodyColor);
                    NoteController.totalNotes++;
                }
                else if (leftPosition > 3 && transform.name == "CBLHLBRH")
                {
                    Instantiate(note, position, Quaternion.identity, transform.parent);
                    StopCoroutine("MoveToScale");
                    StartCoroutine("MoveToScale", beatScale);
                    m_Renderer.material.SetColor("_EmissionColor", leftHandsColor);
                    NoteController.totalNotes++;
                }
        }

        else if (bodyPosition == 2)
        {
            int centerPosition = Random.Range(1, 3);
            if (centerPosition == 1 && transform.name == "CBLHLBRH")
            {
                Instantiate(note, position, Quaternion.identity, transform.parent);
                StopCoroutine("MoveToScale");
                StartCoroutine("MoveToScale", beatScale);
                m_Renderer.material.SetColor("_EmissionColor", leftHandsColor);
                NoteController.totalNotes++;

            }
            else if (centerPosition == 2 && transform.name == "CBRHRBLH")
            {
                Instantiate(note, position, Quaternion.identity, transform.parent);
                StopCoroutine("MoveToScale");
                StartCoroutine("MoveToScale", beatScale);
                m_Renderer.material.SetColor("_EmissionColor", leftHandsColor);
                NoteController.totalNotes++;

            }
        }

        else if (bodyPosition == 3)
        {
            int rightPosition = Random.Range(1, 6);
            if (rightPosition <= 2 && transform.name == "CBRHRBLH")
            {
                Instantiate(note, position, Quaternion.identity, transform.parent);
                StopCoroutine("MoveToScale");
                StartCoroutine("MoveToScale", beatScale);
                m_Renderer.material.SetColor("_EmissionColor", leftHandsColor);
                NoteController.totalNotes++;
            }
            else if (rightPosition == 3 && transform.name == "RB")
            {
                Instantiate(note, positionBody, Quaternion.Euler(180, 90 + 1.977f, 90), transform.parent);
                StopCoroutine("MoveToScale");
                StartCoroutine("MoveToScale", beatScale);
                m_Renderer.material.SetColor("_EmissionColor", rightBodyColor);
                NoteController.totalNotes++;
            }
            else if (rightPosition > 3 && transform.name == "RBRH")
            {
                Instantiate(note, position, Quaternion.identity, transform.parent);
                StopCoroutine("MoveToScale");
                StartCoroutine("MoveToScale", beatScale);
                m_Renderer.material.SetColor("_EmissionColor", leftHandsColor);
                NoteController.totalNotes++;
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

        m_IsBeat = false;
        
    }
}