using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface IEnemyHealthService
{
    void TakeDamage(Enemy enemy, float damage);
    void Die(Enemy enemy);
    void Destroy(Enemy enemy);
}
