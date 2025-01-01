using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InputManager : MonoBehaviour
{
    public int waterCount = 0;
    public int playCount = 0;
    public int trimCount = 0;
    public int magicCount = 0;

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
    public void WaterGolem(ref float moisture)
    {
        moisture += 10f;
        Debug.Log("Watered the golem!");
        TrackInteraction("Water");
    }

    public void PlayWithGolem(ref float golemHealth)
    {
        golemHealth += 10f;
        Debug.Log("Played with the golem!");
        TrackInteraction("Play");
    }

    public void TrimPlant(ref float plantHealth)
    {
        
        plantHealth = Mathf.Max(plantHealth - 5f, 0);
        Debug.Log("Trimmed the plant! Excess health reduced.");
        TrackInteraction("Trim");
    }

    public void UseMagic(ref float plantHealth, ref float golemHealth)
    {
        plantHealth = Mathf.Min(plantHealth + 20f, 100f);
        golemHealth = Mathf.Min(golemHealth + 20f, 100f);
        Debug.Log("Used magic! Both plant and golem health restored.");
        TrackInteraction("Magic");
    }
}
