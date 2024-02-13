using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerHealthManager : IPlayerHealthService
{
    public float Health { get; set; }

    public void TakeDamage(float damage)
    {
        Health-=damage;

        if(Health <= 0)
        {
            Debug.Log("Die!");
        }
    }
}
