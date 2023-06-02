// this script is used to control the interactive object
// it will be attached to the interactive object prefab
// can display quick messages when player is near the object
// and presses Fire1 / CTRL key while on the 
// circle collider 2d as trigger

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InteractiveObject : MonoBehaviour {
  // public variables
  public string gameObjectId = "000000000000";
  public string characterId = "objectClass_objectName";
  public string characterName = "Default Name";
  public string characterDescription = "Default Description";
  public bool isInteractable = true; // is interactable
  public bool hasBeenInteracted = false; // has been interacted
  public bool playerIsInRange = false; // is player in range
  public bool playerIsOutRange = true; // is player out of range
  public bool canDisplayMessage = true; // can display message
  public bool canActivateMessage = false; // can activate message
  public string messageToDisplay; // the message to display
  public Sprite objectDefaultSprite; // the default sprite
  private void Start() {
    
  }

  private void Update() {
    if (canActivateMessage && Input.GetButtonUp("Fire1")) {
      hasBeenInteracted = true;
      // display the message
      DialogManager.instance.SetSimpleMessage(messageToDisplay);
    }
  }

  // this method is called when the player enters the trigger
  private void OnTriggerEnter2D(Collider2D other) {
    // if the other object is the player
    if (other.CompareTag("Player"))
    {
      playerIsInRange = true;
      if (isInteractable && canDisplayMessage) {
        canActivateMessage = true;
      }
    }
  }

  // this method is called when the player exits the trigger
  private void OnTriggerExit2D(Collider2D other) {
    // if the other object is the player
    if (other.CompareTag("Player"))
    {
      playerIsInRange = false;
      if (isInteractable && canDisplayMessage) {
        canActivateMessage = false;
      }
    }
  }
}