using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface IPlayerHealthService:IDamageable
{
    event EventHandler OnHealthChanged;

    float Health { get; set; }
}
