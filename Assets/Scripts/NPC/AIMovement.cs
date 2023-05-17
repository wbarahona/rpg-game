using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AIMovement : MonoBehaviour
{
  public float speed = 3.5f;
  public float avoidDistance = 1f;
  public float moveDelay = 3f; // Delay between movements in seconds
  public LayerMask obstacleLayer;
  private Rigidbody2D rb;
  private CharacterAnimations characterAnimations;
  Vector2 direction;

  void Start()
  {
    characterAnimations = GetComponent<CharacterAnimations>();
    rb = GetComponent<Rigidbody2D>();
    StartCoroutine(MoveRandomly());
  }

  IEnumerator MoveRandomly()
  {
    while (true)
    {
      characterAnimations.x = 0;
      characterAnimations.y = 0;

      yield return new WaitForSeconds(moveDelay);
      direction = GetRandomDirection();
      // TODO: why is it that the character is facing the wrong way when moving left or down? I had to add the * -1 to fix it
      characterAnimations.x = direction.x * -1;
      characterAnimations.y = direction.y * -1;
      rb.velocity = direction * speed;

      if (CheckForObstacles())
      {
        rb.velocity = -direction * speed;
      }

      yield return new WaitForSeconds(.62f);
    }
  }

  private Vector2 GetRandomDirection()
  {
    int randomInt = Random.Range(0, 4);
    switch (randomInt)
    {
      case 0:
        return Vector2.up;
      case 1:
        return Vector2.down;
      case 2:
        return Vector2.left;
      default:
        return Vector2.right;
    }
  }

  private bool CheckForObstacles()
  {
    RaycastHit2D hitUp = Physics2D.Raycast(transform.position, Vector2.up, avoidDistance, obstacleLayer);
    RaycastHit2D hitDown = Physics2D.Raycast(transform.position, Vector2.down, avoidDistance, obstacleLayer);
    RaycastHit2D hitLeft = Physics2D.Raycast(transform.position, Vector2.left, avoidDistance, obstacleLayer);
    RaycastHit2D hitRight = Physics2D.Raycast(transform.position, Vector2.right, avoidDistance, obstacleLayer);

    if (hitUp.collider != null || hitDown.collider != null || hitLeft.collider != null || hitRight.collider != null)
    {
      return true;
    }
    else
    {
      return false;
    }
  }
}
