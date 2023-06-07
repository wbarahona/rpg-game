// this script finds information about any world object in the scene
// also will massage the data to be saved to the savefile

using System.Collections.Generic;
using System.Collections;
using UnityEngine;

public class WorldObjectManager
{
  public List<SaveWorldObject> GetWorldObjectDataList(WorldObjectPersist[] worldObjects)
  {
    List<SaveWorldObject> saveWorldObjects = new List<SaveWorldObject>();

    foreach (WorldObjectPersist worldObject in worldObjects)
    {
      WorldObjectPersist.WorldObjectData worldObjectData = worldObject.GetWorldObjectData();

      int instanceID = worldObjectData.worldObjectId;
      string name = worldObjectData.worldObjectName;
      float positionX = worldObjectData.worldObjectPositionX;
      float positionY = worldObjectData.worldObjectPositionY;
      float positionZ = worldObjectData.worldObjectPositionZ;
      bool isPlayer = worldObjectData.isPlayer;
      bool isInteractable = worldObjectData.isInteractable;
      bool hasBeenInteracted = worldObjectData.hasBeenInteracted;
      bool playerIsInRange = worldObjectData.playerIsInRange;
      bool playerIsOutRange = worldObjectData.playerIsOutRange;
      bool canDisplayMessage = worldObjectData.canDisplayMessage;
      bool canActivateMessage = worldObjectData.canActivateMessage;

      saveWorldObjects.Add(new SaveWorldObject(instanceID, name, positionX, positionY, positionZ, isPlayer, isInteractable, hasBeenInteracted, playerIsInRange, playerIsOutRange, canDisplayMessage, canActivateMessage));
    }

    return saveWorldObjects;
  }

  public SavePlayerStats GetPlayerData(WorldObjectPersist[] worldObjects)
  {
    // get the player data
    // return the player data
    SavePlayerStats playerStats = new SavePlayerStats();
    foreach (WorldObjectPersist worldObject in worldObjects)
    {
      if (worldObject.GetWorldObjectData().isPlayer)
      {
        WorldObjectPersist.WorldObjectData worldObjectData = worldObject.GetWorldObjectData();

        float positionX = worldObjectData.worldObjectPositionX;
        float positionY = worldObjectData.worldObjectPositionY;

        // TODO: Get the player information from the save data saved in the game data object

        playerStats.playerPositionX = positionX;
        playerStats.playerPositionY = positionY;

        return playerStats;
      }
    }
    return playerStats;
  }
}