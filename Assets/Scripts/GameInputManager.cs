using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameInputManager : MonoBehaviour, IGameInputSystem
{
    private GameInputActions gameInputActions;

    private Vector2 movementVector;

    public event EventHandler OnJumpButtonPressed;
    public event EventHandler OnMouseWheelScrolled;

    private void Awake()
    {
        gameInputActions=new GameInputActions();

        gameInputActions.Enable();

        gameInputActions.Player.Jump.performed += Jump_performed;

        gameInputActions.Player.ChangeWeapon.performed += ChangeWeapon_performed;
    }

    private void ChangeWeapon_performed(UnityEngine.InputSystem.InputAction.CallbackContext obj)
    {
        OnMouseWheelScrolled?.Invoke(this, EventArgs.Empty);
    }

    private void Jump_performed(UnityEngine.InputSystem.InputAction.CallbackContext obj)
    {
        OnJumpButtonPressed?.Invoke(this, EventArgs.Empty);
    }

    public Vector2 GetMovementVectorNormalized()
    {
        movementVector=gameInputActions.Player.Movement.ReadValue<Vector2>();
        return movementVector;
    }

    public bool OnAttackButtonPressed()
    {
        return gameInputActions.Player.Attack.triggered;
    }

    public bool OnSkillButtonPressed()
    {
        return gameInputActions.Player.Skill.triggered;
    }

    public int GetMouseWheelValueNormalized()
    {
        return (int)gameInputActions.Player.ChangeWeapon.ReadValue<float>()/120;
    }
}
