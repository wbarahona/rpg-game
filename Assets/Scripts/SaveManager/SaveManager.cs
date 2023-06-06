using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SaveManager : MonoBehaviour
{
  public static SaveManager instance; // the instance of the save manager
  private FileManager fileManager; // the file manager
  private const string FileName = "data.json";

  // Start is called before the first frame update
  void Start()
  {
    // if the instance is null
    if (instance == null)
    {
      // set the instance to this
      instance = this;
    } // if the instance is not null
    else if (instance != this)
    {
      // destroy the game object
      Destroy(gameObject);
    }

    LoadGameSave();
  }

  // Update is called once per frame
  void Update()
  {
    if (Input.GetKeyDown(KeyCode.L))
    {
      SaveData s = new SaveData();

      s.worldObjects = GetWorldObjectDataList();
      SaveGame(s);
    }
  }

  public List<SaveWorldObject> GetWorldObjectDataList()
  {
    WorldObjectPersist[] worldObjects = FindObjectsOfType<WorldObjectPersist>();
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

      // Use the instanceID as needed
      Debug.Log("Instance ID: " + worldObjectData.worldObjectPositionX);
      saveWorldObjects.Add(new SaveWorldObject(instanceID, name, positionX, positionY, positionZ, isPlayer, isInteractable, hasBeenInteracted, playerIsInRange, playerIsOutRange, canDisplayMessage, canActivateMessage));
    }

    return saveWorldObjects;
  }

  public void LoadGameSave()
  {
    fileManager = new FileManager();

    // Fetch the initial data
    string initialData = fileManager.FetchDataFile("Data", "InitialSaveData.json");
    if (initialData != null)
    {
      // Use the initial data as needed
      Debug.Log("Initial data fetched successfully");

      // Initialize the file with the initial data if it doesn't exist
      fileManager.InitFile(FileName, initialData);
    }
    else
    {
      Debug.LogError("Failed to fetch initial data");
    }

    // Example usage: Read the JSON file
    string jsonContent = fileManager.ReadFile(FileName);

    if (jsonContent != null)
    {
      // Process the JSON data
      SaveData saveData = JsonUtility.FromJson<SaveData>(jsonContent);

      Debug.Log("Player name: " + saveData.gameStats.player.stats.characterName);
    }
  }

  public void SaveGame(SaveData saveData)
  {
    // Convert the SaveData object to JSON
    string jsonContent = JsonUtility.ToJson(saveData);

    // Write the JSON content to the file
    fileManager.WriteFile(FileName, jsonContent);
  }
}
