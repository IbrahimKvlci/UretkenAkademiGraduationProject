using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FireSkillManager:ISkillService
{
    public event EventHandler OnSkillUsed;

    private PlayerTriggerCheck _playerTriggerCheck;

    public FireSkillManager(PlayerTriggerCheck playerTriggerCheck)
    {
        _playerTriggerCheck=playerTriggerCheck;
    }

    public void PlayAnimation(SkillBaseSO skill,PlayerAnimation playerAnimation)
    {
        playerAnimation.SkillParticleAnimation(((FireSkillSO)skill).prefab);

        Player.Instance.PlayerSoundController.PlayPlayerFireSkillSound(Player.Instance.transform.position);

    }

    public void UseSkill(SkillBaseSO fireSkillSO)
    {
        OnSkillUsed?.Invoke(this, EventArgs.Empty);
        if(_playerTriggerCheck.IsEnemiesTriggeredToBeAttacked(out List<Enemy> enemies, ((FireSkillSO)fireSkillSO).range))
        {
            foreach (var enemy in enemies)
            {
                enemy.EnemyHealthService.TakeDamage(enemy, ((FireSkillSO)fireSkillSO).damage);
            }
        }

    }

    
}
