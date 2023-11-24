using System;
using UnityEngine;

public class CollectedMoneyManager : MonoBehaviour
{
	private const string MONEY = "Money";
	private int _currentMoneyAmount;

	public event Action<int> MoneyAmountChanged;

    public void AddMoney()
	{
		_currentMoneyAmount++;
		MoneyAmountChanged?.Invoke(_currentMoneyAmount);
	}

	private void OnDestroy()
	{
		SaveMoney();
	}

	private void SaveMoney()
	{
		int playerMoney = PlayerPrefs.GetInt(MONEY);
		playerMoney += _currentMoneyAmount;
		PlayerPrefs.SetInt(MONEY, playerMoney);
	}
}
