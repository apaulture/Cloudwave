using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SkyboxController : MonoBehaviour
{
    public Color color;
    public Color sunsetColor;
    float lerpValue;

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
            lerpValue += Time.deltaTime * 0.1f;
            lerpColor = Color.Lerp(color, sunsetColor, lerpValue);
            RenderSettings.skybox.SetColor("_Tint", lerpColor);
        }
        
    }
}
