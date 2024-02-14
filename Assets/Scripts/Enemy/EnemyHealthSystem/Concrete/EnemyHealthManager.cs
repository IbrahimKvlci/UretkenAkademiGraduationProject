using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyHealthManager : IEnemyHealthService
{
    public void Die(Enemy enemy)
    {
        Debug.Log($"{enemy.name} Die!");
    }

    public void TakeDamage(Enemy enemy,float damage)
    {
        enemy.Health-=damage;

        if(enemy.Health <= 0)
        {
            Die(enemy);
        }
    }
}
