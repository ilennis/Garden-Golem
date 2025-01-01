using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DrainManager : MonoBehaviour
{
    public float drainRate = 0.5f;
    public float minimumThreshold = 40f;

    public void DrainForPlantHealth(ref float plantHealth, ref float golemHealth, ref float moisture)
    {
        if (golemHealth > minimumThreshold && moisture > minimumThreshold)
        {
            // if moisture and golem health is high, it will drain health to heal
            float drainAmount = drainRate * Time.deltaTime;
            golemHealth -= drainAmount;
            moisture -= drainAmount;
            plantHealth += drainAmount * 2;
            Debug.Log("Plant is draining resources to heal.");
        }
        else
        {
            // if below minimum Threshold, it won't heal
            Debug.Log("Insufficient resources for the plant to heal.");
        }
    }
}
