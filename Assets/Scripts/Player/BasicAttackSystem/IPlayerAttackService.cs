using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface IPlayerAttackService
{   
    void Attack(Enemy enemy,WeaponSO weaponSO);

    bool IsAttacking();
}
