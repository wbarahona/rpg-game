// this script is used to control the animations of the character
// it is attached to the character prefab

using UnityEngine;

public class CharacterAnimations : MonoBehaviour
{
  public float x;
  public float y;
  public float lastMoveX;
  public float lastMoveY;
  public Animator animator;
  Vector2 movement;
  private float lastX;
  private float lastY;

  // Update is called once per frame
  void Update()
  {
    movement.x = x;
    movement.y = y;

    if (x == 1 || x == -1 || y == 1 || y == -1)
    {
      lastX = x;
      lastY = y;
      lastMoveX = 0;
      lastMoveY = 0;
    }
    if (lastMoveX == 1 || lastMoveX == -1 || lastMoveY == 1 || lastMoveY == -1)
    {
      lastX = lastMoveX;
      lastY = lastMoveY;
    }

    animator.SetFloat("moveX", movement.x);
    animator.SetFloat("moveY", movement.y);
    animator.SetFloat("lastMoveX", lastX);
    animator.SetFloat("lastMoveY", lastY);
  }
}