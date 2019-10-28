using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GenerateLightpoles : MonoBehaviour
{
    public GameObject lightpole;
    float xPos, yPos, zPos;
    GameObject spawnedLightpole;

    // Start is called before the first frame update
    void Start()
    {
        if (transform.localScale.y > 50)
        {
            Vector3 position = transform.position;


            position.y = transform.localScale.y / 2 + position.y + 0.5f;

            spawnedLightpole = Instantiate(lightpole, position, Quaternion.identity, transform);
            float xScale = lightpole.transform.localScale.x / transform.localScale.x;
            float yScale = lightpole.transform.localScale.y / transform.localScale.y;
            float zScale = lightpole.transform.localScale.z / transform.localScale.z;
            Vector3 scaledDown = new Vector3(xScale, yScale, zScale);
            spawnedLightpole.transform.localScale = scaledDown;
        }
        


        // Height is 50, position is -5, lightpole has to be at 20.5
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
