using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MotionNoteController : MonoBehaviour
{
    public float speed = 3.3f;
    Vector3 direction;
    Vector3 arrowDirection;

    private void Start()
    {
        direction = -transform.parent.transform.forward;
        arrowDirection = -transform.parent.transform.up + new Vector3(0,0,0.3f);
    }

    void FixedUpdate()
    {
        if (gameObject.name == "Tap(Clone)")
        {
            transform.Translate(direction * Time.fixedDeltaTime * speed);
        }

        if (gameObject.name == "Body(Clone)")
        {
            transform.Translate(arrowDirection * Time.fixedDeltaTime * speed);
        }
    }
    
}
