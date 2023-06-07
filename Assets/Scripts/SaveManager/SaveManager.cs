using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SaveManager : MonoBehaviour
{
  public static SaveManager instance; // the instance of the save manager
  private FileManager fileManager; // the file manager
  private const string FileName = "data.json";
  private WorldObjectManager worldObjectManager = new WorldObjectManager(); // the world object manager

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
      WorldObjectPersist[] worldObjects = FindObjectsOfType<WorldObjectPersist>();
      SavePlayerStats playerStats = worldObjectManager.GetPlayerData(worldObjects);

      s.worldObjects = worldObjectManager.GetWorldObjectDataList(worldObjects);
      s.gameStats.player.playerPositionX = playerStats.playerPositionX;
      s.gameStats.player.playerPositionY = playerStats.playerPositionY;
      SaveGame(s);
    }
  }

  private void SetWorldObjectDataList(List<SaveWorldObject> saveWorldObjects)
  {
    WorldObjectPersist[] worldObjects = FindObjectsOfType<WorldObjectPersist>();
    foreach (SaveWorldObject saveWorldObject in saveWorldObjects)
    {
      foreach (WorldObjectPersist worldObject in worldObjects)
      {
        if (saveWorldObject.worldObjectId == worldObject.GetWorldObjectId())
        {
          worldObject.SetWorldObjectData(saveWorldObject);
        }
      }
    }
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

      SetWorldObjectDataList(saveData.worldObjects);
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
