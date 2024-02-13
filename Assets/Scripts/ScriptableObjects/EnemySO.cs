using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu()]
public class EnemySO : ScriptableObject
{
    public float maxHealth;
    public float speed;
    public float maxMoveRange;
    public float chaseRange;
    public float attackRange;
    public float attackSpeed;
    public float attackDamage;
}
