using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NoteController : MonoBehaviour
{
    Renderer m_Renderer;
    Material m_Material;
    Animator m_Animator;

    Color32 lerpedColor;
    Color32 touchColor = Color.white;

    void Start()
    {
        m_Renderer = GetComponent<Renderer>();
        m_Material = m_Renderer.material;
        m_Animator = GetComponent<Animator>();

        lerpedColor = m_Renderer.material.color;
    }

    private void OnTriggerEnter(Collider other)
    {
        // m_Animator.SetBool("IsTouched", true);


        if (other.gameObject.CompareTag("Hand"))
        {
            // Touched with which hand?
            switch (other.gameObject.name)
            {
                case "LeftHandAnchor":
                    OVRInput.SetControllerVibration(0.5f, 1f, OVRInput.Controller.LTouch);
                    break;
                case "RightHandAnchor":
                    OVRInput.SetControllerVibration(0.5f, 1f, OVRInput.Controller.RTouch);
                    break;
            }
        }
    }

    /*private void OnTriggerStay(Collider other)
    {
        while (transform.localScale.magnitude > 0)
        {
            transform.localScale -= new Vector3(Time.deltaTime, Time.deltaTime, Time.deltaTime);
            switch (other.gameObject.name)
            {
                case "LeftHandAnchor":
                    OVRInput.SetControllerVibration(0.7f, 1f, OVRInput.Controller.LTouch);
                    break;
                case "RightHandAnchor":
                    OVRInput.SetControllerVibration(0.7f, 1f, OVRInput.Controller.RTouch);
                    break;
            }
            lerpedColor = Color32.Lerp(lerpedColor, touchColor, Time.time);
            
        }

        Destroy(gameObject);


    }
    */
}
