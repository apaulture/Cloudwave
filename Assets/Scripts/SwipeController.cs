using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SwipeController : MonoBehaviour
{
    Collider m_ParentCollider;

    // Start is called before the first frame update
    void Start()
    {
        m_ParentCollider = GetComponentInParent<Collider>();
    }

    // Update is called once per frame
    void Update()
    {
        /*if (transform.GetChild(0).gameObject.activeSelf == false)
        {
            m_Collider.enabled = true;
        }
        */
    }

    private void OnTriggerEnter(Collider other)
    {
        print("Enable parent collider");
        m_ParentCollider.enabled = true;
    }
}
