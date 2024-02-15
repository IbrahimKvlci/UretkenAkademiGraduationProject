using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface IPlayerHealthService:IDamageable
{
    public float Health { get; set; }
}
