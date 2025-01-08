using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GrowthManager : MonoBehaviour
{
    public GameManager gm;
    public GameObject pebbleModel, rockModel, boulderModel, golemModel;
    public GameObject sproutModel, budModel, flowerModel, ripenedModel;

    private int golemStage = 0; // 0: Pebble, 1: Rock, 2: Boulder, 3: Golem
    private int plantStage = 0; // 0: Sprout, 1: Bud, 2: Flower, 3: Ripened

    public void UpdateGrowth(float plantGrowth, float golemGrowth)
    {
        // Example: Update plant growth stage
        if (plantGrowth >= 100)
        {
            AdvancePlantStage();
        }

        // Example: Update rock growth stage
        if (golemGrowth >= 100) // change this to advance when Golem Growth reaches 100%
        {
            AdvanceGolemStage();
        }

        
    }
    public void AdvanceGolemStage()
    {
        golemStage++;
        if (golemStage > 3) golemStage = 3; // Max stage is Golem

        // Update model based on health
        UpdateGolemModel();
    }

    public void AdvancePlantStage()
    {
        plantStage++;
        if (plantStage > 3) plantStage = 3; // Max stage is Ripened

        // Update model based on health
        UpdatePlantModel();
    }

    private void UpdateGolemModel()
    {
        // Deactivate all models
        pebbleModel.SetActive(false);
        rockModel.SetActive(false);
        boulderModel.SetActive(false);
        golemModel.SetActive(false);

        // Activate model based on stage and health
        switch (golemStage)
        {
            case 0:
                gm.rockState = RockGrowthState.Pebble;
                pebbleModel.SetActive(true);
                break;
            case 1:
                gm.rockState = RockGrowthState.Rock;
                rockModel.SetActive(true);
                break;
            case 2:
                gm.rockState = RockGrowthState.Boulder;
                boulderModel.SetActive(true);
                break;
            case 3:
                gm.rockState = RockGrowthState.Golem;
                golemModel.SetActive(true);
                break;

        }

        Debug.Log($"Golem advanced to stage {golemStage}.");
    }

    private void UpdatePlantModel()
    {
        // Deactivate all models
        sproutModel.SetActive(false);
        budModel.SetActive(false);
        flowerModel.SetActive(false);
        ripenedModel.SetActive(false);

        switch (plantStage)
        {
            case 0:
                gm.plantState = PlantGrowthState.Sprout;
                sproutModel.SetActive(true);
                break;
            case 1:
                gm.plantState = PlantGrowthState.Bud;
                budModel.SetActive(true);
                break;
            case 2:
                gm.plantState = PlantGrowthState.Flower;
                flowerModel.SetActive(true);
                break;
            case 3:
                gm.plantState = PlantGrowthState.Ripened;
                ripenedModel.SetActive(true);
                break;

        }

        Debug.Log($"Plant advanced to stage {plantStage}.");
    }


}
