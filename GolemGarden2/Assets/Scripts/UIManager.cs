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
    public Text rockStateText;
    public Text plantStateText;

    public Slider golemHealthSlider;
    public Slider plantHealthSlider;
    public Slider moistureSlider;
    //public Slider golemGrowthSlider;
    //public Slider plantGrowthSlider;

    public void UpdateUI(float golemHealth, float plantHealth, float moisture, float golemGrowth, float plantGrowth, RockGrowthState rockState, PlantGrowthState plantState)
    {
        // Update text fields
        golemHealthText.text = $"Golem Health: {Mathf.RoundToInt(golemHealth)}/100";
        plantHealthText.text = $"Plant Health: {Mathf.RoundToInt(plantHealth)}/100";
        moistureText.text = $"Moisture: {Mathf.RoundToInt(moisture)}/100";
        golemGrowthText.text = $"Golem Growth: {Mathf.RoundToInt(golemGrowth)}%";
        plantGrowthText.text = $"Plant Growth: {Mathf.RoundToInt(plantGrowth)}%";
        rockStateText.text = $"Golem Growth: {rockState}";
        plantStateText.text = $"Plant Growth: {plantState}";
        // Update sliders
        golemHealthSlider.value = golemHealth;
        plantHealthSlider.value = plantHealth;
        moistureSlider.value = moisture;
        //golemGrowthSlider.value = golemGrowth;
        //plantGrowthSlider.value = plantGrowth;
    }

    
}
