using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GenerateWindows : MonoBehaviour
{
    public GameObject window;
    float xPos, yPos, zPos;
    // Start is called before the first frame update
    void Start()
    {
        // Range should be -1.5 to 1.5 for scale 4
        // Building margin is 0.5
        // Window margin is 0.25
        // Total margin is 1.5 out of 4, so 2.5 of space left, use 4 windows of 0.5, .5 of spacing in between
        
        for (float i = -0.4f; i <= 0.4f; i += 0.15f)
        {
            

            Vector3 position = new Vector3(i, -0.5f, 3);
            window.transform.localScale = new Vector3(0.1f, 0.01666667f, 0.2f);
            Instantiate(window, position, Quaternion.identity, transform);
        }
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
