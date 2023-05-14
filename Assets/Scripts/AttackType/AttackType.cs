// this is the AttackType script
// it will be attached to any attack type prefab
// it has an id as int, name, description, icon,
// attack type and can only be either physical, magical, or special

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]

public class AttackType : MonoBehaviour
{
  public int attackTypeID = 0;
  public string attackTypeName = "Default Name";
  public string attackTypeDescription = "Default Description";
  public Sprite attackTypeIcon;
  public string attackType = "Default Type";
}