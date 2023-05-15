// this script contains the definition of Stats for the game characters
// can be applied to any CharacterStat

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]

public class Stats
{
  public enum StatsType
  {
    health,
    mana,
    strength,
    defense,
    speed,
    luck
  }
}