using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerHealthManager : IPlayerHealthService
{
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

    public event EventHandler OnHealthChanged;

    public void TakeDamage(float damage)
    {
        Health-=damage;

        if(Health <= 0)
        {
            Debug.Log("Die!");
        }
    }
}
