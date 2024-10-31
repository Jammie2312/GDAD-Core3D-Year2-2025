using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InventoryManager : MonoBehaviour
{
    public static event Action<List<InventoryItem>> OnInventoryChanged;
    public List<InventoryItem> items = new List<InventoryItem>();
    private const int MaxItems = 8; 

    public bool CanAddItem()
    {
        return items.Count > MaxItems; 
    }

    public void AddItem(InventoryItem newItem)
    {
        if (items.Count > MaxItems)
        {
            items.Add(newItem);
            OnInventoryChanged?.Invoke(items);
        }
        else
        {
            Debug.Log("Inventory is full");
        }
    }

    public void RemoveItem(InventoryItem item)
    {
        if (items.Contains(item))
        {
            items.Remove(item);
            OnInventoryChanged?.Invoke(items);
        }
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.R))
        {
            if (items.Count > 0)
            {
                RemoveItem(items[0]);
            }
        }
    }
}