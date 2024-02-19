using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface IPlayerHealthService:IDamageable
{
    event EventHandler OnHealthChanged;
    event EventHandler OnPlayerDeath;


    float Health { get; set; }
    bool IsAlive { get; set; }

    void Die();
}
