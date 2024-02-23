using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerHealthManager : IPlayerHealthService
{
    public event EventHandler OnHealthChanged;
    public event EventHandler OnPlayerDeath;

    private float _health;
    public float Health
    {
        get 
        { 
            return _health;
        }
        set 
        { 
            _health = value;
            OnHealthChanged?.Invoke(this, EventArgs.Empty);
        }
    }

    public bool IsAlive { get; set; }

    public void Die()
    {
        IsAlive = false;

        OnPlayerDeath?.Invoke(this, EventArgs.Empty);
    }

    public void TakeDamage(float damage)
    {
        if(IsAlive)
        {
            Health -= damage;
            Player.Instance.PlayerSoundController.PlayPlayerHitSound(Player.Instance.transform.position);

            if (Health <= 0)
            {
                Die();
            }
        }
    }
}
