using System;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

class SkinPurchaseWindow : UIWindow
{
	[SerializeField] private Button _backButton;
	[SerializeField] private Button _purchaseButton;
	[SerializeField] private Image _skinPreview;
	[SerializeField] private TMP_Text _skinName;
	[SerializeField] private TMP_Text _skinPrice;
	[SerializeField] private PlayerMoneyHandler _moneyHandler;
	private int _price;
	private int _skinId;

	public event Action<int> SkinPurchased;

	public void Init(Skin skin, int id)
	{
		Enable();
		_skinId = id;
		_skinPreview.sprite = skin.Preview;
		_skinName.text = skin.Name;
		_skinPrice.text = skin.Price.ToString();
		_price = skin.Price;
		_backButton.onClick.AddListener(OnBackButtonClicked);
		_purchaseButton.interactable = _moneyHandler.CanAfford(_price);
		if (_moneyHandler.CanAfford(_price))
		{
			_purchaseButton.onClick.AddListener(OnPurchaseButtonClicked);
		}
	}

	private void OnBackButtonClicked()
	{
		Disable();
	}

	private void OnPurchaseButtonClicked()
	{
		if(_moneyHandler.CanAfford(_price))
		{
			_moneyHandler.Spend(_price);
			SkinPurchased?.Invoke(_skinId);
			Disable();
		}
	}
}