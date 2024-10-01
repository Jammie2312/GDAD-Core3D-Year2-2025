using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealthPotion : Item
{
    public int healthRestoreAmount;
    public int minRestoreAmount = 30;
    public int maxRestoreAmount = 70;

    public HealthPotion()
    {
        itemName = "Health Potion";
        description = "A potion that restores health.";
    }

    private void Start()
    {
        healthRestoreAmount = Random.Range(minRestoreAmount, maxRestoreAmount);
        Debug.Log($"HealthPotion: Random restore amount set to {healthRestoreAmount}.");
    }

    public override void DisplayInfo()
    {
        Debug.Log($"{itemName}: Restores {healthRestoreAmount} health points,");
    }
}
