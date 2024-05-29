using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BicepsPoseDetector : MonoBehaviour
{
    // Threshold angles to consider for a biceps pose
    public float minBicepsAngle = 30f; // Minimum angle between forearm and upper arm
    public float maxBicepsAngle = 90f; // Maximum angle between forearm and upper arm

    void Update()
    {
        // Try to find the GameObjects with the tags "shoulder", "forearm", and "hand"
        GameObject shoulderObject = GameObject.FindGameObjectWithTag("shoulder");
        GameObject forearmObject = GameObject.FindGameObjectWithTag("forearm");
        GameObject handObject = GameObject.FindGameObjectWithTag("hand");

        // Check if all three GameObjects were found
        if (shoulderObject != null && forearmObject != null && handObject != null)
        {
            // Get the positions of the shoulder, forearm, and hand
            Vector3 shoulderPos = shoulderObject.transform.position;
            Vector3 forearmPos = forearmObject.transform.position;
            Vector3 handPos = handObject.transform.position;

            // Calculate the vectors between the points
            Vector3 shoulderToForearm = forearmPos - shoulderPos;
            Vector3 forearmToHand = handPos - forearmPos;

            // Calculate the angle between the shoulder-to-forearm vector and the forearm-to-hand vector
            float angle = Vector3.Angle(shoulderToForearm, forearmToHand);

            // Log the angle for debugging
            //Debug.Log("Angle between shoulder, forearm, and hand: " + angle);

            // Check if the angle is within the range for a biceps pose
            if (angle >= minBicepsAngle && angle <= maxBicepsAngle)
            {
                Debug.Log("Biceps pose detected!");
            }
        }
        else
        {
            Debug.Log("Shoulder, forearm, or hand not found.");
        }
    }
}
