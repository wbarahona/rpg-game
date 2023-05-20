// this scropt is used to manage the dialog
// between the player and the NPC

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DialogManager : MonoBehaviour
{
    public Text dialogText;
    public Text nameText;
    public GameObject dialogBox;
    public GameObject nameBox;
    public int currentLine;
    private DialogLines[] dialogLines;
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        dialogText.text = dialogLines[currentLine].text;
        nameText.text = dialogLines[currentLine].name;
    }

    public void ClearDialogWindow()
    {
        dialogText.text = "";
        nameText.text = "";
        dialogBox.SetActive(false);
        nameBox.SetActive(false);
    }
}