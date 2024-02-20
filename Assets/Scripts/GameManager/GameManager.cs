using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Zenject;

public class GameManager : MonoBehaviour
{
    public event EventHandler OnGameOverChanged;
    public event EventHandler OnGamePauseChanged;

    public static GameManager Instance { get; set; }

    private bool _isGameOver = false;
    public bool IsGameOver
    {
        get { 
            return _isGameOver;
        }
        set { 
            _isGameOver = value;

            OnGameOverChanged?.Invoke(this, EventArgs.Empty);
        }
    }

    private bool _isGamePaused=false;
    public bool IsGamePaused
    {
        get
        {
            return _isGamePaused;
        }
        set
        {
            _isGamePaused = value;

            OnGamePauseChanged?.Invoke(this, EventArgs.Empty);
        }
    }

    private IGameStateService gameStateService;

    public IGameState GamePlayingState { get; set; }
    public IGameState GameOverState { get; set; }
    public IGameState GamePauseState { get; set; }

    private IGameInputSystem _gameInputSystem;

    [Inject]
    public void Construct(IGameInputSystem gameInputSystem)
    {
        _gameInputSystem = gameInputSystem;
    }

    private void Awake()
    {
        Instance = this;

        gameStateService = new GameStateManager();

        GamePlayingState = new GamePlayingState(this,gameStateService);
        GameOverState = new GameOverState(this,gameStateService);
        GamePauseState=new GamePauseState(this, gameStateService);
    }

    private void Start()
    {
        _gameInputSystem.OnGamePauseKeyPressed += gameInputSystem_OnGamePauseKeyPressed;

        gameStateService.Initialize(GamePlayingState);
    }

    private void gameInputSystem_OnGamePauseKeyPressed(object sender, EventArgs e)
    {
        IsGamePaused = !IsGamePaused;
    }

    private void Update()
    {
        gameStateService.CurrentGameState.UpdateState();
    }

    public void Pause()
    {
        Time.timeScale = 0;
    }

    public void Unpause()
    {
        Time.timeScale = 1;

    }
}
