using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Play : MonoBehaviour
{
    public void PlayGame()
    {
    SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }

   // public void OnTriggerEnter(Collider changeScene)
    //{
        //if(changeScene.gameObject.CompareTag("Player"))
        //{
            //SceneManager.LoadScene(1);
        //}
    //}
}
