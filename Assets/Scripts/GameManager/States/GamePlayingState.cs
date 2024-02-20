using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GamePlayingState : GameStateBase
{
    public GamePlayingState(GameManager gameManager,IGameStateService gameStateService) : base(gameManager, gameStateService)
    {
    }

    public override void EnterState()
    {
        base.EnterState();
        Player.Instance.PlayerAnimationHandler.OnPlayerDeathAnimationFinished += PlayerAnimationHandler_OnPlayerDeathAnimationFinished;

    }

    private void PlayerAnimationHandler_OnPlayerDeathAnimationFinished(object sender, System.EventArgs e)
    {
        _gameManager.IsGameOver = true;
    }

    public override void UpdateState()
    {
        base.UpdateState();
    }

    public override void ExitState()
    {
        base.ExitState();
    }
}
