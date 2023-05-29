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
  public enum ArmorPiece
  {
    head,
    chest,
    legs
  }
  public enum ItemClass
  {
    weapon,
    shield,
    armor,
    consumable,
    crafting,
    quest,
    money,
    misc
  }
  public enum Rarity // 1 = common, 2 = uncommon, 3 = rare, 4 = epic, 5 = legendary
  {
    common = 1,
    uncommon = 2,
    rare = 3,
    epic = 4,
    legendary = 5
  }
  public enum ElementType
  {
    fire,
    water,
    plasma,
    none
  }
  public string gameObjectId = "000000000000";
  public string itemId = "itemClass_itemName";
  public string itemName = "Default Name";
  public string itemDescription = "Default Description";
  public Sprite itemIcon;
  public int itemPower = 1;
  public ItemCraftingList[] itemCraftingList;
  public ItemCraftingList[] itemDeconstructionList;
  public Stats.StatsType statEffectName;
  public ItemClass itemClass;
  public ArmorPiece armorPiece;
  public bool isSellable = false;
  public bool isBuyable = false;
  public bool isPickupable = false;
  public bool isCraftable = false;
  public bool isEquippeable = false;
  public bool isEquipped = false;
  public bool isElemental = false;
  public ElementType itemElementalType;
  public int itemQuantity = 1;
  public float itemWeight = 1;
  public float itemBaseValue = 1;
  public float itemBuyValue = 1;
  public float itemSellValue = 1;
  public float spawnChance = 1;
  public Rarity itemRarity;
  public GameObject gameItemLabel;
  public AttackType itemAttackType;
  public ElementType itemUpgradeType;
  public int itemUpgradeLevel = 0;
  public int maxUpgradeLevel = 5;

  private void Start()
  {
    gameItemLabel.GetComponentInChildren<TextMesh>().text = "x" + itemQuantity.ToString();
    itemSellValue = isSellable ? CalculateItemValue(itemRarity, itemBaseValue) : 0f;
    itemBuyValue = isBuyable ? CalculateItemValue(itemRarity, itemBaseValue) : 0f;
    spawnChance = CalculateSpawnChance(itemRarity);
  }

  public float CalculateSpawnChance(Rarity itemRarity)
  {
    int rarityValue = (int)itemRarity;

    if (rarityValue >= 1 && rarityValue <= 5)
    {
      float baseSpawnChance = (6 - rarityValue) / 5f;

      if (rarityValue >= 3) // Adjust spawn chance for rarity "rare," "epic," or "legendary"
      {
        baseSpawnChance *= 0.8f; // Reduce the spawn chance by 20%
      }

      return baseSpawnChance;
    }

    return 0f; // Invalid rarity, no spawn chance
  }

  public float CalculateItemValue(Rarity rarity, float baseValue)
  {
    int rarityValue = (int)rarity;

    if (rarityValue >= 1 && rarityValue <= 5)
    {
      float baseSellValue = baseValue * rarityValue;

      if (rarityValue >= 3) // Adjust sell value for rarity "rare," "epic," or "legendary"
      {
        baseSellValue *= 0.8f; // Reduce the sell value by 20%
      }

      return baseSellValue;
    }

    return 0f; // Invalid rarity, no sell value
  }
}