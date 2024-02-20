using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance { get; set; }

    private bool isGamePaused;

    private void Awake()
    {
        Instance = this;
    }

    private void Start()
    {
        isGamePaused = false;
    }

    public void TogglePause()
    {
        isGamePaused = !isGamePaused;

        if(isGamePaused )
        {
            Time.timeScale = 0f;

        }
        else
        {
            Time.timeScale=1f;
        }
    }
}
