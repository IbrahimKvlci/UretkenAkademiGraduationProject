using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface IPlayerTriggerCheckService
{
    bool IsEnemyTriggeredToBeAttacked(Transform point, out Enemy enemy, float length, LayerMask layerMask);
}
