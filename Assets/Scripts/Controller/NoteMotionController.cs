using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NoteMotionController : MonoBehaviour
{
    public float noteVelocity;
    public static float noteSpeed;
    
    void Start()
    {
        noteSpeed = noteVelocity;
    }

    void Update()
    {
        
    }
}
