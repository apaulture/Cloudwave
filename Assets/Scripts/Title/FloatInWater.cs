using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FloatInWater : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter(Collider other)
    {
        other.gameObject.GetComponent<Rigidbody>().useGravity = false;
    }

    private void OnTriggerStay(Collider other)
    {
        
        other.gameObject.GetComponent<Rigidbody>().AddForce(Vector3.up * 0.35f);
    }

    private void OnTriggerExit(Collider other)
    {

        other.gameObject.GetComponent<Rigidbody>().useGravity = true;
        //other.gameObject.GetComponent<Rigidbody>().AddForce(Vector3.down * 0.35f);
    }
}
