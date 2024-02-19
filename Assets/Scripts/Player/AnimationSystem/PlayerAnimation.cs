using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAnimation : MonoBehaviour
{
    [SerializeField] private int maxAttackCounter;

    [SerializeField] private PlayerSkill playerSkill;
    [SerializeField] private Transform skillPoint;

    public enum PlayerAnimationEnum
    {
        IsAttacking,
        AttackCounter,
        Idle,
        Run,
        Dash,
        Death
    }

    private Animator animator;

    

    private void Awake()
    {
        animator = GetComponent<Animator>();
    }

    public void SkillParticleAnimation(GameObject skillPrefab)
    {
        GameObject prefabVisual = Instantiate(skillPrefab);
        prefabVisual.transform.SetParent(skillPoint);
        prefabVisual.transform.localPosition = Vector3.zero;
        prefabVisual.transform.localRotation = Quaternion.identity;
    }

    public void DashSkillAnimation()
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
