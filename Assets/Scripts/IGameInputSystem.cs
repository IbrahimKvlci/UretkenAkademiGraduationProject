using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface IGameInputSystem
{
    event EventHandler OnJumpButtonPressed;

    Vector2 GetMovementVectorNormalized();
}
