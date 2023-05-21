// this scropt is used to manage the dialog
// between the player and the NPC

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class DialogManager : MonoBehaviour
{
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
  }

  public void HideDialogWindow()
  {
    dialogBox.SetActive(false);
    nameBox.SetActive(false);
  }

  public void ShowDialogWindow()
  {
    dialogBox.SetActive(true);
    nameBox.SetActive(true);
  }

  public void ShowCurrentDialogLine(int currLine)
  {
    // dialogText.text = PlaceHolderNameReplace(dialogLines[currLine].text);
    // nameText.text = PlaceHolderNameReplace(dialogLines[currLine].name);
  }
}