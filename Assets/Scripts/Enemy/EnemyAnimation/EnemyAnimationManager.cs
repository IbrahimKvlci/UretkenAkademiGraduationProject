using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyAnimationManager : IEnemyAnimationService
{
    Animator _animator;

    public EnemyAnimationManager(Animator animator)
    {

        _animator = animator;

    }



    public void SetChasing(bool value)
    {
        _animator.SetBool(EnemyAnimationBase.EnemyAnimationEnum.IsChasing.ToString(), value);
    }

    public void SetStand(bool value)
    {
        _animator.SetBool(EnemyAnimationBase.EnemyAnimationEnum.Stand.ToString(), value);
    }

    public void TriggerAttack()
    {
        _animator.SetTrigger(EnemyAnimationBase.EnemyAnimationEnum.Attack.ToString());

    }

    public void TriggerDeath()
    {
        _animator.SetTrigger(EnemyAnimationBase.EnemyAnimationEnum.Death.ToString());

    }

    public void TriggerTakeDamage()
    {
        _animator.SetTrigger(EnemyAnimationBase.EnemyAnimationEnum.TakeDamage.ToString());

    }
}
