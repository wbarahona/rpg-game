// This is the character stats class that will be used for all characters prefabs in the game
// This class will be used for the player, NPCs, enemies, and bosses
// This class will be used for the merchant and quest giver NPCs
// This class also will be attached to any world character prefab or battle character prefab
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
[System.Serializable]

public class CharacterStats : MonoBehaviour
{
  public enum CharacterGameClass
  {
    villager,
    warrior,
    mage,
    rogue,
    cleric,
    merchant
  }

  public enum CharacterType
  {
    player,
    npc,
    boss,
    merchant,
    questGiver,
    questReceiver
  }

  public enum CharacterStatus
  {
    normal,
    poisoned,
    paralyzed,
    confused,
    blind,
    silenced,
    cursed,
    petrified,
    asleep,
    dead
  }

  public enum CharacterMood
  {
    happy = 0,
    sad = 1,
    angry = 2,
    scared = 3,
    confused = 4,
    surprised = 5,
    disgusted = 6,
    neutral = 7
  }
  public int characterID = 0;
  public string characterName = "Default Name";
  public string characterDescription = "Default Description";
  public CharacterGameClass characterClass;
  public CharacterType characterType;
  public CharacterStatus characterStatus;
  public CharacterMood characterMood;
  public Sprite characterIcon;
  public int health = 100;
  public int maxHealth = 100;
  public int mana = 100;
  public int maxMana = 100;
  public int strength = 1;
  public int defense = 1;
  public int speed = 1;
  public int luck = 1;
  public int level = 1;
  public int maxLevel = 100;
  public int experience = 0;
  public int experienceToNextLevel = 100;
  public bool isDead = false;
  public bool isActive = true;
  public bool canMove = true;
  public bool canAttack = true;
  public bool canUseMagic = true;
  public bool canUseItem = true;
  public Inventory inventory = new Inventory();
  // TODO: add a quest public variable here or what quest array the character is on
  // TODO: add a moves list here or what moves the character has
  public Item weaponEquipped;
  public Item shieldEquipped;
  public Item armorHeadEquipped;
  public Item armorChestEquipped;
  public Item armorLegEquipped;
  private CharacterUI characterUI;

  private void Start()
  {
    characterUI = GetComponent<CharacterUI>();

    characterUI.initHealthBar(maxHealth, health);
    characterUI.hideVisualCues();
  }

  private void Update()
  {
    characterUI.updateHealthBar(health);
    characterUI.setEmojiBubble((int)characterMood);
  }

  public void SetCharacterDead()
  {
    isDead = true;
    health = 0;
    characterUI.hideVisualCues();
  }

  public void SetCharacterAlive()
  {
    isDead = false;
    health = 1;
    characterUI.showHealthBar();
  }

  public void TakeDamage(int damage)
  {
    if (isDead)
    {
      return;
    }

    health -= damage;

    if (health <= 0)
    {
      SetCharacterDead();
    }
  }

  public void Heal(int healAmount)
  {
    if (isDead)
    {
      return;
    }

    health += healAmount;

    if (health > maxHealth)
    {
      health = maxHealth;
    }
  }
}
