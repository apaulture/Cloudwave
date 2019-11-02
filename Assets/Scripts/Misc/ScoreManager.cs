using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class ScoreManager : MonoBehaviour
{
    private static ScoreManager _instance;
    public static ScoreManager Instance { get { return _instance; } }

    [SerializeField]
    private int pointMax;
    private int currentPointTotal;
    [SerializeField]
    private ScoreCounter scoreCounter;


    public void addPoint()
    {
        currentPointTotal++;
        scoreCounter.progress = (float)currentPointTotal / (float) pointMax;
    }

    private void Awake()
    {
        if (_instance != null && _instance != this)
        {
            Destroy(this.gameObject);
        }
        else
        {
            _instance = this;
        }
    }
}
