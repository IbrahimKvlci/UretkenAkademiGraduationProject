using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface IEnemyMovementService 
{
    void HandleMovement();
    void MoveToPoint(Vector3 pointToMove);
}
