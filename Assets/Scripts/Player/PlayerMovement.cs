using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem.XR;
using Zenject;

public class PlayerMovement:IPlayerMovementService
{

    private Player _player;
    private CharacterController characterController;

    private Vector3 movementVector;

    private IGameInputSystem _gameInputSystem;

    private bool isWalking;

    public PlayerMovement(Player player,IGameInputSystem gameInputSystem)
    {
        _gameInputSystem = gameInputSystem;
        _player = player;

        characterController = _player.GetComponent<CharacterController>();
    }



    public void HandleMovement()
    {
        Vector2 movementInputVector = _gameInputSystem.GetMovementVectorNormalized();
        movementVector = new Vector3(movementInputVector.x,0,movementInputVector.y);

        isWalking= movementVector != Vector3.zero;

        characterController.Move(movementVector * _player.PlayerSO.speed * Time.deltaTime);

        if (isWalking)
        {
            _player.transform.forward = Vector3.Slerp(_player.transform.forward, movementVector, Time.deltaTime * _player.PlayerSO.rotationSpeed); ;
        }
    }

    public bool IsWalking()
    {
        if(_gameInputSystem.GetMovementVectorNormalized() != Vector2.zero)
        {
            isWalking = true;
        }
        return isWalking;
    }
}
