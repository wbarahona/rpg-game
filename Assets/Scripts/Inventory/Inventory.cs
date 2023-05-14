// this is a script that is attached to the inventory game object
// this script is responsible for managing the inventory
// the definition of the inventory is a list of items based on an item class with a quantity as int

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]

public class Inventory
{
  public List<InventoryListItem> items = new List<InventoryListItem>();
  public int inventorySize = 20;
  public int inventoryMaxSize = 100;
  public int inventoryGold = 0;
  public int inventoryMaxGold = 999999;
  public int inventoryWeight = 0;
  public int inventoryMaxWeight = 100;
  public bool isInventoryOpen = false;
  public bool isInventoryClosed = true;
  public bool isInventoryFull = false;
  public bool isInventoryEmpty = true;
  // TODO: add inventory management functions here or shall I use a different script for that like a monobehaviour with public fns that manage the inventory?
}