using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameOverUI : MonoBehaviour
{
    private void Start()
    {
        Player.Instance.PlayerAnimationHandler.OnPlayerDeathAnimationFinished += PlayerAnimationHandler_OnPlayerDeathAnimationFinished;

        Hide();
    }

    private void PlayerAnimationHandler_OnPlayerDeathAnimationFinished(object sender, System.EventArgs e)
    {
        Show();
    }

    private void PlayerHealthService_OnPlayerDeath(object sender, System.EventArgs e)
    {
        Show();
    }

    private void Hide()
    {
        gameObject.SetActive(false);
    }

    private void Show()
    {
        gameObject.SetActive(true);
    }
}
