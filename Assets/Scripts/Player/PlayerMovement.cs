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
  // Start is called before the first frame update
  void Start()
  {
    characterAnimations = GetComponent<CharacterAnimations>();
  }

  // Update is called once per frame
  void Update()
  {
    float x = Input.GetAxisRaw("Horizontal");
    float y = Input.GetAxisRaw("Vertical");

    movement.x = x;
    movement.y = y;

    characterAnimations.x = movement.x;
    characterAnimations.y = movement.y;
  }

  void FixedUpdate()
  {
    rb.MovePosition(rb.position + movement * moveSpeed * Time.fixedDeltaTime);
  }
}
