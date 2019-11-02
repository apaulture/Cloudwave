using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawner : MonoBehaviour
{
    public GameObject temp;
    public Vector3 staticNoteVelocity;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void spawnNote(Vector3 displacement)
    {
        Note note = Instantiate(temp, gameObject.GetComponent<Transform>().position + displacement, new Quaternion()).GetComponent<Note>();
        note.setVelocity(staticNoteVelocity);
    }
}
