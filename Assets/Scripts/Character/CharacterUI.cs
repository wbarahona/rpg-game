// this script contains all interactions with the character UI
// the character UI displays a healthbar, overhead bubble and overhead label

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CharacterUI : MonoBehaviour
{
  public GameObject characterVisualCues;
  public GameObject characterLabel;
  public GameObject characterHealthBarWrapper;
  public Slider characterHealthBar;
  public OverheadBubble characterOverheadBubble;
  public Image emojiBubble;

  public void showHealthBar()
  {
    characterVisualCues.gameObject.SetActive(true);
    characterHealthBarWrapper.gameObject.SetActive(true);
  }

  public void showOverheadBubble()
  {
    characterVisualCues.gameObject.SetActive(true);
    characterOverheadBubble.gameObject.SetActive(true);
  }

  public void showOverheadLabel(string text)
  {
    characterLabel.GetComponentInChildren<TextMesh>().text = text;
    characterLabel.gameObject.SetActive(true);
  }

  public void hideHealthBar()
  {
    characterHealthBarWrapper.gameObject.SetActive(false);
  }

  public void hideOverheadBubble()
  {
    characterOverheadBubble.gameObject.SetActive(false);
  }

  public void hideOverheadLabel()
  {
    characterLabel.gameObject.SetActive(false);
  }

  public void hideVisualCues()
  {
    characterVisualCues.gameObject.SetActive(false);
    characterHealthBarWrapper.gameObject.SetActive(false);
    characterOverheadBubble.gameObject.SetActive(false);
    characterLabel.gameObject.SetActive(false);
  }

  public void initHealthBar(float maxHealth, float health)
  {
    characterHealthBar.maxValue = maxHealth;
    characterHealthBar.value = health;
  }

  public void updateHealthBar(float health)
  {
    characterHealthBar.value = health;
  }

  public void setEmojiBubble(int moodId)
  {
    characterOverheadBubble.SetEmoji(moodId);
  }
}