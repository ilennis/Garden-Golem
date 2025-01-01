using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GrowthManager : MonoBehaviour
{

    public GameObject pebbleModel, rockModel, boulderModel, golemModel;
    public GameObject sproutModel, budModel, flowerModel, ripenedModel;

    private int golemStage = 0; // 0: Pebble, 1: Rock, 2: Boulder, 3: Golem
    private int plantStage = 0; // 0: Sprout, 1: Bud, 2: Flower, 3: Ripened

    public void UpdateGrowth(float plantHealth, float golemHealth)
    {
        // Example: Update rock growth stage
        if (golemHealth > 75)
        {
            pebbleModel.SetActive(false);
            rockModel.SetActive(true);
        }

        // Example: Update plant growth stage
        if (plantHealth > 75)
        {
            sproutModel.SetActive(false);
            budModel.SetActive(true);
        }
    }
    public void AdvanceGolemStage(float golemHealth)
    {
        golemStage++;
        if (golemStage > 3) golemStage = 3; // Max stage is Golem

        // Update model based on health
        UpdateGolemModel(golemHealth);
    }

    public void AdvancePlantStage(float plantHealth)
    {
        plantStage++;
        if (plantStage > 3) plantStage = 3; // Max stage is Ripened

        // Update model based on health
        UpdatePlantModel(plantHealth);
    }

    private void UpdateGolemModel(float golemHealth)
    {
        // Deactivate all models
        pebbleModel.SetActive(false);
        rockModel.SetActive(false);
        boulderModel.SetActive(false);
        golemModel.SetActive(false);

        // Activate model based on stage and health
        if (golemStage == 0) pebbleModel.SetActive(true);
        else if (golemStage == 1) rockModel.SetActive(true);
        else if (golemStage == 2) boulderModel.SetActive(true);
        else golemModel.SetActive(true);

        Debug.Log($"Golem advanced to stage {golemStage} with health {golemHealth}.");
    }

    private void UpdatePlantModel(float plantHealth)
    {
        // Deactivate all models
        sproutModel.SetActive(false);
        budModel.SetActive(false);
        flowerModel.SetActive(false);
        ripenedModel.SetActive(false);

        // Activate model based on stage and health
        if (plantStage == 0) sproutModel.SetActive(true);
        else if (plantStage == 1) budModel.SetActive(true);
        else if (plantStage == 2) flowerModel.SetActive(true);
        else ripenedModel.SetActive(true);

        Debug.Log($"Plant advanced to stage {plantStage} with health {plantHealth}.");
    }


}
