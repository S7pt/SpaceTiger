using System;
using UnityEngine;
using UnityEngine.UI;

public class GameStateHandler : MonoBehaviour
{
    [SerializeField] private PlayerStateHandler _playerState;
    [SerializeField] private GameOverWindow _gameOverWindow;
    [SerializeField] private GamePausedWindow _gamePausedWindow;
	[SerializeField] private Button _pauseButton;

	private void Start()
	{
		_gamePausedWindow.ContinueButtonClicked += OnGameContinued;
		_playerState.PlayerDied += OnPlayerDied;
		_pauseButton.onClick.AddListener(OnPaused);
		SetState(GameState.ACTIVE);
	}

	private void OnDestroy()
	{
		_gamePausedWindow.ContinueButtonClicked -= OnGameContinued;
		_playerState.PlayerDied -= OnPlayerDied;
		_pauseButton.onClick.RemoveListener(OnPaused);
	}

	private void OnPaused()
	{
		SetState(GameState.PAUSED);
	}

	private void OnPlayerDied()
	{
		SetState(GameState.ENDED);
	}

	private void OnGameContinued()
	{
		SetState(GameState.ACTIVE);
	}

	private void SetState(GameState state)
	{
		switch (state)
		{
			case GameState.ACTIVE:
			{
				_gamePausedWindow.Disable();
				_playerState.SetState(PlayerState.ALIVE);
				break;
			}
			case GameState.PAUSED:
			{
				_gamePausedWindow.Enable();
				_playerState.SetState(PlayerState.PAUSED);
				break;
			}
			case GameState.ENDED:
			{
				_gameOverWindow.Enable();
				break;
			}
		}
	}
}
