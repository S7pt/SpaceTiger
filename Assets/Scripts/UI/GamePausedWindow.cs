using System;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GamePausedWindow : UIWindow
{
    [SerializeField] private Button _continueButton;
    [SerializeField] private Button _exitButton;
	[SerializeField] private int _menuSceneId;

    public event Action ContinueButtonClicked;

	private void Start()
	{
		_exitButton.onClick.AddListener(OnExitButtonClicked);
		this._continueButton.onClick.AddListener(OnContinueButtonClicked);
	}

	private void OnContinueButtonClicked()
	{
		ContinueButtonClicked?.Invoke();
	}

	private void OnExitButtonClicked()
	{
		SceneManager.LoadScene(_menuSceneId);
	}
}
