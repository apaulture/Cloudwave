using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SwipeController : MonoBehaviour
{
    public int swipeLength = 5;
    public GameObject note;

    GameObject[] swipeNotes;
    Vector3 m_NotePosition;

    // Components
    SphereCollider m_Collider;
    Collider m_ChildCollider;

    void Start()
    {
        m_ChildCollider = GetComponentInChildren<Collider>();
        m_Collider = GetComponent<SphereCollider>();

        swipeNotes = new GameObject[swipeLength];
        m_NotePosition = transform.position;

        for (int i = 0; i < swipeLength; i++)
        {
            m_NotePosition.z += 0.5f;
            swipeNotes[i] = Instantiate(note, m_NotePosition, Quaternion.identity, transform);
            print(i + ": " + swipeNotes[i]);

            // First element of the array is the only note with collider enabled
            // After first element has been triggered, enable collider of next element


            swipeNotes[i + 1].GetComponent<SphereCollider>().enabled = !swipeNotes[i + 1].GetComponent<SphereCollider>().enabled;
        }

        
    }

    void Update()
    {
        if (transform.GetChild(0).gameObject.activeSelf == false)
        {
            transform.GetChild(1).GetComponent<Collider>().enabled = true;
        }
    }
}
