using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ItemsRemainingController : MonoBehaviour
{
    public Text numItemText;
    public int minNumItems = 0;
    public int totalNumItemsInArea = 3;

    private int itemsInInventory;
    private string numItemString;
    private int itemsCollected;

    // Update is called once per frame
    void Update()
    {
        itemsInInventory = InventoryManager.Instance.inventory.Count;
        itemsCollected = itemsInInventory - minNumItems;

        if (itemsCollected > totalNumItemsInArea) {
            itemsCollected = totalNumItemsInArea;
        }

        string textCollected = "" + itemsCollected + "/" + totalNumItemsInArea + " Items Collected";
        numItemText.text = textCollected;
    }
}
