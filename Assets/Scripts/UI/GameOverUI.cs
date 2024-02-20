using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameOverUI : MonoBehaviour
{

    [SerializeField] private Button gameOverBtn;

    private void Start()
    {
        GameManager.Instance.OnGameOverChanged += GameManager_OnGameOverChanged;

        gameOverBtn.onClick.AddListener(() =>
        {
            Loader.Load(Loader.Scene.GameScene);
        });

        Hide();
    }

    private void GameManager_OnGameOverChanged(object sender, System.EventArgs e)
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
