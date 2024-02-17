using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface IGameInputSystem
{
    event EventHandler OnJumpButtonPressed;
    event EventHandler OnMouseWheelScrolled;

    Vector2 GetMovementVectorNormalized();
    int GetMouseWheelValueNormalized(); 
    bool OnAttackButtonPressed();
    bool OnSkillButtonPressed();
}
