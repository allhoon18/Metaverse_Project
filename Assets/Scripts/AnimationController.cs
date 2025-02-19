using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AnimationController : MonoBehaviour
{
    Animator animator;

    SpriteRenderer spriteRenderer;

    private static readonly int IsMoving = Animator.StringToHash("isMove");
    private static readonly int IsJump = Animator.StringToHash("isJump");

    private void Awake()
    {
        animator = GetComponentInChildren<Animator>();
        spriteRenderer = GetComponentInChildren<SpriteRenderer>();
    }

    public void Move(Vector2 obj)
    {
        animator.SetBool(IsMoving, obj.magnitude > 0.5f);
    }

    public void Flip(float inputX)
    {
        if(inputX != 0)
            spriteRenderer.flipX = inputX < 0;
    }

    public void Jump()
    {
        animator.SetTrigger(IsJump);
    }
}
