using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InputManager : MonoBehaviour
{
    public int waterCount = 0;
    public int playCount = 0;
    public int trimCount = 0;
    public int magicCount = 0;

    public GameManager gm;

    void TrackInteraction(string interactionType)
    {
        switch (interactionType)
        {
            case "Water":
                waterCount++;
                break;
            case "Play":
                playCount++;
                break;
            case "Trim":
                trimCount++;
                break;
            case "Magic":
                magicCount++;
                break;
        }
    }

    // Player Interaction.
    public void WaterGolem()
    {
        gm.moisture += 10f;
        Debug.Log("Watered the golem!");
        TrackInteraction("Water");
    }

    public void PlayWithGolem()
    {
        gm.golemHealth += 10f;
        Debug.Log("Played with the golem!");
        TrackInteraction("Play");
    }

    public void TrimPlant()
    {
        
        gm.plantHealth = Mathf.Max(gm.plantHealth - 5f, 0);
        Debug.Log("Trimmed the plant! Excess health reduced.");
        TrackInteraction("Trim");
    }

    public void UseMagic()
    {
        gm.plantHealth = Mathf.Min(gm.plantHealth + 20f, 100f);
        gm.golemHealth = Mathf.Min(gm.golemHealth + 20f, 100f);
        Debug.Log("Used magic! Both plant and golem health restored.");
        TrackInteraction("Magic");
    }
}
