// this script has all dialogs for the NPCs
// it is attached to the NPC prefab

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NpcDialogs : MonoBehaviour
{
  [System.Serializable]
  public class CharacterDialogs
  {
    public DialogLines[] dialogs;
  }

  public static NpcDialogs instance;

  private FileManager fileManager;
  private DialogLines[] npcDialogLines = new DialogLines[0];
  private CharacterStats characterStats;
  private string characterId;


  // Start is called before the first frame update
  private void Start()
  {
    if (instance == null)
    {
      instance = this;
    }
    else
    {
      Destroy(gameObject);
    }
    DontDestroyOnLoad(gameObject);
    fileManager = new FileManager();
    characterStats = GetComponent<CharacterStats>();
    string characterId = characterStats.characterId;
    LoadDialog(characterId + ".json");
  }
  public void LoadDialog(string dialogFileName)
  {
    // Fetch the initial data
    string dialogLinesAsString = fileManager.FetchDataFile("Data/Dialogs/NPC", dialogFileName);
    CharacterDialogs characterDialogs = JsonUtility.FromJson<CharacterDialogs>(dialogLinesAsString);

    if (dialogLinesAsString != null)
    {
      npcDialogLines = characterDialogs.dialogs;
      // Process the JSON data
      Debug.Log(PlaceHolderReplace(npcDialogLines[0].name, "$characterName", characterStats.characterName) + ": " + PlaceHolderReplace(npcDialogLines[0].text, "$characterName", characterStats.characterName));
    }
  }

  private string PlaceHolderReplace(string text, string textToReplace, string characterName = "defaultReplacedName")
  {
    return text.Replace(textToReplace, characterName);
  }
}