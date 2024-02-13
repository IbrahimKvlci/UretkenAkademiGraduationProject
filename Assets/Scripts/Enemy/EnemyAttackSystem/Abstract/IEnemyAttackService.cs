using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface IEnemyAttackService
{
    void Attack(Player player,float damage);
}
