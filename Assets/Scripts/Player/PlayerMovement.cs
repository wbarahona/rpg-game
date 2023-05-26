// this script allows the player to move
// it is attached to the player prefab
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
  public float moveSpeed = 5f;
  public Rigidbody2D rb;
  public Camera cam;
  Vector2 movement;

  private CharacterAnimations characterAnimations;
  private CharacterStats playerStats;
  // Start is called before the first frame update
  void Start()
  {
    playerStats = GetComponent<CharacterStats>();
    characterAnimations = GetComponent<CharacterAnimations>();
  }

  // Update is called once per frame
  void Update()
  {

    if (playerStats.canMove)
    {
      movement.x = Input.GetAxisRaw("Horizontal");
      movement.y = Input.GetAxisRaw("Vertical");

      characterAnimations.x = movement.x;
      characterAnimations.y = movement.y;
    }
    else
    {
      movement.x = 0;
      movement.y = 0;
      characterAnimations.x = 0;
      characterAnimations.y = 0;
    }
  }

  void FixedUpdate()
  {
    rb.MovePosition(rb.position + movement * moveSpeed * Time.fixedDeltaTime);
  }
}
