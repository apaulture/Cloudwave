using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// Attach this script to objects with collider and generated buildings won't spawn near the object (SetActive > false)

public class BoundaryController : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Building"))
        {
            other.gameObject.SetActive(false);
        }
    }
}
