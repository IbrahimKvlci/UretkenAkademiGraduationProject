using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface IEnemyMovementService 
{
    public bool CanMove { get; set; }

    void HandleMovement();
    void MoveToPoint(Vector3 pointToMove,float speed);
    void HandleChase(Player player);
    
}
