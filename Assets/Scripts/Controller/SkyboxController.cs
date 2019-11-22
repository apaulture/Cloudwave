using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SkyboxController : MonoBehaviour
{
    public Color color;
    public Color transitionColor;
    public Color sunsetColor;
    float lerpValue;
    float time;
    bool firstTransition;

    Color lerpColor;

    // Start is called before the first frame update
    void Start()
    {
        RenderSettings.skybox.SetColor("_Tint", color);
    }

    // Update is called once per frame
    void Update()
    {
        if (TriggerSun.sunTriggered)
        {
            time += Time.deltaTime;
            lerpValue += Time.deltaTime * 0.1f; 
            lerpColor = Color.Lerp(color, sunsetColor, lerpValue);
            
            
            RenderSettings.skybox.SetColor("_Tint", lerpColor);
        }
        
    }


}
