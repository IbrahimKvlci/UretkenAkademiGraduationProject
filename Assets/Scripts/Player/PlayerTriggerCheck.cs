using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Zenject;

public class PlayerTriggerCheck : MonoBehaviour
{
    [SerializeField] private Player player;

    [SerializeField] LayerMask layerMask;

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
    }
}
