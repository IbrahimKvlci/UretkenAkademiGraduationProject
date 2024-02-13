using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem.XR;
using Zenject;

public class PlayerMovement : MonoBehaviour
{
    [SerializeField] private float speed;
    [SerializeField] private float rotateSpeed;


    private CharacterController characterController;

    private Vector3 movementVector;

    private IGameInputSystem _gameInputSystem;

    [Inject]
    public void Construct(IGameInputSystem gameInputSystem)
    {
        _gameInputSystem = gameInputSystem;
    }

    private void Awake()
    {
        characterController = GetComponent<CharacterController>();
    }

    private void Update()
    {
        HandleMovement();
    }

    private void HandleMovement()
    {
        Vector2 movementInputVector = _gameInputSystem.GetMovementVectorNormalized();
        movementVector = new Vector3(movementInputVector.x,0,movementInputVector.y);

        characterController.Move(movementVector * speed * Time.deltaTime);

        if (movementVector != Vector3.zero)
        {
            gameObject.transform.forward = Vector3.Slerp(transform.forward, movementVector, Time.deltaTime * rotateSpeed); ;
        }
    }

   
}
