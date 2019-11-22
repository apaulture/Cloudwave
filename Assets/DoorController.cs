using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DoorController : MonoBehaviour
{
    AudioSource m_AudioSource;
    bool touched;

    // Start is called before the first frame update
    void Start()
    {
        m_AudioSource = GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.name == "LeftHandAnchor" || other.gameObject.name == "RightHandAnchor")
        {
            GetComponent<Animator>().SetBool("DoorTouched", true);
            m_AudioSource.Play();
            GetComponent<Collider>().enabled = false;
        }
            
    }
}
