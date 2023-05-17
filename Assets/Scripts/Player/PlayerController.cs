// this script handles the player character
// as a controller it allows the player interact with the world
// it is attached to the player prefab

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
  // public variables
  public static PlayerController instance; // the instance of the player controller
  public string areaTransitionName; // the area transition name

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

  }
}