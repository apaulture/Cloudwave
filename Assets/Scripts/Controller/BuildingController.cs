using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BuildingController : MonoBehaviour
{
    public GameObject building;

    GameObject spawnedBuilding;
    Vector3 buildingScale;
    float heightDistanceScale;

    float xPos, zPos, xScale, zScale, distanceFromCenter;

    // Start is called before the first frame update
    void Start()
    {
        for (int i = 1; i < 300; i++)
        {
            // Randomize position of buildings
            xPos = Random.Range(-160f, 160f);
            zPos = Random.Range(-160f, 160f);

            // about 28 to approx 254 is max distance from center for -180 to 180
            // We want to multiply yScale by about 1-4, so, 254-28 / 4, increment by every ~56
            // Multiply by highest scale factor for buildings CLOSEST to the rooftop
            distanceFromCenter = distance(xPos, zPos);
            heightDistanceScale = 1/distanceFromCenter * 120f; // Inverse proportionality
                // 1 = 254
                // 4 = 28

            // Randomize building scale
            xScale = Random.Range(4f, 4f);
            float yScale = Random.Range(25f, 40f) * heightDistanceScale;
            zScale = Random.Range(4f, 4f);
            buildingScale = new Vector3(xScale, yScale, zScale);

            // The rooftop building is 30m tall, so subtract about 30 from half of scale to achieve the correct height from world ground
            float height = (yScale / 2f) - 30f;

            
            Vector3 position = new Vector3(xPos, height, zPos);

            spawnedBuilding = Instantiate(building, position, Quaternion.identity, transform);
            spawnedBuilding.transform.localScale += buildingScale;
        }
    }

    float distance(float x, float z)
    {
        return Mathf.Sqrt(x * x + z * z);
    }
}
