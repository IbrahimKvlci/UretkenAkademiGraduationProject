using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Zenject;

public class PlayerTriggerCheck : MonoBehaviour
{
    [SerializeField] private Player player;

    [SerializeField] private LayerMask layerMask;
    [SerializeField] private float range;

    private IPlayerTriggerCheckService _playerTriggerCheckService;

    [Inject]
    public void Construct(IPlayerTriggerCheckService playerTriggerCheckService)
    {
        _playerTriggerCheckService = playerTriggerCheckService;
    }

    private void Update()
    {
        if(_playerTriggerCheckService.IsEnemyTriggeredToBeAttacked(transform,out Enemy enemy, player.WeaponSO.length, layerMask))
        {
            player.EnemyTriggeredToBeAttacked= enemy;
        }
        else
        {
            player.EnemyTriggeredToBeAttacked = null;
        }
    }

    public bool IsEnemiesTriggeredToBeAttacked(out List<Enemy> enemies,float range)
    {
        return _playerTriggerCheckService.IsEnemiesTriggeredToBeAttacked(transform, out enemies, range, layerMask);
    }

    public bool IsInteractableObjectTriggered(out IInteractable interactable)
    {
        return _playerTriggerCheckService.IsInteractableObjectTriggered(transform, out interactable,range);
    }
}
