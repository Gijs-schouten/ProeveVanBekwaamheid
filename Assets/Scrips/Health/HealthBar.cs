using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HealthBar : MonoBehaviour
{
    
    public Slider slider;

   //Function for MaxHealth so there's no need to edit in the inspector
    public void SetMaxHealth(int health)
    {
        slider.maxValue = health;
        slider.value = health;
    }

    //Set value of slider in the slider UI
    public void SetHealth(int health)
    {
        slider.value = health;
    }
    
}
