using System;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameOverWindow : UIWindow
{
    [SerializeField] private Button _exitButton;
    [SerializeField] private Button _restartButton;
	[SerializeField] private int _lobbySceneId;

	private void Start()
	{
		_exitButton.onClick.AddListener(OnExitButtonClicked);
		_restartButton.onClick.AddListener(OnRestartButtonClicked);
	}

	private void OnRestartButtonClicked()
	{
		SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
	}

	private void OnExitButtonClicked()
	{
		SceneManager.LoadScene(_lobbySceneId);
	}

	private void OnDestroy()
	{
		_exitButton.onClick.RemoveListener(OnExitButtonClicked);
		_restartButton.onClick.RemoveListener(OnRestartButtonClicked);
	}
}
