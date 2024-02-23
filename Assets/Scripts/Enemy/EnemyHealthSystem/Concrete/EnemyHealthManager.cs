using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyHealthManager : IEnemyHealthService
{
    public event EventHandler OnEnemyHealthChanged;
    public event EventHandler OnEnemyDeath;

    private int _health;
    public int Health
    {
        get
        {
            return _health;
        }
        set 
        { 
            _health = value;
            OnEnemyHealthChanged?.Invoke(this, EventArgs.Empty);
        }

    }

    
    public void Destroy(Enemy enemy)
    {
        GameObject.Destroy(enemy.gameObject);
    }

    public void Die(Enemy enemy)
    {
        enemy.IsDead = true;
        Player.Instance.PlayerGoldService.Gold += enemy.EnemySO.gold;

        OnEnemyDeath?.Invoke(this, EventArgs.Empty);    
    }

    public void TakeDamage(Enemy enemy,int damage)
    {
        enemy.EnemyHealthService.Health -=damage;

        enemy.EnemySoundController.PlayEnemyHitSound();

        if(enemy.EnemyHealthService.Health <= 0)
        {
            Die(enemy);
        }
    }
}
