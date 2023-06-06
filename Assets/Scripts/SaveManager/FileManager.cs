using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;

public class FileManager
{
  public static FileManager instance; // the instance of the file manager
  private const string gameName = "RPGGame";

  // Start is called before the first frame update
  void Start()
  {
    // if the instance is null
    if (instance == null)
    {
      // set the instance to this
      instance = this;
    }
  }

  // Update is called once per frame
  void Update()
  {

  }

  private string GetFilePath(string filename)
  {
    string filePath = "";

    switch (Application.platform)
    {
      case RuntimePlatform.WindowsEditor:
      case RuntimePlatform.WindowsPlayer:
        filePath = Path.Combine(GetWindowsDirectory(), filename);
        break;
      case RuntimePlatform.OSXEditor:
      case RuntimePlatform.OSXPlayer:
        filePath = Path.Combine(GetMacOSDirectory(), filename);
        break;
      case RuntimePlatform.Android:
        filePath = Path.Combine(GetAndroidDirectory(), filename);
        break;
      case RuntimePlatform.IPhonePlayer:
        filePath = Path.Combine(GetiOSDirectory(), filename);
        break;
      default:
        Debug.LogError("Unsupported platform");
        break;
    }

    return filePath;
  }

  public bool FileExists(string filename)
  {
    string filePath = GetFilePath(filename);
    return File.Exists(filePath);
  }

  public void InitFile(string filename, string initialContent)
  {
    string filePath = GetFilePath(filename);
    string directoryPath = Path.GetDirectoryName(filePath);

    // Create the directory if it doesn't exist
    if (!Directory.Exists(directoryPath))
    {
      try
      {
        Directory.CreateDirectory(directoryPath);
        Debug.Log($"Directory '{directoryPath}' created.");
      }
      catch (IOException e)
      {
        Debug.LogError($"Error creating directory: {e.Message}");
        return;
      }
    }

    if (!FileExists(filename))
    {
      try
      {
        File.WriteAllText(filePath, initialContent);
        Debug.Log($"File '{filename}' created.");
      }
      catch (IOException e)
      {
        Debug.LogError($"Error creating file: {e.Message}");
      }
    }
    else
    {
      Debug.Log($"File '{filename}' already exists.");
    }
  }

  public string ReadFile(string filename)
  {
    string filePath = GetFilePath(filename);
    if (File.Exists(filePath))
    {
      try
      {
        return File.ReadAllText(filePath);
      }
      catch (IOException e)
      {
        Debug.LogError($"Error reading file: {e.Message}");
      }
    }
    else
    {
      Debug.LogError($"File not found: {filePath}");
    }

    return null;
  }

  public void WriteFile(string filename, string content)
  {
    string filePath = GetFilePath(filename);

    try
    {
      File.WriteAllText(filePath, content);
    }
    catch (IOException e)
    {
      Debug.LogError($"Error writing file: {e.Message}");
    }
  }

  public string FetchDataFile(string folder, string fileName)
  {
    string initialSaveDataPath = Path.Combine(Application.dataPath, folder, fileName);

    if (File.Exists(initialSaveDataPath))
    {
      try
      {
        return File.ReadAllText(initialSaveDataPath);
      }
      catch (IOException e)
      {
        Debug.LogError($"Error reading data file '{fileName}': {e.Message}");
      }
    }
    else
    {
      Debug.LogError($"{fileName} Data file not found");
    }

    return null;
  }

  private string GetWindowsDirectory()
  {
    return Path.Combine(System.Environment.GetFolderPath(System.Environment.SpecialFolder.MyDocuments), gameName);
  }

  private string GetMacOSDirectory()
  {
    return Path.Combine(System.Environment.GetFolderPath(System.Environment.SpecialFolder.Personal), gameName);
  }

  private string GetAndroidDirectory()
  {
    return Path.Combine(Application.persistentDataPath, gameName);
  }

  private string GetiOSDirectory()
  {
    return Path.Combine(Application.persistentDataPath, gameName);
  }
}
