using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GenerateFloors : MonoBehaviour
{
    public GameObject floor;
    public int floorLength;

    Vector3 position;
    GameObject spawnedFloor;

    // Start is called before the first frame update
    void Start()
    {
        position = transform.position;
        for (float i = 0; i < floorLength; i++)
        {
            position.z = i / 10f;
            spawnedFloor = Instantiate(floor, position, Quaternion.identity, transform.parent);
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
