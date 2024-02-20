using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface IGameInputSystem
{
    event EventHandler OnJumpButtonPressed;
    event EventHandler OnMouseWheelScrolled;
    event EventHandler OnPlayerInteract;
    event EventHandler OnGamePauseKeyPressed;

    Vector2 GetMovementVectorNormalized();
    int GetMouseWheelValueNormalized(); 
    bool OnAttackButtonPressed();
    bool OnSkillButtonPressed();
}
