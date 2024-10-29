using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "NewBonusItem", menuName = "Inventory/Bonus Item")]
public class BonusItem : InventoryItem
{
    public int bonusPoint;

    private void OnEnable()
    {
        itemType = ItemType.Bonus;
    }
}