using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HandsHorizontal : MonoBehaviour
{
    public Slider slider3; // Public reference to the Slider component for right hand horizontal movement

    // Define the minimum and maximum x positions for normalization
    public float minX = -1f;
    public float maxX = 1f;

    // Define the smoothing factor
    public float smoothSpeed = 0.1f;

    // Define a variable to hold the target value for smoothing
    private float targetX;

    void Update()
    {
        // Try to find the GameObjects with the tags "rightshoulder" and "righthand"
        GameObject shoulderObject = GameObject.FindGameObjectWithTag("rightshoulder");
        GameObject handObject = GameObject.FindGameObjectWithTag("righthand");

        // Check if both GameObjects were found
        if (shoulderObject != null && handObject != null)
        {
            // Get the x positions of the shoulder and hand GameObjects
            float shoulderX = shoulderObject.transform.position.x;
            float handX = handObject.transform.position.x;

            // Calculate the relative horizontal position of the hand to the shoulder
            float relativeX = handX - shoulderX;

            // Normalize the relativeX position to the range of the slider
            float normalizedX = Mathf.InverseLerp(minX, maxX, relativeX);

            // Set the target value for the slider based on the normalized x position
            targetX = Mathf.Clamp01(normalizedX);

            // Smoothly move the slider towards the target value
            slider3.value = Mathf.Lerp(slider3.value, targetX, smoothSpeed * Time.deltaTime);
        }
        else
        {
            Debug.Log("Right shoulder or hand not found.");
        }
    }
}
