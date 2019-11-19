using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MotionNoteController : MonoBehaviour
{
    public float speed = 3.3f;
    Vector3 direction;

    private void Start()
    {
        direction = -transform.parent.transform.forward;
    }

    void FixedUpdate()
    {
        transform.Translate(direction * Time.fixedDeltaTime * speed);
    }
    
}
