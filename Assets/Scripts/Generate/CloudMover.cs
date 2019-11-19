using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CloudMover : MonoBehaviour
{
    //private Transform transform;

    // Start is called before the first frame update
    void Start()
    {
        //transform = gameObject.GetComponent<Transform>();
    }

    // Update is called once per frame
    void Update()
    {
            transform.Rotate(new Vector3(0f, 0.0025f, 0f));
    }
}
