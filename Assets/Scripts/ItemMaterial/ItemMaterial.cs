// this is the item material class
// it will be attached to any material prefab
// it has an id as int, name, description, icon, 
// strength against what type of material this material is as array of ItemMaterial
// weakeness against what type of attack this material is as array of AttackType

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]

public class ItemMaterial : MonoBehaviour
{
  public int materialID = 0;
  public string materialName = "Default Name";
  public string materialDescription = "Default Description";
  public Sprite materialIcon;
  public ItemMaterial[] materialStrengths;
  public AttackType[] materialWeaknesses;
}