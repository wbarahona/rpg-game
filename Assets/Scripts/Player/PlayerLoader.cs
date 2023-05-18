// this script is used to load the player from the prefab
// there is a gameObject prefab named as PlayerLoader in the scene
// this script is attached to the PlayerLoader gameObject

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerLoader : MonoBehaviour
{
  public GameObject playerPrefab; // the player prefab

  // Start is called before the first frame update
  void Start()
  {
    // if the player is not loaded
    if (PlayerController.instance == null)
    {
      // load the player from the prefab
      Instantiate(playerPrefab);
    }
  }
}