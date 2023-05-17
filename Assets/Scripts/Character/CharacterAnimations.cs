// this script is used to control the animations of the character
// it is attached to the character prefab

using UnityEngine;

public class CharacterAnimations : MonoBehaviour
{
  public float x;
  public float y;
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
    }

    animator.SetFloat("moveX", movement.x);
    animator.SetFloat("moveY", movement.y);
    animator.SetFloat("lastMoveX", lastX);
    animator.SetFloat("lastMoveY", lastY);
  }
}