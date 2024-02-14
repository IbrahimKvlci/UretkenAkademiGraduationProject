using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerTriggerCheckManager : IPlayerTriggerCheckService
{
    public bool IsEnemyTriggeredToBeAttacked(Transform point, out Enemy enemy, float length, LayerMask layerMask)
    {
        if(Physics.Raycast(point.position, point.forward,out RaycastHit hitInfo, length, layerMask))
        {
            enemy=hitInfo.transform.GetComponent<Enemy>();
            return true;
        }
        enemy= null;
        return false;
    }
}
