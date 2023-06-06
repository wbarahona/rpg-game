// this script controls the unique data from the world object
// it will read the data from the savefile and apply it to the world object
// it will also return the data from the world object to be saved to the savefile
// once the player saves the game, this script will be called to get the data
// from the world object and save it to the savefile

using UnityEngine;

public class WorldObjectPersist : MonoBehaviour
{
  public static WorldObjectPersist instance;

  [System.Serializable]
  public class WorldObjectData
  {
    public int worldObjectId = 0;
    public string worldObjectName = "Default World Object Name";
    public float worldObjectPositionX = 0;
    public float worldObjectPositionY = 0;
    public float worldObjectPositionZ = 0;
    public bool isPlayer = false; // if is player
    public bool isInteractable = true; // is interactable
    public bool hasBeenInteracted = false; // has been interacted
    public bool playerIsInRange = false; // is player in range
    public bool playerIsOutRange = true; // is player out of range
    public bool canDisplayMessage = true; // can display message
    public bool canActivateMessage = false; // can activate message
  }
  public int worldObjectId = 0;
  private void Start()
  {
    if (instance == null)
    {
      instance = this;
    }
    SetWorldObjectId();
  }

  public void SetWorldObjectId()
  {
    worldObjectId = gameObject.GetInstanceID();
  }

  public int GetWorldObjectId()
  {
    return worldObjectId;
  }

  public WorldObjectData GetWorldObjectData()
  {
    // get the data from the world object
    // return the data
    WorldObjectData worldObjectData = new WorldObjectData();
    InteractiveObject interactiveObject = GetComponent<InteractiveObject>();
    PlayerManager playerManager = GetComponent<PlayerManager>();

    worldObjectData.worldObjectId = worldObjectId;
    worldObjectData.worldObjectName = gameObject.name;
    worldObjectData.worldObjectPositionX = transform.position.x;
    worldObjectData.worldObjectPositionY = transform.position.y;
    worldObjectData.worldObjectPositionZ = transform.position.z;

    if (interactiveObject != null)
    {
      // is interactive object, fill the rest of the properties
      worldObjectData.isInteractable = interactiveObject.isInteractable;
      worldObjectData.hasBeenInteracted = interactiveObject.hasBeenInteracted;
      worldObjectData.playerIsInRange = interactiveObject.playerIsInRange;
      worldObjectData.playerIsOutRange = interactiveObject.playerIsOutRange;
      worldObjectData.canDisplayMessage = interactiveObject.canDisplayMessage;
      worldObjectData.canActivateMessage = interactiveObject.canActivateMessage;
    }

    if (playerManager != null)
    {
      // is player, set the isPlayer property to true
      worldObjectData.isPlayer = true;
    }

    return worldObjectData;
  }
}