using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameStateBase : IGameState
{
    protected IGameStateService _gameStateService;
    protected GameManager _gameManager;

    public GameStateBase(GameManager gameManager,IGameStateService gameStateService)
    {
        _gameStateService = gameStateService;
        _gameManager = gameManager;
    }

    public virtual void EnterState()
    {
    }

    public virtual void ExitState()
    {
    }

    public virtual void UpdateState()
    {
        if(this is not GameOverState)
        {
            //State is not GameOverState
            if (_gameManager.IsGameOver)
            {
                _gameStateService.SwitchState(_gameManager.GameOverState);
            }
        }

        if(this is not GamePauseState)
        {
            if (_gameManager.IsGamePaused)
            {
                _gameStateService.SwitchState(_gameManager.GamePauseState);
            }
        }
    }
}
