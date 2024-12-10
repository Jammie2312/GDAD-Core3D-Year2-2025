using System.Collections;
using System.Collections.Generic;
//using Unity.VisualScripting.ReorderableList;
using UnityEngine;

public class ItemClick : MonoBehaviour
{
    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            RaycastHit hit;

            if (Physics.Raycast(ray, out hit) )
            {
                Item clickedItem = hit.transform.GetComponent<Item>();

                if (clickedItem != null)
                {
                    clickedItem.DisplayInfo();
                    
                    clickedItem.SayHello();
                }
            }
        }
    }
}
