using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyTriggerCheckManager : IEnemyTriggerCheckService
{

    public bool IsPlayerTriggered(Enemy enemy,Player player, LayerMask layerMask)
    {
        return Physics.CheckSphere(enemy.transform.position, enemy.EnemySO.attackRange, layerMask);
    }
}
