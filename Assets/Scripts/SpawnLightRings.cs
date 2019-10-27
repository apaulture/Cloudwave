using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnLightRings : MonoBehaviour
{
    public GameObject lightRing;
    public GameObject elevator;
    
    void Start()
    {
        for (int i = 10; i < elevator.transform.localScale.y * 2; i+=5)
        {
            Vector3 position = transform.position;
            position.y += i;
            Instantiate(lightRing, position, Quaternion.identity, transform);
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
