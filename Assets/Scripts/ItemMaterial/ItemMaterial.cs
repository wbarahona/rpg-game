// this is the item material class
// it will be attached to any material prefab
// it has an id as int, name, description, icon, 
// strength against what type of attack this material is as array of AttackType
// weakeness against what type of attack this material is as array of AttackType

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]

public class ItemMaterial : MonoBehaviour
{
  public enum Rarity // 1 = common, 2 = uncommon, 3 = rare, 4 = epic, 5 = legendary
  {
    common = 1,
    uncommon = 2,
    rare = 3,
    epic = 4,
    legendary = 5
  }
  public string gameObjectId = "000000000000";
  public string materialId = "materialType_materialName";
  public string materialName = "Default Name";
  public string materialDescription = "Default Description";
  public Sprite materialIcon;
  public AttackType[] materialStrengths;
  public AttackType[] materialWeaknesses;
  public bool isSellable = false;
  public bool isBuyable = false;
  public float spawnChance = 1f;
  public int quantity = 1;
  public float materialBaseValue = 1;
  public float materialBuyValue = 0;
  public float materialSellValue = 0;
  public float materialWeight = 1;
  public Rarity materialRarity; // 1 = common, 2 = uncommon, 3 = rare, 4 = epic, 5 = legendary
  public GameObject gameMaterialLabel;

  private void Start()
  {
    gameMaterialLabel.GetComponentInChildren<TextMesh>().text = "x" + quantity.ToString();
    materialBuyValue = isBuyable ? CalculateMaterialValue(materialRarity, materialBaseValue) : 0f;
    materialSellValue = isSellable ? CalculateMaterialValue(materialRarity, materialBaseValue) : 0f;
    spawnChance = CalculateMaterialSpawnChance(materialRarity);
  }

  public float CalculateMaterialSpawnChance(Rarity materialRarity)
  {
    int rarityValue = (int)materialRarity;

    if (rarityValue >= 1 && rarityValue <= 5)
    {
      float baseSpawnChance = (6 - rarityValue) / 5f;

      if (rarityValue >= 3) // Adjust spawn chance for rarity "rare," "epic," or "legendary"
      {
        baseSpawnChance *= 0.8f; // Reduce the spawn chance by 20%
      }

      return spawnChance;
    }

    return 0f; // Invalid rarity, no spawn chance
  }

  public float CalculateMaterialValue(Rarity materialRarity, float baseValue)
  {
    int rarityValue = (int)materialRarity;

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