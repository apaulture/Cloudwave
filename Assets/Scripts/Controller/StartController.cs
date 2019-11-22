using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class StartController : MonoBehaviour
{
    public GameObject audioController;
    public GameObject audioDelay;
    public GameObject gameBoundary;
    public GameObject boundaryLight;
    Animator m_Animator;
    
    void Start()
    {
        m_Animator = GetComponent<Animator>();
        m_Animator.SetBool("IsStartButton", true);
    }

    private void OnTriggerEnter(Collider other)
    {
        //if (other.gameObject.name == "LeftHandAnchor" || other.gameObject.name == "RightHandAnchor")
        {
            // Start music
            audioController.SetActive(true);
            audioDelay.SetActive(true);

            // Activate dance ring and aura
            boundaryLight.SetActive(true);
            gameBoundary.GetComponent<Renderer>().material.SetColor("_EmissionColor", new Color(0, 0.952941176470588f, 0.145098039215686f));

            // Start button touched animation
            m_Animator.SetBool("IsTouched", true);
            StartCoroutine(SetInactiveAfterTouching());
        }
            
    }

    IEnumerator SetInactiveAfterTouching()
    {
        yield return new WaitForSeconds(0.75f);
        gameObject.SetActive(false);
    }
}
