using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HealthBar : MonoBehaviour
{
    public Slider slider;

    public void FixedUpdate()
    {
        slider.value = PlayerController.currentHealth;
    } 
}
