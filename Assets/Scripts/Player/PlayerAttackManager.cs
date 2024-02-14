using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAttackManager : IPlayerAttackService
{
    private IGameInputSystem _gameInputSystem;

    public PlayerAttackManager(IGameInputSystem gameInputSystem)
    {
        _gameInputSystem = gameInputSystem;
    }

    public void Attack(Enemy enemy, WeaponSO weaponSO)
    {
        enemy.EnemyHealthService.TakeDamage(enemy,weaponSO.damage);
    }

    public bool IsAttacking()
    {
        if (_gameInputSystem.OnAttackButtonPressed())
        {
            return true;
        }
        return false;
    }
}
