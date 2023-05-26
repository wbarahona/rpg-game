using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AIMovement : MonoBehaviour
{
  public float moveSpeed = 3f; // The movement speed of the NPC
  public float idleTime = 2f; // Time to idle between movements
  public float detectionDistance = 1f; // Distance to detect solid objects
  public float moveTime = 3f; // Time to move in a chosen direction
  private CharacterStats characterStats; // Reference to the CharacterStats script
  private Transform playerTransform; // Reference to the player's transform
  private CharacterAnimations characterAnimations;

  private Rigidbody2D rb;
  private Vector2[] directions = { Vector2.up, Vector2.down, Vector2.left, Vector2.right };
  private Vector2 currentDirection;
  private float idleTimer;
  private float moveTimer;
  private bool isSpeaking;

  private void Awake()
  {
    rb = GetComponent<Rigidbody2D>();
  }

  private void Start()
  {
    characterStats = GetComponent<CharacterStats>();
    playerTransform = PlayerManager.instance.transform;
    characterAnimations = GetComponent<CharacterAnimations>();
    isSpeaking = characterStats.isSpeaking;
  }

  private void Update()
  {
    if (characterStats.isDead || !characterStats.isActive || !characterStats.canMove)
    {
      return;
    }

    if (isSpeaking != characterStats.isSpeaking)
    {
      isSpeaking = characterStats.isSpeaking;
      if (isSpeaking)
      {
        TurnTowardsPlayer();
      }
    }

    if (!isSpeaking)
    {
      if (idleTimer > 0f)
      {
        ResetNPCAnimations();
        idleTimer -= Time.deltaTime;
        return;
      }

      if (moveTimer > 0f)
      {
        moveTimer -= Time.deltaTime;
        Move(currentDirection);
      }
      else
      {
        if (currentDirection == Vector2.zero || IsBlocked())
        {
          currentDirection = GetRandomDirection();
        }

        moveTimer = moveTime;
        idleTimer = idleTime;
      }
    }
  }

  private bool IsBlocked()
  {
    RaycastHit2D hit = Physics2D.Raycast(transform.position, currentDirection, detectionDistance);
    return hit.collider != null;
  }

  private Vector2 GetRandomDirection()
  {
    return directions[Random.Range(0, directions.Length)];
  }

  private void Move(Vector2 direction)
  {
    ResetNPCAnimations();
    rb.velocity = direction * moveSpeed;
    characterAnimations.x = direction.x;
    characterAnimations.y = direction.y;
  }

  private void TurnTowardsPlayer()
  {
    ResetNPCAnimations();
    Vector2 directionToPlayer = playerTransform.position - transform.position;
    float angle = Mathf.Atan2(directionToPlayer.y, directionToPlayer.x) * Mathf.Rad2Deg;
    angle += 180f;

    float vectorValue = 1f;
    Vector2[] animatorValues = new Vector2[]
    {
        new Vector2(-vectorValue, 0f),  // Left
        new Vector2(0f, -vectorValue),  // Down
        new Vector2(vectorValue, 0f),    // Right
        new Vector2(0f, vectorValue)   // Up
    };

    int index = Mathf.FloorToInt((angle + 45f) / 90f) % 4;
    Vector2 selectedValue = animatorValues[index];

    currentDirection = selectedValue;

    characterAnimations.lastMoveX = currentDirection.x;
    characterAnimations.lastMoveY = currentDirection.y;
  }

  private void ResetNPCAnimations()
  {
    characterAnimations.x = 0;
    characterAnimations.y = 0;
  }
}

