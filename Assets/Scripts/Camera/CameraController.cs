// this script is used to load the camera from the prefab
// there is a gameObject prefab named as CameraLoader in the scene
// this script is attached to the CameraLoader gameObject

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{
  public Transform target; // the target to follow
  private PlayerController thePlayer; // the player

  // Awake is called before the first frame update
  void Awake()
  {
    thePlayer = FindObjectOfType<PlayerController>(); // find the player

    target = thePlayer.transform; // set the target to follow
  }

  // LateUpdate is called after Update each frame (after all other updates)
  void LateUpdate()
  {
    transform.position = new Vector3(target.position.x, target.position.y, transform.position.z); // follow the target
  }
}