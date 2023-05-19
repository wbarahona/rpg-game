// this script is used to load all the essentials scripts in the game
// this script is attached to the EssentialsLoader prefab

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EssentialsLoader : MonoBehaviour
{
  // public variables
  public GameObject UIScreen; // the UI screen
  public GameObject player; // the player
  // public GameObject gameManagers; // the game managers
  // Start is called before the first frame update
  void Start()
  {
    if (UIFade.instance == null)
    {
      UIFade.instance = Instantiate(UIScreen).GetComponent<UIFade>();
    }
    if (PlayerController.instance == null)
    {
      PlayerController clone = Instantiate(player).GetComponent<PlayerController>();
      PlayerController.instance = clone;
    }
    // if (GameManager.instance == null)
    // {
    //   Instantiate(gameManagers);
    // }
  }

  // Update is called once per frame
  void Update()
  {

  }
}