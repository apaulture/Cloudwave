using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ZoneSpawnController : MonoBehaviour
{
    public GameObject note;
    Renderer m_NoteRenderer;
    float m_NoteOpacity;

    // Start is called before the first frame update
    void Start()
    {
        Vector3 position = transform.position + (1.5f * transform.forward);
        GameObject spawnedNote = Instantiate(note, position, Quaternion.identity, gameObject.transform);

        m_NoteRenderer = spawnedNote.GetComponent<Renderer>();
        m_NoteOpacity = m_NoteRenderer.sharedMaterial.color.a;
        m_NoteOpacity = 0;
    }

    // Update is called once per frame
    void Update()
    {
        while (m_NoteOpacity < 1)
        {
            m_NoteOpacity += Time.deltaTime * 0.01f;
            print(m_NoteOpacity);
        }
    }
}
