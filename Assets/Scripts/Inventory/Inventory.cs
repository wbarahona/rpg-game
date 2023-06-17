// this is a script that is attached to the inventory game object
// this script is responsible for managing the inventory
// the definition of the inventory is a list of items based on an item class with a quantity as int

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public struct Inventory
{
    public List<InventoryListItem> items;
    public int inventorySize;
    public int inventoryMaxSize;
    public int inventoryGold;
    public int inventoryMaxGold;
    public int inventoryWeight;
    public int inventoryMaxWeight;
    public bool isInventoryOpen;
    public bool isInventoryClosed;
    public bool isInventoryFull;
    public bool isInventoryEmpty;

    // Constructor
    public Inventory(int size, int maxSize, int gold, int maxGold, int weight, int maxWeight)
    {
        items = new List<InventoryListItem>();
        inventorySize = size;
        inventoryMaxSize = maxSize;
        inventoryGold = gold;
        inventoryMaxGold = maxGold;
        inventoryWeight = weight;
        inventoryMaxWeight = maxWeight;
        isInventoryOpen = false;
        isInventoryClosed = true;
        isInventoryFull = false;
        isInventoryEmpty = true;
    }

    // TODO: Add inventory management functions here or use a different script like a MonoBehaviour with public methods to manage the inventory.
}
