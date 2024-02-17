using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyHealthManager : IEnemyHealthService
{
    public void Destroy(Enemy enemy)
    {
        GameObject.Destroy(enemy.gameObject);
    }

    public void Die(Enemy enemy)
    {
        enemy.IsDead = true;
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
