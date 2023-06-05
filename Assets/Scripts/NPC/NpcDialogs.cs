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
    public List<DialogLines> dialogs;
  }

  public static NpcDialogs instance;

  private FileManager fileManager;
  private List<DialogLines> npcDialogLines = new List<DialogLines>();
  private CharacterStats npcStats;
  private string characterId;
  private bool canActivateDialog = false;


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

    fileManager = new FileManager();
    npcStats = GetComponent<CharacterStats>();
    string npcId = npcStats.characterId;

    LoadDialog(npcId + ".json");
  }

  // Update is called once per frame
  private void Update()
  {
    if (canActivateDialog && Input.GetButtonUp("Fire1"))
    {
      DialogManager.instance.SetDialogLines(npcDialogLines);
      DialogManager.instance.StartDialog();
      StopMovement();
    }
  }
  public void LoadDialog(string dialogFileName)
  {
    // Fetch the initial data
    string dialogLinesAsString = fileManager.FetchDataFile("Data/Dialogs/NPC", dialogFileName);
    CharacterDialogs characterDialogs = JsonUtility.FromJson<CharacterDialogs>(dialogLinesAsString);

    if (dialogLinesAsString != null)
    {
      npcDialogLines = characterDialogs.dialogs;
      ReplacePlaceHolders();
    }
  }

  private void ReplacePlaceHolders()
  {
    string playerName = PlayerManager.instance.GetStats().characterName;
    int length = npcDialogLines.Count;

    for (int i = 0; i < length; ++i)
    {
      npcDialogLines[i].name = PlaceHolderReplace(npcDialogLines[i].name, "$characterName", npcStats.characterName);
      npcDialogLines[i].text = PlaceHolderReplace(npcDialogLines[i].text, "$characterName", npcStats.characterName);
      npcDialogLines[i].name = PlaceHolderReplace(npcDialogLines[i].name, "$playerName", playerName);
      npcDialogLines[i].text = PlaceHolderReplace(npcDialogLines[i].text, "$playerName", playerName);
    }
  }

  private string PlaceHolderReplace(string text, string textToReplace, string characterName = "defaultReplacedName")
  {
    return text.Replace(textToReplace, characterName);
  }

  private void StopMovement()
  {
    PlayerManager.instance.SetStat(CharacterStats.StatType.canMove, 0);
    npcStats.SetStat(CharacterStats.StatType.isSpeaking, 1);
  }

  public void StartMovement()
  {
    PlayerManager.instance.SetStat(CharacterStats.StatType.canMove, 1);
    npcStats.SetStat(CharacterStats.StatType.isSpeaking, 0);
  }

  private void OnTriggerEnter2D(Collider2D other)
  {
    if (other.CompareTag("Player"))
    {
      canActivateDialog = true;
    }
  }

  private void OnTriggerExit2D(Collider2D other)
  {
    if (other.CompareTag("Player"))
    {
      canActivateDialog = false;
    }
  }
}