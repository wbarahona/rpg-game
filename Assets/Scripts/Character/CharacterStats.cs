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
  public enum CharacterClass
  {
    warrior,
    mage,
    rogue,
    cleric,
    merchant,
    questGiver,
    questReceiver,
    enemy,
    boss
  }
  public string characterName = "Default Name";
  public string characterDescription = "Default Description";
  public CharacterClass characterClass;
  public int health = 100;
  public int maxHealth { get; private set; } = 100;
  public int mana = 100;
  public int maxMana { get; private set; } = 100;
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
  public bool isPlayer = false;
  public bool isNPC = false;
  public bool isEnemy = false;
  public bool isBoss = false;
  public bool isMerchant = false;
  public bool isQuestGiver = false;
  public bool isQuestReceiver = false;
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
  public GameObject characterHealthBar;
  public GameObject characterLabel;

  private void Start()
  {
    characterHealthBar.GetComponentInChildren<Slider>().maxValue = maxHealth;
    characterHealthBar.GetComponentInChildren<Slider>().value = health;
    characterLabel.GetComponentInChildren<TextMesh>().text = characterName;

    hideVisualCues();
  }

  private void Update()
  {
    characterHealthBar.GetComponentInChildren<Slider>().value = health;
  }

  private void hideVisualCues()
  {
    // this hides the health bar and label for the character
    // these will be visible when necesary
    characterHealthBar.SetActive(false);
    characterLabel.SetActive(false);
  }
}
