using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnControllerTest : MonoBehaviour
{
    public GameObject[] note = new GameObject[3];

    // [SerializeField] Sound

    public int[] numberOfNotes;
    public Vector3[] positions;

    public enum Note { Tap, Swipe, Hold };
    public Note[] noteType;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
