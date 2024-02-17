using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAnimation : MonoBehaviour
{
    [SerializeField] private int maxAttackCounter;

    public enum PlayerAnimationEnum
    {
        IsAttacking,
        AttackCounter,
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

    public void SetAttackCounter()
    {
        int counter = animator.GetInteger(PlayerAnimationEnum.AttackCounter.ToString());
        int newCounter=counter+1;
        if(newCounter > maxAttackCounter)
        {
            newCounter = 0;
        }


        animator.SetInteger(PlayerAnimationEnum.AttackCounter.ToString(), newCounter);
    }

    public void ResetAttackCounter()
    {
        animator.SetInteger(PlayerAnimationEnum.AttackCounter.ToString(), 0);
    }
}
