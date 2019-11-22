using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BuildingWindows : MonoBehaviour
{

    public GameObject building;
    public GameObject window;
    public float xPos, xPos1, xPos2, yPos, yPos1, yPos2, zPos;

    // Start is called before the first frame update
    void Start()
    {
        //each of the xPos and yPos values can be modified depending on size/scale of the buildings
        xPos1 = -0.257f;
        xPos2 = 0.026f;
        yPos1 = 0.4478f;
        yPos2 = 0.396f;
        xPos = xPos2 - xPos1; //difference of x-pos of windows
        xPos = -0.257f;
        yPos = yPos2 - yPos1; //difference of y-pos of windows
        zPos = -0.507f;

        for (float i = yPos1; i < transform.localScale.y; i++) //3 rows
        {
            i += yPos;
            for (float j = xPos1; j < transform.localScale.x; j++) //3 columns 
            {
                j += xPos;
                Vector3 position = new Vector3(xPos1 + j, yPos1 + i, zPos);
                Instantiate(window, position, Quaternion.identity, transform);

            }
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
