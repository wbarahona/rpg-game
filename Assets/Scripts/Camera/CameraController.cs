// this script is used to load the camera from the prefab
// there is a gameObject prefab named as CameraLoader in the scene
// this script is attached to the CameraLoader gameObject

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Tilemaps;

public class CameraController : MonoBehaviour
{
  public Transform target; // the target to follow
  public Tilemap theMap; // the map
  private PlayerManager thePlayer; // the player
  private Vector3 bottomLeftLimit; // the bottom left limit of the map
  private Vector3 topRightLimit; // the top right limit of the map
  private float halfHeight; // the half height of the camera
  private float halfWidth; // the half width of the camera

  // Start is called before the first frame update
  void Start()
  {
    thePlayer = FindObjectOfType<PlayerManager>(); // find the player

    halfHeight = Camera.main.orthographicSize; // get the half height of the camera
    halfWidth = halfHeight * Camera.main.aspect; // get the half width of the camera

    target = thePlayer.transform; // set the target to follow
    bottomLeftLimit = theMap.localBounds.min + new Vector3(halfWidth, halfHeight, 0f); // set the bottom left limit
    topRightLimit = theMap.localBounds.max + new Vector3(-halfWidth, -halfHeight, 0f); // set the top right limit
    thePlayer.SetBounds(theMap.localBounds.min, theMap.localBounds.max); // set the bounds of the player
  }

  // LateUpdate is called after Update each frame (after all other updates)
  void LateUpdate()
  {
    transform.position = new Vector3(target.position.x, target.position.y, transform.position.z); // follow the target

    float clampedX = Mathf.Clamp(transform.position.x, bottomLeftLimit.x, topRightLimit.x); // clamp the x position
    float clampedY = Mathf.Clamp(transform.position.y, bottomLeftLimit.y, topRightLimit.y); // clamp the y position

    transform.position = new Vector3(clampedX, clampedY, transform.position.z); // clamp the camera to the map
  }
}