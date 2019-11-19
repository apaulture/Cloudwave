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
                    restColor = Color32.Lerp(leftHandsColor, Color.black, Time.time);
                    break;
                case "Body":
                    restColor = Color32.Lerp(leftBodyColor, Color.black, Time.time);
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
        position.x += Random.Range(-0.3f, 0.3f);
        position.y += Random.Range(-0.3f, 0.3f);

        /*
        int bodyPosition = 0;
        int notesRemaining;
        bool left = false, center = false, right = false;

        // Body position: left (1), center (2), right (3)
        if (left == false && center == false && right == false)
        {
            bodyPosition = Random.Range(1, 4);
        }
        */

        int bodyPosition = Random.Range(1, 4);

        // left position
        if (bodyPosition == 1)
        {
            /*
            notesRemaining = 6;
            left = true;
            center = false;
            right = false;
            */

            // while (notesRemaining > 0)
            {
                int leftPosition = Random.Range(1, 6);
                if (leftPosition <= 2 && transform.name == "LBLH")
                {
                    Instantiate(note, position, Quaternion.identity, transform.parent);
                    StopCoroutine("MoveToScale");
                    StartCoroutine("MoveToScale", beatScale);
                    m_Renderer.material.SetColor("_EmissionColor", leftHandsColor);
                    NoteController.totalNotes++;
                    // notesRemaining--;
                }
                else if (leftPosition == 3 && transform.name == "LB")
                {
                    Instantiate(note, position, Quaternion.identity, transform.parent);
                    StopCoroutine("MoveToScale");
                    StartCoroutine("MoveToScale", beatScale);
                    m_Renderer.material.SetColor("_EmissionColor", leftBodyColor);
                    NoteController.totalNotes++;
                    // notesRemaining--;
                }
                else if (leftPosition > 3 && transform.name == "CBLHLBRH")
                {
                    Instantiate(note, position, Quaternion.identity, transform.parent);
                    StopCoroutine("MoveToScale");
                    StartCoroutine("MoveToScale", beatScale);
                    m_Renderer.material.SetColor("_EmissionColor", leftHandsColor);
                    NoteController.totalNotes++;
                    // notesRemaining--;
                }
            }

            // After notes remaining reaches 0...
            // left = false;
        }

        // center position
        else if (bodyPosition == 2)
        {


            // while (notesRemaining > 0)
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

            // center = false;
        }

        // right position
        else if (bodyPosition == 3)
        {

            // while (notesRemaining > 0)
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
                    Instantiate(note, position, Quaternion.identity, transform.parent);
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

            // right = false;
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