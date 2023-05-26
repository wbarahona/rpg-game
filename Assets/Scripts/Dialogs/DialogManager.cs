// this scropt is used to manage the dialog
// between the player and the NPC

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class DialogManager : MonoBehaviour
{
  public static DialogManager instance;
  public Text nameText;
  public GameObject dialogBox;
  public GameObject nameBox;
  public GameObject dialogTextContent;
  public int currentLine = 0;
  private TextMeshProUGUI dialogText;
  private DialogLines[] dialogLines;

  // Start is called before the first frame update
  void Start()
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

    dialogText = dialogTextContent.GetComponent<TextMeshProUGUI>();

    ClearDialogWindow();
    HideDialogWindow();
  }

  // Update is called once per frame
  void Update()
  {
    if (dialogBox.activeInHierarchy && Input.GetButtonUp("Fire1"))
    {
      currentLine++;
      if (currentLine >= dialogLines.Length)
      {
        ClearDialogWindow();
        HideDialogWindow();
      }
      else
      {
        ShowCurrentDialogLine(currentLine);
      }
    }
  }

  public void ClearDialogWindow()
  {
    dialogText.text = "";
    nameText.text = "";
    currentLine = 0;
  }

  public void HideDialogWindow()
  {
    dialogBox.SetActive(false);
    nameBox.SetActive(false);
    NpcDialogs.instance.StartMovement();
  }

  public void ShowDialogWindow()
  {
    dialogBox.SetActive(true);
    nameBox.SetActive(true);
  }

  public void ShowCurrentDialogLine(int currLine)
  {
    dialogText.text = dialogLines[currLine].text;
    nameText.text = dialogLines[currLine].name;
  }

  public void SetDialogLines(DialogLines[] dialogLines)
  {
    this.dialogLines = dialogLines;
  }

  public void StartDialog()
  {
    ShowDialogWindow();
    ShowCurrentDialogLine(currentLine);
  }
}