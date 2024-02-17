using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAnimation : MonoBehaviour
{
    [SerializeField] private int maxAttackCounter;

    [SerializeField] private PlayerSkill playerSkill;

    public enum PlayerAnimationEnum
    {
        IsAttacking,
        AttackCounter,
        Idle,
        Run,
        Dash
    }

    private Animator animator;

    

    private void Awake()
    {
        animator = GetComponent<Animator>();
    }

    private void Start()
    {
        playerSkill.DashSkill.SkillBaseSO.SkillService.OnSkillUsed += DashSkillService_OnSkillUsed;
    }

    private void DashSkillService_OnSkillUsed(object sender, System.EventArgs e)
    {
        animator.SetTrigger(PlayerAnimationEnum.Dash.ToString());
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

    public void UseSkill(PlayerAnimationEnum animationEnum)
    {
        animator.SetTrigger(animationEnum.ToString());
    }
}
