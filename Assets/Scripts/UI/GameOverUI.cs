using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameOverUI : MonoBehaviour
{
    [SerializeField] private Button gameOverBtn;

    private void Start()
    {
        Player.Instance.PlayerAnimationHandler.OnPlayerDeathAnimationFinished += PlayerAnimationHandler_OnPlayerDeathAnimationFinished;

        gameOverBtn.onClick.AddListener(() =>
        {
            Loader.Load(Loader.Scene.GameScene);
        });

        Hide();
    }

    private void PlayerAnimationHandler_OnPlayerDeathAnimationFinished(object sender, System.EventArgs e)
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
