// This is the character stats class that will be used for all characters prefabs in the game
// This class will be used for the player, NPCs, enemies, and bosses
// This class will be used for the merchant and quest giver NPCs
// This class also will be attached to any world character prefab or battle character prefab
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
[System.Serializable]

public class CharacterStats : MonoBehaviour
{
  public string characterName = "Default Name";
  public string characterDescription = "Default Description";
  public string characterClass = "Default Class";
  public int health = 100;
  public int maxHealth { get; private set; } = 100;
  public int mana = 100;
  public int maxMana { get; private set; } = 100;
  public int strength = 1;
  public int defense = 1;
  public int speed = 1;
  public int luck = 1;
  public int level { get; private set; } = 1;
  public int maxLevel { get; private set; } = 100;
  public int experience { get; private set; } = 0;
  public int experienceToNextLevel { get; private set; } = 100;
  public bool isDead { get; private set; } = false;
  public bool isActive { get; private set; } = true;
  public bool isPlayer { get; private set; } = false;
  public bool isNPC { get; private set; } = false;
  public bool isEnemy { get; private set; } = false;
  public bool isBoss { get; private set; } = false;
  public bool isMerchant { get; private set; } = false;
  public bool isQuestGiver { get; private set; } = false;
  public bool isQuestReceiver { get; private set; } = false;
  public bool canMove { get; private set; } = true;
  public bool canAttack { get; private set; } = true;
  public bool canUseMagic { get; private set; } = true;
  public bool canUseItem { get; private set; } = true;
  public Inventory inventory = new Inventory();
  // TODO: add a quest public variable here or what quest array the character is on
  // TODO: add a moves list here or what moves the character has
  public Item weaponEquipped;
  public Item shieldEquipped;
  public Item armorHeadEquipped;
  public Item armorChestEquipped;
  public Item armorLegEquipped;
}
