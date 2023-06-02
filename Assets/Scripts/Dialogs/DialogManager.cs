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
  private List<DialogLines> dialogLines;

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
      if (currentLine >= dialogLines.Count)
      {
        ClearDialogWindow();
        HideDialogWindow();
        NpcDialogs.instance.StartMovement();
      }
      else
      {
        ShowCurrentDialogLine(currentLine);
        currentLine++;
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

  public void SetDialogLines(List<DialogLines> dialogLines)
  {
    this.dialogLines = dialogLines;
  }

  public void SetSimpleMessage(string message)
  {
    List<DialogLines> dialogLines = new List<DialogLines>();
    DialogLines dialogLine = new DialogLines();
    dialogLine.name = "";
    dialogLine.text = message;
    dialogLines.Add(dialogLine);

    SetDialogLines(dialogLines);
    nameBox.SetActive(false);
    dialogBox.SetActive(true);
  }

  public void StartDialog()
  {
    if (currentLine <= 0)
    {
      ShowDialogWindow();
      return;
    }
  }
}