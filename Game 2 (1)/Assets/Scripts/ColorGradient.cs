using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ColorGradient : MonoBehaviour
{
    public Gradient colorGrad;
    float colorCycle;

    Light lightColor;
    
    // Start is called before the first frame update
    void Start()
    {
        lightColor = GetComponent<Light>(); 
    }

    // Update is called once per frame
    void Update()
    {
        colorCycle += 0.005f;
        if (colorCycle >= 1)
        {
            colorCycle = 0;
            
        }

        lightColor.color = colorGrad.Evaluate(colorCycle);

    }
}
