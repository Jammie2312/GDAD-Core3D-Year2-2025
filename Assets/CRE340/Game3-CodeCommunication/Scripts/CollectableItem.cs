using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CollectableItem : MonoBehaviour
{
    public InventoryItem itemData;

    private InventoryManager inventoryManager;

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            GameObject player = other.gameObject;
        }
        if (other.GetComponent<InventoryManager>() != null)
        {
            inventoryManager = other.GetComponent<InventoryManager>();
        }
        if (inventoryManager.CanAddItem())
        {
            Collect();
        }
        else
        {
            Debug.Log("Cannot collet item, inventory is full");
        }
    }

    public void Collect()
    {
        inventoryManager.AddItem(itemData);
        Collected();
    }
    private void Collected()
    {
        Destroy(gameObject);
    }
}
