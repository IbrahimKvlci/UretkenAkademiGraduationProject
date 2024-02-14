using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerStartingAttackState : PlayerStateBase
{
    private float startingAttackSpeedTimer;

    public PlayerStartingAttackState(Player player, IPlayerStateService playerStateService) : base(player, playerStateService)
    {
    }

    public override void EnterState()
    {
        base.EnterState();
        Debug.Log("Player Attack state");
    }

    public override void UpdateState()
    {
        base.UpdateState();
        startingAttackSpeedTimer += Time.deltaTime;
        if (startingAttackSpeedTimer > _player.PlayerSO.startingAttackSpeed)
        {
            startingAttackSpeedTimer = 0;
            _playerStateService.SwitchState(_player.PlayerAttackState);
        }
    }

    public override void ExitState()
    {
        base.ExitState();
    }
}
