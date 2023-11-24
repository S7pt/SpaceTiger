using UnityEngine;
using UnityEngine.UI;

public class SettingsWindow : UIWindow
{
	[SerializeField] private Button _backButton;

	private void Start()
	{
		_backButton.onClick.AddListener(OnBackButtonClicked);
	}

	private void OnBackButtonClicked()
	{
		Disable();
	}

	private void OnDestroy()
	{
		_backButton.onClick.RemoveListener(OnBackButtonClicked);
	}
}
