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
  public enum AttackTypeName
  {
    physical,
    magical,
    special
  }
  public enum AttackTypeEffect
  {
    slash,
    fire,
    ice,
    plasma,
  }
  public int attackTypeID = 0;
  public string attackTypeName = "Default Name";
  public string attackTypeDescription = "Default Description";
  public Sprite attackTypeIcon;
  public AttackTypeName attackType;
  public AttackTypeEffect attackTypeEffect;
  // TODO: this will have the attack effect animation prefab attached to it add it here
  public int baseAttackPower = 1;
}