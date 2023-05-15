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
    happy,
    sad,
    angry,
    scared,
    confused,
    surprised,
    disgusted,
    neutral
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
  public GameObject characterVisualCues;
  public GameObject characterLabel;
  private GameObject characterHealthBarWrapper;
  private Slider characterHealthBar;
  private TextMesh characterOverheadLabel;
  private OverheadBubble characterOverheadBubble;

  private void Start()
  {
    characterHealthBar = characterVisualCues.GetComponentInChildren<Slider>();
    characterOverheadBubble = characterVisualCues.GetComponentInChildren<OverheadBubble>();
    characterOverheadLabel = characterLabel.GetComponentInChildren<TextMesh>();
    characterHealthBarWrapper = characterHealthBar.transform.parent.gameObject;

    characterHealthBar.maxValue = maxHealth;
    characterHealthBar.value = health;
    characterOverheadLabel.text = characterName;

    hideVisualCues();
  }

  private void Update()
  {
    characterHealthBar.value = health;
  }

  public void showHealthBar()
  {
    characterVisualCues.gameObject.SetActive(true);
    characterOverheadBubble.gameObject.SetActive(false);
    characterHealthBarWrapper.gameObject.SetActive(true);
  }

  public void showOverheadBubble()
  {
    characterVisualCues.gameObject.SetActive(true);
    characterHealthBarWrapper.gameObject.SetActive(false);
    characterOverheadBubble.gameObject.SetActive(true);
  }

  public void showOverheadLabel()
  {
    characterLabel.gameObject.SetActive(true);
  }

  public void hideHealthBar()
  {
    characterVisualCues.gameObject.SetActive(false);
    characterHealthBarWrapper.gameObject.SetActive(false);
  }

  public void hideOverheadBubble()
  {
    characterVisualCues.gameObject.SetActive(false);
    characterOverheadBubble.gameObject.SetActive(false);
  }

  public void hideOverheadLabel()
  {
    characterLabel.gameObject.SetActive(false);
  }

  private void hideVisualCues()
  {
    characterVisualCues.gameObject.SetActive(false);
    characterHealthBarWrapper.gameObject.SetActive(false);
    characterOverheadBubble.gameObject.SetActive(false);
    characterLabel.gameObject.SetActive(false);
  }
}
