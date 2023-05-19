// this script is used to fade in and out the UI elements
// or to fade in and out the screen when changing scenes

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIFade : MonoBehaviour
{
  // public variables
  public static UIFade instance; // the instance of the UI fade
  public Image fadeScreen; // the fade screen
  public float fadeSpeed; // the fade speed

  // private variables
  private bool shouldFadeToBlack; // should fade to black
  private bool shouldFadeFromBlack; // should fade from black

  // Start is called before the first frame update
  void Start()
  {
    // if the instance is null
    if (instance == null)
    {
      // set the instance to this
      instance = this;
    } // if the instance is not null
    else if (instance != this)
    {
      // destroy the game object
      Destroy(gameObject);
    }
    DontDestroyOnLoad(gameObject);
  }

  // Update is called once per frame
  void Update()
  {
    // if should fade to black
    if (shouldFadeToBlack)
    {
      // fade to black
      FadeToBlack();
    } // if should fade from black
    else if (shouldFadeFromBlack)
    {
      // fade from black
      FadeFromBlack();
    }
  }

  // this function is used to fade to black
  public void FadeToBlack()
  {
    // set the fade screen to active
    fadeScreen.gameObject.SetActive(true);

    // get the color of the fade screen
    float r = fadeScreen.color.r;
    float g = fadeScreen.color.g;
    float b = fadeScreen.color.b;
    float a = Mathf.MoveTowards(fadeScreen.color.a, 1f, fadeSpeed * Time.deltaTime);

    // set the alpha of the fade screen
    fadeScreen.color = new Color(r, g, b, a);
    // if the alpha is greater than or equal to 1
    if (fadeScreen.color.a >= 1f)
    {
      // set the alpha to 1
      fadeScreen.color = new Color(r, g, b, 1f);
      // set should fade to black to false
      shouldFadeToBlack = false;
    }
  }

  // this function is used to fade from black
  public void FadeFromBlack()
  {
    // get the color of the fade screen
    float r = fadeScreen.color.r;
    float g = fadeScreen.color.g;
    float b = fadeScreen.color.b;
    float a = Mathf.MoveTowards(fadeScreen.color.a, 0, fadeSpeed * Time.deltaTime);

    // set the alpha of the fade screen
    fadeScreen.color = new Color(r, g, b, a);
    // if the alpha is less than or equal to 0
    if (fadeScreen.color.a <= 0f)
    {
      // set the alpha to 0
      fadeScreen.color = new Color(r, g, b, 0f);
      // set the fade screen to inactive
      fadeScreen.gameObject.SetActive(false);
      // set should fade from black to false
      shouldFadeFromBlack = false;
    }
  }

  // this function is used to fade to black the screen
  public void FadeToBlackScreen()
  {
    // set should fade to black to true
    shouldFadeToBlack = true;
    // set should fade from black to false
    shouldFadeFromBlack = false;
  }

  // this function is used to fade from black the screen
  public void FadeFromBlackScreen()
  {
    // set should fade to black to false
    shouldFadeToBlack = false;
    // set should fade from black to true
    shouldFadeFromBlack = true;
  }
}