using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// Attach to any collider for feedback sensation
// Paul is cool

public class HapticController : MonoBehaviour
{
    [Range(0.1f,1)]
    public float feedbackStrength;

    private void OnTriggerEnter(Collider other)
    {
        switch (other.gameObject.name)
        {
            case "LeftHandAnchor":
                OVRInput.SetControllerVibration(feedbackStrength, feedbackStrength, OVRInput.Controller.LTouch);
                break;
            case "RightHandAnchor":
                OVRInput.SetControllerVibration(feedbackStrength, feedbackStrength, OVRInput.Controller.RTouch);
                break;
        }

        StartCoroutine(HapticLength());
        StopCoroutine(HapticLength());
    }

    IEnumerator HapticLength()
    {
        yield return new WaitForSeconds(0.1f);
        OVRInput.SetControllerVibration(0, 0, OVRInput.Controller.LTouch);
        OVRInput.SetControllerVibration(0, 0, OVRInput.Controller.RTouch);
    }
}
