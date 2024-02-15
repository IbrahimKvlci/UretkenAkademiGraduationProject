using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface IPlayerMovementService
{
    void HandleMovement();
    bool IsWalking();
    void Dash(float speed);
}
