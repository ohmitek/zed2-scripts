using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class FindHand : MonoBehaviour
{
    public Slider handYSlider; // Public reference to the Slider component
    public TimeManager timeManager; // Reference to the TimeManager script

    // Define the minimum and maximum angles for normalization
    public float minAngle = -90f;
    public float maxAngle = 90f;

    // Define the middle value for normalization
    private float middleAngle;

    // Define the smoothing factor
    public float smoothSpeed = 0.1f;

    // Define a variable to hold the target value for smoothing
    private float targetAngle;

    // Define a threshold for how close the slider needs to be to the extremes to trigger time change
    public float threshold = 0.05f; // Adjust this value as needed

    void Start()
    {
        // Calculate the middle value
        middleAngle = (minAngle + maxAngle) / 2f;
    }

    void Update()
    {
        // Try to find the GameObjects with the tags "shoulder" and "hand"
        GameObject shoulderObject = GameObject.FindGameObjectWithTag("shoulder");
        GameObject handObject = GameObject.FindGameObjectWithTag("hand");

        // Check if both GameObjects were found
        if (shoulderObject != null && handObject != null)
        {
            // Get the y positions of the shoulder and hand GameObjects
            float shoulderY = shoulderObject.transform.position.y;
            float handY = handObject.transform.position.y;

            // Calculate the angle between the shoulder and hand positions
            float angle = Mathf.Atan2(handY - shoulderY, 1) * Mathf.Rad2Deg;

            // Set the target value of the slider based on the sign of the angle
            if (angle > 0)
            {
                targetAngle = 1f; // Slider goes up
            }
            else
            {
                targetAngle = 0f; // Slider goes down
            }

            // Smoothly move the slider towards the target value
            handYSlider.value = Mathf.Lerp(handYSlider.value, targetAngle, smoothSpeed * Time.deltaTime);

            // If the slider is near fully up or fully down, change the time of day
            if (handYSlider.value >= 1f - threshold || handYSlider.value <= threshold)
            {
                // Calculate the time of day based on the position of the slider
                float timeOfDay = handYSlider.value * 24f;

                // Set the hours in the TimeManager script based on the time of day
                timeManager.Hours = Mathf.RoundToInt(timeOfDay);
            }
        }
        else
        {
            Debug.Log("Shoulder or hand not found.");
        }
    }
}





//using System.Collections;
//using System.Collections.Generic;
//using UnityEngine;
//using UnityEngine.UI; // Include this namespace to use UI components

//public class FindHand : MonoBehaviour
//{
//    public Slider handYSlider; // Public reference to the Slider component

//    // Define the minimum and maximum angles for normalization
//    public float minAngle = -90f;
//    public float maxAngle = 90f;

//    // Define the middle value for normalization
//    private float middleAngle;

//    // Define the smoothing factor
//    public float smoothSpeed = 0.1f;

//    // Define a variable to hold the target value for smoothing
//    private float targetAngle;

//    void Start()
//    {
//        // Calculate the middle value
//        middleAngle = (minAngle + maxAngle) / 2f;
//    }

//    // Update is called once per frame
//    void Update()
//    {
//        // Try to find the GameObjects with the tags "shoulder" and "hand"
//        GameObject shoulderObject = GameObject.FindGameObjectWithTag("shoulder");
//        GameObject handObject = GameObject.FindGameObjectWithTag("hand");

//        // Check if both GameObjects were found
//        if (shoulderObject != null && handObject != null)
//        {
//            // Get the y positions of the shoulder and hand GameObjects
//            float shoulderY = shoulderObject.transform.position.y;
//            float handY = handObject.transform.position.y;

//            // Calculate the angle between the shoulder and hand positions
//            float angle = Mathf.Atan2(handY - shoulderY, 1) * Mathf.Rad2Deg;

//            // Log the calculated angle to the debug log
//            Debug.Log("Angle between shoulder and hand: " + angle);

//            // Set the target value of the slider based on the sign of the angle
//            if (angle > 0)
//            {
//                targetAngle = 1f; // Slider goes up
//            }
//            else
//            {
//                targetAngle = 0f; // Slider goes down
//            }

//            // Smoothly move the slider towards the target value
//            handYSlider.value = Mathf.Lerp(handYSlider.value, targetAngle, smoothSpeed * Time.deltaTime);
//        }
//        else
//        {
//            Debug.Log("Shoulder or hand not found.");
//        }
//    }
//}



//using System.Collections;
//using System.Collections.Generic;
//using UnityEngine;
//using UnityEngine.UI; // Include this namespace to use UI components

//public class FindHand : MonoBehaviour
//{
//    public Slider handYSlider; // Public reference to the Slider component

//    // Define the minimum and maximum angles for normalization
//    public float minAngle = -90f;
//    public float maxAngle = 90f;

//    // Define the middle value for normalization
//    private float middleAngle;

//    // Define the smoothing factor
//    public float smoothSpeed = 0.1f;

//    // Define a variable to hold the target value for smoothing
//    private float targetAngle;

//    void Start()
//    {
//        // Calculate the middle value
//        middleAngle = (minAngle + maxAngle) / 2f;
//    }

//    // Update is called once per frame
//    void Update()
//    {
//        // Try to find the GameObjects with the tags "shoulder" and "hand"
//        GameObject shoulderObject = GameObject.FindGameObjectWithTag("shoulder");
//        GameObject handObject = GameObject.FindGameObjectWithTag("hand");

//        // Check if both GameObjects were found
//        if (shoulderObject != null && handObject != null)
//        {
//            // Get the y positions of the shoulder and hand GameObjects
//            float shoulderY = shoulderObject.transform.position.y;
//            float handY = handObject.transform.position.y;

//            // Calculate the angle between the shoulder and hand positions
//            float angle = Mathf.Atan2(handY - shoulderY, 1) * Mathf.Rad2Deg;

//            // Log the calculated angle to the debug log
//            Debug.Log("Angle between shoulder and hand: " + angle);

//            // Normalize the angle between -90 and 90 degrees
//            float normalizedAngle = Mathf.InverseLerp(minAngle, maxAngle, angle);

//            // Smoothly move the slider towards the normalized angle
//            handYSlider.value = Mathf.Lerp(handYSlider.value, normalizedAngle, smoothSpeed * Time.deltaTime);
//        }
//        else
//        {
//            Debug.Log("Shoulder or hand not found.");
//        }
//    }
//}





//using System.Collections;
//using System.Collections.Generic;
//using UnityEngine;
//using UnityEngine.UI; // Include this namespace to use UI components

//public class FindHand : MonoBehaviour
//{
//    public Slider handYSlider; // Public reference to the Slider component

//    // Define the minimum and maximum angles for normalization
//    public float minAngle = -90f;
//    public float maxAngle = 90f;

//    // Define the middle value for normalization
//    private float middleAngle;

//    // Define the smoothing factor
//    public float smoothSpeed = 0.1f;

//    // Define a variable to hold the target value for smoothing
//    private float targetAngle;

//    void Start()
//    {
//        // Calculate the middle value
//        middleAngle = (minAngle + maxAngle) / 2f;
//    }

//    // Update is called once per frame
//    void Update()
//    {
//        // Try to find the GameObject with the tag "hand"
//        GameObject handObject = GameObject.FindGameObjectWithTag("hand");

//        // Check if the GameObject was found
//        if (handObject != null)
//        {
//            // Get the rotation of the hand GameObject in world space
//            Quaternion handRotation = handObject.transform.rotation;

//            // Convert the rotation to euler angles
//            Vector3 handEulerAngles = handRotation.eulerAngles;

//            // Calculate the angle around the X-axis (pitch) to determine if the hand is up or down
//            float handAngle = handEulerAngles.x;
//            if (handAngle > 180f)
//            {
//                handAngle -= 360f;
//            }

//            // Log the hand angle to the debug log
//            Debug.Log("Hand Angle: " + handAngle);

//            // Set the target value of the slider based on the hand angle
//            if (handAngle > 50f)
//            {
//                targetAngle = 1f; // Slider goes up
//            }
//            else if (handAngle < -50f)
//            {
//                targetAngle = 0f; // Slider goes down
//            }
//            else
//            {
//                // Calculate a normalized value between 0 and 1 based on the hand angle
//                float normalizedValue = Mathf.InverseLerp(-50f, 50f, handAngle);
//                targetAngle = normalizedValue; // Set the target angle based on normalization
//            }

//            // Smoothly move the slider towards the target value
//            handYSlider.value = Mathf.Lerp(handYSlider.value, targetAngle, smoothSpeed * Time.deltaTime);
//        }
//        else
//        {
//            Debug.Log("Hand not found.");
//        }
//    }
//}




//using System.Collections;
//using System.Collections.Generic;
//using UnityEngine;
//using UnityEngine.UI; // Include this namespace to use UI components

//public class FindHand : MonoBehaviour
//{
//    public Slider handYSlider; // Public reference to the Slider component

//    // Define the minimum and maximum angles for normalization
//    public float minAngle = -90f;
//    public float maxAngle = 90f;

//    // Define the middle value for normalization
//    private float middleAngle;

//    // Define the smoothing factor
//    public float smoothSpeed = 0.1f;

//    // Define a variable to hold the target value for smoothing
//    private float targetAngle;

//    void Start()
//    {
//        // Calculate the middle value
//        middleAngle = (minAngle + maxAngle) / 2f;
//    }

//    // Update is called once per frame
//    void Update()
//    {
//        // Try to find the GameObject with the tag "hand"
//        GameObject handObject = GameObject.FindGameObjectWithTag("hand");

//        // Check if the GameObject was found
//        if (handObject != null)
//        {
//            // Get the rotation of the hand GameObject in world space
//            Quaternion handRotation = handObject.transform.rotation;

//            // Convert the rotation to euler angles
//            Vector3 handEulerAngles = handRotation.eulerAngles;

//            // Calculate the angle around the X-axis (pitch) to determine if the hand is up or down
//            float handAngle = handEulerAngles.x;
//            if (handAngle > 180f)
//            {
//                handAngle -= 360f;
//            }

//            // Log the hand angle to the debug log
//            Debug.Log("Hand Angle: " + handAngle);

//            // Set the target value of the slider based on the hand angle
//            if (handAngle > 50f)
//            {
//                targetAngle = 1f; // Slider goes up
//            }
//            else if (handAngle < -50f)
//            {
//                targetAngle = 0f; // Slider goes down
//            }
//            else
//            {
//                targetAngle = 0.5f; // Slider stays in the middle
//            }

//            // Smoothly move the slider towards the target value
//            handYSlider.value = Mathf.Lerp(handYSlider.value, targetAngle, smoothSpeed * Time.deltaTime);
//        }
//        else
//        {
//            Debug.Log("Hand not found.");
//        }
//    }
//}




//using System.Collections;
//using System.Collections.Generic;
//using UnityEngine;
//using UnityEngine.UI; // Include this namespace to use UI components

//public class FindHand : MonoBehaviour
//{
//    public Slider handYSlider; // Public reference to the Slider component

//    // Define the minimum and maximum angles for normalization
//    public float minAngle = -90f;
//    public float maxAngle = 90f;

//    // Define the middle value for normalization
//    private float middleAngle;

//    // Define the smoothing factor
//    public float smoothSpeed = 0.1f;

//    // Define a variable to hold the target value for smoothing
//    private float targetAngle;

//    void Start()
//    {
//        // Calculate the middle value
//        middleAngle = (minAngle + maxAngle) / 2f;
//    }

//    // Update is called once per frame
//    void Update()
//    {
//        // Try to find the GameObject with the tag "hand"
//        GameObject handObject = GameObject.FindGameObjectWithTag("hand");

//        // Check if the GameObject was found
//        if (handObject != null)
//        {
//            // Get the rotation of the hand GameObject in world space
//            Quaternion handRotation = handObject.transform.rotation;

//            // Convert the rotation to euler angles
//            Vector3 handEulerAngles = handRotation.eulerAngles;

//            // Calculate the angle around the X-axis (pitch) to determine if the hand is up or down
//            float handAngle = handEulerAngles.x;
//            if (handAngle > 180f)
//            {
//                handAngle -= 360f;
//            }

//            // Log the hand angle to the debug log
//            Debug.Log("Hand Angle: " + handAngle);

//            // Normalize the hand angle to match the slider range
//            float normalizedAngle = Mathf.InverseLerp(minAngle, maxAngle, handAngle);
//            normalizedAngle = Mathf.Clamp01(normalizedAngle);

//            // Smoothly move the slider towards the normalized angle value
//            targetAngle = normalizedAngle;
//            handYSlider.value = Mathf.Lerp(handYSlider.value, targetAngle, smoothSpeed * Time.deltaTime);
//        }
//        else
//        {
//            Debug.Log("Hand not found.");
//        }
//    }
//}




//using System.Collections;
//using System.Collections.Generic;
//using UnityEngine;
//using UnityEngine.UI; // Include this namespace to use UI components

//public class FindHand : MonoBehaviour
//{
//    public Slider handYSlider; // Public reference to the Slider component

//    // Define the minimum and maximum Y-axis values for normalization
//    public float minY = 0f;
//    public float maxY = 1f;

//    // Define the middle value for normalization
//    private float middleY;

//    // Define the smoothing factor
//    public float smoothSpeed = 0.1f;

//    // Define a variable to hold the target value for smoothing
//    private float targetY;

//    void Start()
//    {
//        // Calculate the middle value
//        middleY = (minY + maxY) / 2f;
//    }

//    // Update is called once per frame
//    void Update()
//    {
//        // Try to find the GameObject with the tag "hand"
//        GameObject handObject = GameObject.FindGameObjectWithTag("hand");

//        // Check if the GameObject was found
//        if (handObject != null)
//        {
//            // Get the Y-axis value of the hand GameObject
//            float handY = handObject.transform.position.y;
//            Debug.Log("Hand Y-axis value: " + handY);

//            // Normalize the hand Y-axis value to match the slider range
//            float normalizedY = Mathf.InverseLerp(minY, maxY, handY);
//            normalizedY = Mathf.Clamp01(normalizedY);

//            // Smoothly move the slider towards the normalized Y-axis value
//            targetY = normalizedY;
//            handYSlider.value = Mathf.Lerp(handYSlider.value, targetY, smoothSpeed * Time.deltaTime);
//        }
//        else
//        {
//            Debug.Log("Hand not found.");
//        }
//    }
//}