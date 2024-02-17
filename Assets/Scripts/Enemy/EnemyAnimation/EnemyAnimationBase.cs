using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyAnimationBase : MonoBehaviour
{
    public enum EnemyAnimationEnum
    {
        IsChasing,
        Attack,
        Death,
        TakeDamage,
        Stand
    }

    private Animator animator;

    public IEnemyAnimationService EnemyAnimationService { get; set; }

    private void Awake()
    {
        animator = GetComponent<Animator>();
        EnemyAnimationService = new EnemyAnimationManager(animator);
    }

}
