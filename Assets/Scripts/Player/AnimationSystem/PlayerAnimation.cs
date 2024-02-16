using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAnimation : MonoBehaviour
{
    public enum PlayerAnimationEnum
    {
        IsAttacking,
        IsAttackingHorizontal,
        IsAttackingBackhand,
        Idle,
        Run
    }

    private Animator animator;

    private void Awake()
    {
        animator = GetComponent<Animator>();
    }

    public void SetAnimationTrigger(PlayerAnimationEnum animation)
    {
        animator.SetTrigger(animation.ToString());
    }

    public void SetAnimationBool(PlayerAnimationEnum animation,bool isRunning)
    {
        animator.SetBool(animation.ToString(),isRunning);
    }
}
