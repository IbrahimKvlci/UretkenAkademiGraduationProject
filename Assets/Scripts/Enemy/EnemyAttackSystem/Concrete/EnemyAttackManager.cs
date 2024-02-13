using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyAttackManager : IEnemyAttackService
{
    public void Attack(Player player, float damage)
    {
        player.PlayerHealthService.TakeDamage(damage);
        Debug.Log("attack!");
    }
}
