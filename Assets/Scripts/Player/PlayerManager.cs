// this script handles the player character
// as a manager it allows the player interact with the world
// it is attached to the player prefab

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerManager : MonoBehaviour
{
  // public variables
  public static PlayerManager instance; // the instance of the player controller
  public string areaTransitionName; // the area transition name
  private Vector3 bottomLeftLimit; // the bottom left limit of the map
  private Vector3 topRightLimit; // the top right limit of the map
  private FileManager fileManager; // the file manager

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
    float clampedX = Mathf.Clamp(transform.position.x, bottomLeftLimit.x, topRightLimit.x); // clamp the x position
    float clampedY = Mathf.Clamp(transform.position.y, bottomLeftLimit.y, topRightLimit.y); // clamp the y position

    transform.position = new Vector3(clampedX, clampedY, transform.position.z); // clamp the camera to the map
  }

  // this function is used to set the bounds of the camera
  public void SetBounds(Vector3 botLeft, Vector3 topRight)
  {
    float offsetX = .5f;
    float offsetY = 1f;
    bottomLeftLimit = botLeft + new Vector3(offsetX, offsetY, 0f); // set the bottom left limit
    topRightLimit = topRight + new Vector3(-offsetX, -offsetY, 0f); // set the top right limit
  }
}