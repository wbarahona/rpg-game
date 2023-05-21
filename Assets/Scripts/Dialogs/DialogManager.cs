// this scropt is used to manage the dialog
// between the player and the NPC

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DialogManager : MonoBehaviour
{
    [System.Serializable]
    public class CharacterDialogs
    {
        public DialogLines[] dialogs;
    }

    public Text dialogText;
    public Text nameText;
    public GameObject dialogBox;
    public GameObject nameBox;
    public int currentLine;
    private DialogLines[] dialogLines;
    private CharacterStats characterStats;
    private FileManager fileManager;
    // Start is called before the first frame update
    void Start()
    {
        characterStats = GetComponent<CharacterStats>();
        LoadDialog($"{characterStats.characterId}.json");
    }

    // Update is called once per frame
    void Update()
    {
        // dialogText.text = dialogLines[currentLine].text;
        // nameText.text = dialogLines[currentLine].name;
    }

    public void ClearDialogWindow()
    {
        dialogText.text = "";
        nameText.text = "";
        dialogBox.SetActive(false);
        nameBox.SetActive(false);
    }

    public void LoadDialog(string dialogFileName) {
        fileManager = new FileManager();

        // Fetch the initial data
        string dialogLinesAsString = fileManager.FetchDataFile("Data/Dialogs/NPC", dialogFileName);
        CharacterDialogs characterDialogs = JsonUtility.FromJson<CharacterDialogs>(dialogLinesAsString);
        
        if (dialogLinesAsString != null)
        {
            dialogLines = characterDialogs.dialogs;
            // Process the JSON data
            Debug.Log(PlaceHolderNameReplace(dialogLines[0].name)+": "+PlaceHolderNameReplace(dialogLines[0].text));
        }
    }

    private string PlaceHolderNameReplace(string text)
    {
        return text.Replace("$characterName", characterStats.characterName);
    }
}