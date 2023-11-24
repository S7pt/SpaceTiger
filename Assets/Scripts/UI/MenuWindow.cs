using System;
using UnityEngine;
using UnityEngine.UI;

public class MenuWindow : UIWindow
{
    [SerializeField] private Button _playButton;
	[SerializeField] private Button _settingsButton;
	[SerializeField] private Button _skinsButton;
	[SerializeField] private GameLoader _loader;
	[SerializeField] private SkinsSelectionWindow _skinsWindow;
	[SerializeField] private SettingsWindow _settingsWindow;

	private void Start()
	{
		_playButton.onClick.AddListener(OnPlayGameClicked);
		_skinsButton.onClick.AddListener(OnSkinsMenuClicked);
		_settingsButton.onClick.AddListener(OnSettingsMenuClicked);
	}

	private void OnSettingsMenuClicked()
	{
		_settingsWindow.Enable();
	}

	private void OnSkinsMenuClicked()
	{
		_skinsWindow.Enable();
	}

	private void OnPlayGameClicked()
	{
		_loader.StartGame();
	}

	private void OnDestroy()
	{
		_playButton.onClick.RemoveListener(OnPlayGameClicked);
		_skinsButton.onClick.RemoveListener(OnSkinsMenuClicked);
		_settingsButton.onClick.RemoveListener(OnSettingsMenuClicked);
	}
}
