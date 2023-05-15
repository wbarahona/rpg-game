// this script contains the actions for the overhead bubble

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class OverheadBubble : MonoBehaviour
{
  public Sprite[] allEmojis;
  public Image bubbleEmoji;
  public Text bubbleText;

  public void SetEmoji(int emojiID)
  {
    bubbleEmoji.sprite = allEmojis[emojiID];
  }

  public void SetText(string text)
  {
    bubbleText.text = text;
  }
}