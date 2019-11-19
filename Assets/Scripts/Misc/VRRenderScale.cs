using UnityEngine;
using UnityEngine.XR;

public class VRRenderScale : MonoBehaviour
{
    void Start()
    {
        XRSettings.eyeTextureResolutionScale = 1.1f;
    }
}