using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BuildingController : MonoBehaviour
{
    public GameObject building;
    GameObject spawnedBuilding;
    Vector3 buildingScale;

    // Start is called before the first frame update
    void Start()
    {
        for (int i = 1; i < 300; i++)
        {
            float yScale = Random.Range(5, 70);
            buildingScale = new Vector3(1, yScale, 1);
            float yPosition = (yScale / 2) - 30;


            float x = Random.Range(-65f, 65f);
            float z = Random.Range(-65f, 65f);
            Vector3 position = new Vector3(x, yPosition, z);

            spawnedBuilding = Instantiate(building, position, Quaternion.identity, transform);
            spawnedBuilding.transform.localScale += buildingScale;
            

            // Divide by 2 and minus 30 from height
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter(Collider other)
    {
        // other.gameObject.SetActive(false);
        if (other.gameObject.CompareTag("Building"))
        {
            other.gameObject.SetActive(false);
            
        }
    }
}
