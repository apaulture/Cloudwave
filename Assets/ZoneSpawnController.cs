using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ZoneSpawnController : MonoBehaviour
{
    public GameObject note;

    // Start is called before the first frame update
    void Start()
    {
        Vector3 position = transform.position + (3 * transform.up);
        print(position);
        Instantiate(note, position, Quaternion.identity, gameObject.transform);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
