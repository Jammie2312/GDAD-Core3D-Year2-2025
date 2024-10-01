using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ManaPotion : Item
{
    public int manaRestoreAmount;
    public int maxManaRestoreAmount = 50;
    public int minManaRestoreAmount = 20;

    public ManaPotion()
    {
        itemName = "Mana Potion";
        description = "A potion that restores mana.";
    }

    private void Start()
    {
        manaRestoreAmount = Random.Range(minManaRestoreAmount, maxManaRestoreAmount);
        Debug.Log($"ManaPotion: Random restore amount set to {manaRestoreAmount}.");
    }

    public override void DisplayInfo()
    {
        Debug.Log($"{itemName}: Restores {manaRestoreAmount} mana points.");
    }
}
