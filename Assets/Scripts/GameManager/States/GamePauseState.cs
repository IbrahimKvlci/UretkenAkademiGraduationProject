using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GamePauseState : GameStateBase
{
    private bool playerAlreadyPaused;

    public GamePauseState(GameManager gameManager,IGameStateService gameStateService) : base(gameManager, gameStateService)
    {
    }

    public override void EnterState()
    {
        base.EnterState();
        playerAlreadyPaused = Player.Instance.IsPlayerPaused;
        Player.Instance.IsPlayerPaused= true;
        _gameManager.Pause();
    }



    public override void UpdateState()
    {
        base.UpdateState();

        if (!_gameManager.IsGamePaused)
        {
            _gameStateService.SwitchState(_gameManager.GamePlayingState);
        }
    }

    public override void ExitState()
    {
        base.ExitState();
        _gameManager.Unpause();
        if (!playerAlreadyPaused)
        {
            Player.Instance.IsPlayerPaused = false;
        }
    }
}
