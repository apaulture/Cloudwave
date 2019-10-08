using System.Collections;
using System.Collections.Generic;
using UnityEngine;



public class SwipeController : MonoBehaviour
{
    public int swipeLength = 5;
    public GameObject note;
    public GameObject arrow;
    public bool oscillate;
    public bool linear;
    public bool spiral;
    public float stretch = 1;


    GameObject[] swipeNotes;
    Vector3 m_NotePosition;

    /* Components
    Collider m_Collider;
    Collider m_ChildCollider;
    Renderer m_Renderer;
    Animator m_Animator;
    */

    void Start()
    {
        /*
        m_ChildCollider = GetComponentInChildren<Collider>();
        m_Collider = GetComponent<Collider>();
        m_Renderer = GetComponent<Renderer>();
        m_Animator = GetComponentInChildren<Animator>();
        */


        swipeNotes = new GameObject[swipeLength];
        m_NotePosition = transform.position;

        for (int i = 0; i < swipeLength; i++)
        {
            if (oscillate)
            {
                m_NotePosition.y += Mathf.Cos((360 / swipeLength) * i) * 0.2f;
                m_NotePosition.x += 0.05f * stretch;
            }
            else if (spiral)
            {
                m_NotePosition.x += Mathf.Sin((360 / swipeLength) * i) * 0.25f;
                m_NotePosition.y += 0.01f * stretch;
                m_NotePosition.z += Mathf.Cos((360 / swipeLength) * i) * 0.25f;
            }
            else
            {
                m_NotePosition.z += 0.2f * stretch;
            }

            // Instantiate first and last note
            if (i == 0 || i == swipeLength - 1)
            {
                print("Spawn note");
                swipeNotes[i] = Instantiate(note, m_NotePosition, Quaternion.identity, transform);
            }

            // Instantiate notes in between
            if (i != 0 && i != swipeLength - 1)
            {
                print("Spawn arrow");
                swipeNotes[i] = Instantiate(arrow, m_NotePosition, Quaternion.identity, transform);
            }

            swipeNotes[i].GetComponent<Collider>().enabled = false;
        }

        // Enable first swipe note's collider, and color it
        swipeNotes[0].GetComponent<Collider>().enabled = true;

        // transform.eulerAngles = new Vector3(0, -138, 0);
    }

    void Update()
    {
        // First element of the array is the only note with collider enabled
        // After first element has been triggered, enable collider of next element
        for (int i = 0; i < swipeLength; i++)
        {
            if (transform.GetChild(i).gameObject.GetComponent<Animator>().GetBool("IsTouched") && i < swipeLength - 1) // Exclude the last one to prevent out of bounds error
            {
                transform.GetChild(i + 1).GetComponent<Collider>().enabled = true;
            }
        }

        
    }
}
