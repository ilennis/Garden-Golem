using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum RockGrowthState { Pebble, Rock, Boulder, Golem }
public enum PlantGrowthState { Sprout, Bud, Flower, Ripened }

public class GameManager : MonoBehaviour
{
    public GrowthManager growthManager;
    public InputManager inputManager;
    public DrainManager drainManager;
    public UIManager uiManager;

    public float plantHealth = 100f;
    public float golemHealth = 100f;
    public float moisture = 50f;

    public float plantGrowthProgress = 0f;
    public float golemGrowthProgress = 0f;

    public float decayRate = 0.1f; // Rate of variable decrease per second. Adjust. 
    public float maxHealth = 100f;
    public float maxMoisture = 100f;

    public float growthRate = 5f; // Growth progress rate per second
    public float maxGrowthProgress = 100f; // Threshold for stage transition

    public RockGrowthState rockState;
    public PlantGrowthState plantState;

    private void Awake()
    {
        rockState = RockGrowthState.Pebble;
        plantState = PlantGrowthState.Sprout;
    }


    void Update()
    {
        // Gradual decay for all variables
        plantHealth -= decayRate * Time.deltaTime;
        golemHealth -= decayRate * Time.deltaTime;
        moisture -= decayRate * Time.deltaTime;

        // Increment growth progress
        plantGrowthProgress += Time.deltaTime * growthRate;
        golemGrowthProgress += Time.deltaTime * growthRate;

        // Check for stage transitions
        if (plantGrowthProgress >= maxGrowthProgress)
        {
            growthManager.AdvancePlantStage();
            plantGrowthProgress = 0f;
        }

        if (golemGrowthProgress >= maxGrowthProgress)
        {
            growthManager.AdvanceGolemStage();
            golemGrowthProgress = 0f;
        }

        // Delegate Task to Other Scripts
        growthManager.UpdateGrowth(plantGrowthProgress, golemGrowthProgress);
        drainManager.DrainForPlantHealth(ref plantHealth, ref golemHealth, ref moisture);
        uiManager.UpdateUI(golemHealth, plantHealth, moisture, golemGrowthProgress, plantGrowthProgress, rockState, plantState);

        // Clamp values to prevent them from exceeding bounds. Don't go below zero. Don't go above Max Health.
        plantHealth = Mathf.Clamp(plantHealth, 0, maxHealth);
        golemHealth = Mathf.Clamp(golemHealth, 0, maxHealth);
        moisture = Mathf.Clamp(moisture, 0, maxMoisture);

        if (plantHealth <= 0 || golemHealth <= 0)
        {
            Debug.Log("Game Over! Plant or Golem has perished.");
        }
    }

      

}
