using System;
using UnityEngine;
using System.Collections.Generic;
// add save prefix and rename each serialized class
[Serializable]
public class SaveData
{
  public bool initialIdentity;
  public string gameVersion;
  public string gameTitle;
  public string gameDescription;
  public string gameAuthor;
  public string gameDate;
  public string emoji;
  public SaveGameStats gameStats;
  public List<SaveWorldObject> worldObjects;
}

[Serializable]
public class SaveGameStats
{
  public SavePlayerStats player;
}

[Serializable]
public class SavePlayerStats
{
  public int gamePlayTime;
  public string gamePlayTimeFormatted;
  public int inGameTime;
  public int score;
  public float playerPositionX;
  public float playerPositionY;
  public SavePlayerCharacterStats stats;
  public List<SavePlayerPartyMember> playerParty;
  public SavePlayerInventory inventory;
}

[Serializable]
public class SavePlayerInventoryList
{
  public string itemId;
  public int quantity;
}

[Serializable]
public class SavePlayerInventory
{
  public int inventorySize = 20;
  public int inventoryMaxSize = 100;
  public int inventoryGold = 0;
  public int inventoryMaxGold = 999999;
  public int inventoryWeight = 0;
  public int inventoryMaxWeight = 100;
  public bool isInventoryOpen = false;
  public bool isInventoryClosed = true;
  public bool isInventoryFull = false;
  public bool isInventoryEmpty = true;
  public List<SavePlayerInventoryList> inventoryList = new List<SavePlayerInventoryList>();
}

[Serializable]
public class SavePlayerCharacterStats
{
  public int characterID;
  public string characterName;
  public string characterDescription;
  public string characterClass;
  public string characterType;
  public string characterStatus;
  public string characterMood;
  public int health;
  public int maxHealth;
  public int mana;
  public int maxMana;
  public int strength;
  public int defense;
  public int speed;
  public int luck;
  public int level;
  public int maxLevel;
  public int experience;
  public int experienceToNextLevel;
  public bool isDead;
  public bool isActive;
  public bool canMove;
  public bool canAttack;
  public bool canUseMagic;
  public bool canUseItem;
  public string weaponEquippedId;
  public string shieldEquippedId;
  public string armorHeadEquipped;
  public string armorChestEquipped;
  public string armorLegEquipped;
}

[Serializable]
public class SavePlayerPartyMember
{
  // Define the properties for the player party member as needed
}

[Serializable]
public class SaveWorldObject
{
  public int worldObjectId;
  public string worldObjectName;
  public float worldObjectPositionX;
  public float worldObjectPositionY;
  public float worldObjectPositionZ;
  public bool isPlayer;
  public bool isInteractable = true; // is interactable
  public bool hasBeenInteracted = false; // has been interacted
  public bool playerIsInRange = false; // is player in range
  public bool playerIsOutRange = true; // is player out of range
  public bool canDisplayMessage = true; // can display message
  public bool canActivateMessage = false; // can activate message

  // Constructor with arguments
  public SaveWorldObject(int objectId, string objectName, float posX, float posY, float posZ, bool player, bool interactable, bool interacted, bool playerinrange, bool playeroutofrange, bool displaymessage, bool activatemessage)
  {
    worldObjectId = objectId;
    worldObjectName = objectName;
    worldObjectPositionX = posX;
    worldObjectPositionY = posY;
    worldObjectPositionZ = posZ;
    isPlayer = player;
    isInteractable = interactable;
    hasBeenInteracted = interacted;
    playerIsInRange = playerinrange;
    playerIsOutRange = playeroutofrange;
    canDisplayMessage = displaymessage;
    canActivateMessage = activatemessage;
  }
}