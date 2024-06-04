using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class LightChange : MonoBehaviour
{

    public Slider Temperature;

    public Light Light;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {


        // Calculate the color temperature based on the slider value
        float minTemperature = 1000f; // Minimum temperature (warmest color)
        float maxTemperature = 10000f; // Maximum temperature (coolest color)

        // Map the slider value (0 to 1) to the desired temperature range
        float colorTemperature = Mathf.Lerp(minTemperature, maxTemperature, Temperature.value);

        // Set the color temperature
        Light.colorTemperature = colorTemperature;
    }
}
