using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface IEnemyHealthService
{
    event EventHandler OnEnemyHealthChanged;
    event EventHandler OnEnemyDeath;

    public int Health { get; set; }

    void TakeDamage(Enemy enemy, int damage);
    void Die(Enemy enemy);
    void Destroy(Enemy enemy);
}
