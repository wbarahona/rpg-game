using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AIController : MonoBehaviour
{
    public float moveSpeed = 2f;
    public float rotationSpeed = 200f;

    private Vector2 moveDirection;

    void Start()
    {
        // Start moving in a random direction
        moveDirection = Random.insideUnitCircle.normalized;
    }

    void Update()
    {
        // Move the AI
        transform.Translate(moveDirection * moveSpeed * Time.deltaTime, Space.World);

        // Rotate the AI towards its movement direction
        float targetAngle = Mathf.Atan2(moveDirection.y, moveDirection.x) * Mathf.Rad2Deg;
        transform.rotation = Quaternion.RotateTowards(transform.rotation, Quaternion.Euler(0, 0, targetAngle), rotationSpeed * Time.deltaTime);

        // Check for collisions with 2D colliders
        RaycastHit2D hit = Physics2D.Raycast(transform.position, moveDirection, 0.5f);
        if (hit.collider != null)
        {
            // Change direction if collided with a 2D collider
            moveDirection = Random.insideUnitCircle.normalized;
        }
    }

    void OnCollisionEnter2D(Collision2D collision)
    {
        // Change direction if collided with another object
        moveDirection = Random.insideUnitCircle.normalized;
    }
}
