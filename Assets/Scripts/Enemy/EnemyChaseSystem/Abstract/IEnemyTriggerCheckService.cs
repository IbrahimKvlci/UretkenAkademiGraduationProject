using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface IEnemyTriggerCheckService
{
    bool IsPlayerTriggered(Enemy enemy,Player player,LayerMask layerMask);
}
