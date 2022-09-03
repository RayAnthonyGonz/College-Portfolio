using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class SupplyBar : MonoBehaviour
{

    public Slider slider;
    public Gradient gradient;
    public Image fill;

    public void SetMaxSupply(int supply)
    {
        slider.maxValue = supply;
        slider.value = supply;

        fill.color = gradient.Evaluate(1f);
    }

    public void SetSupply(int supply)
    {
        slider.value = supply;

        fill.color = gradient.Evaluate(slider.normalizedValue);
    }
}
