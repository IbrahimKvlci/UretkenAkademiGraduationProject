using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu()]
public class EnemySO : ScriptableObject
{
    public int maxHealth;
    public float speed;
    public float chaseSpeed;
    public float rotationSpeed = 5f;
    public float maxMoveRange;
    public float chaseRange;
    public float attackRange;
    public float attackSpeed;
    public float attackDamage;
    public float attackAnimationTime;
    public float attackAnimationAllTime;
    public float deathTime;
    public int gold;
}
