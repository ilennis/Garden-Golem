using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIManager : MonoBehaviour
{
    public Text golemHealthText;
    public Text plantHealthText;
    public Text moistureText;
    public Text golemGrowthText;
    public Text plantGrowthText;
    public Text notificationText;

    public Slider golemHealthSlider;
    public Slider plantHealthSlider;
    public Slider moistureSlider;
    //public Slider golemGrowthSlider;
    //public Slider plantGrowthSlider;

    public void UpdateUI(float golemHealth, float plantHealth, float moisture, float golemGrowth, float plantGrowth)
    {
        // Update text fields
        golemHealthText.text = $"Golem Health: {golemHealth}/100";
        plantHealthText.text = $"Plant Health: {plantHealth}/100";
        moistureText.text = $"Moisture: {moisture}/100";
        golemGrowthText.text = $"Golem Growth: {golemGrowth}%";
        plantGrowthText.text = $"Plant Growth: {plantGrowth}%";

        // Update sliders
        golemHealthSlider.value = golemHealth;
        plantHealthSlider.value = plantHealth;
        moistureSlider.value = moisture;
        //golemGrowthSlider.value = golemGrowth;
        //plantGrowthSlider.value = plantGrowth;
    }

    public void ShowNotification(string message)
    {
        notificationText.text = message;
    }
}
