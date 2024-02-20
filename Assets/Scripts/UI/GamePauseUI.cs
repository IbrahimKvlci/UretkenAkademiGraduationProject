using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GamePauseUI : MonoBehaviour
{
    [SerializeField] private Button resumeBtn;

    private void Start()
    {
        GameManager.Instance.OnGamePauseChanged += GameManager_OnGamePauseChanged;

        resumeBtn.onClick.AddListener(() =>
        {
            GameManager.Instance.IsGamePaused=false;
        });

        gameObject.SetActive(false);
    }

    private void GameManager_OnGamePauseChanged(object sender, System.EventArgs e)
    {
        if (GameManager.Instance.IsGamePaused)
        {
            Show();
        }
        else
        {
            Hide();
        }
    }

    private void Show()
    {
        gameObject.SetActive(true);
    }

    private void Hide()
    {
        gameObject.SetActive(false);
    }
}
