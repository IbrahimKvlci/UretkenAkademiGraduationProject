using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameInputManager : MonoBehaviour, IGameInputSystem
{
    private GameInputActions gameInputActions;

    private Vector2 movementVector;

    public event EventHandler OnJumpButtonPressed;

    private void Awake()
    {
        gameInputActions=new GameInputActions();

        gameInputActions.Enable();

        gameInputActions.Player.Jump.performed += Jump_performed;

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
}
