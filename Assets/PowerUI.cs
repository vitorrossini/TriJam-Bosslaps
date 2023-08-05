using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PowerUI : MonoBehaviour
{
   
    public Slider slider;
    public Gradient gradient;
    public Image fill;


    public void SetMaxPower(float power)
    {
        slider.maxValue = power;
        slider.value = power;

        fill.color = gradient.Evaluate(1f);
    }
    public void SetPower(float power)
    {
        slider.value = power;
        fill.color = gradient.Evaluate(slider.normalizedValue);
    }
}
