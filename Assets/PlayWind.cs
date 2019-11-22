using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayWind : MonoBehaviour
{
    float volume;
    bool inZone;
    
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (inZone)
        {
            if (volume < 0.62f)
            {
                volume += Time.deltaTime * 0.142857142857143f;
                GetComponent<AudioSource>().volume = volume;
            }
            
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.name == "LeftHandAnchor" || other.gameObject.name == "RightHandAnchor")
        {
            inZone = true;

            GetComponent<AudioSource>().Play();


            GetComponent<Collider>().enabled = false;
        }
            
    }
}
