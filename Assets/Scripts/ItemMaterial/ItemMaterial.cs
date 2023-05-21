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
  public string gameObjectId = "000000000000";
  public string materialId = "materialType_materialName";
  public string materialName = "Default Name";
  public string materialDescription = "Default Description";
  public Sprite materialIcon;
  public AttackType[] materialStrengths;
  public AttackType[] materialWeaknesses;
  public float spawnChance = 1f;
  public int quantity = 1;
  public GameObject gameMaterialLabel;

  private void Start()
  {
    gameMaterialLabel.GetComponentInChildren<TextMesh>().text = "x" + quantity.ToString();
  }
}