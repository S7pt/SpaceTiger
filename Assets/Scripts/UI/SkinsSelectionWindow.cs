using System;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class SkinsSelectionWindow : UIWindow
{
	[SerializeField] private SkinsSelectionHandler _skinsHandler;
	[SerializeField] private TMP_Text _playerMoney;
	[SerializeField] private Button _backButton;
	[SerializeField] private PlayerMoneyHandler _moneyHandler;

	private void Start()
	{
		_skinsHandler.Init();
		_backButton.onClick.AddListener(OnBackButtonClicked);
		_moneyHandler.AmountChanged += OnAmountChanged;
		_playerMoney.text = _moneyHandler.Amount.ToString();
	}

	private void OnAmountChanged(int money)
	{
		_playerMoney.text = money.ToString();
	}

	private void OnBackButtonClicked()
	{
		Disable();
	}

	private void OnDestroy()
	{
		_backButton.onClick.RemoveListener(OnBackButtonClicked);
		_moneyHandler.AmountChanged -= OnAmountChanged;
	}
}
