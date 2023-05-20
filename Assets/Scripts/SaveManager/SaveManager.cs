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
        DontDestroyOnLoad(gameObject);
        LoadGameSave();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void LoadGameSave() {
        fileManager = new FileManager();

        // Fetch the initial data
        string initialData = fileManager.FetchInitialData();
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
            Debug.Log(jsonContent);
        }
    }
}
