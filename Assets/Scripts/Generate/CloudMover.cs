using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CloudMover : MonoBehaviour
{
    int randomInt;
    //private Transform transform;

    // Start is called before the first frame update
    void Start()
    {
        //transform = gameObject.GetComponent<Transform>();
        randomInt = Random.Range(1, 5);
    }

    // Update is called once per frame
    void Update()
    {
        switch (randomInt)
        {
            case 1:
                transform.Rotate(new Vector3(0f, 0.0025f, 0f));
                break;
            case 2:
                transform.Rotate(new Vector3(0f, -0.0025f, 0f));
                break;
            case 3:
                transform.Rotate(new Vector3(0f, 0.0035f, 0f));
                break;
            case 4:
                transform.Rotate(new Vector3(0f, -0.0035f, 0f));
                break;

        }
        
    }
}
