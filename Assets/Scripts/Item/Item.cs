// this is the item class and will be attached to any item prefab
// it has a name, description, icon, power as int, material as material class
// the stat that it affects as string, if it is a weapon or if it is armor
// what piece of armor is and only can be either head, chest, or legs
// item is equipped and also a quantity as int

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]

public class Item : MonoBehaviour
{
  public string itemName = "Default Name";
  public string itemDescription = "Default Description";
  public Sprite itemIcon;
  public int itemPower = 1;
  public ItemMaterial itemMaterial;
  public string itemStat = "Default Stat";
  public bool isWeapon = false;
  public bool isShield = false;
  public bool isArmor = false;
  public string armorPiece = "Default Piece";
  public bool isEquipped = false;
  public int itemQuantity = 1;
  public int itemWeight = 1;
  public static int itemSellValue = 1;
  public int itemBuyValue = Mathf.RoundToInt(itemSellValue * 0.1f) + itemSellValue;
}