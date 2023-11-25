using System;
using UnityEngine;

public class PlayerMoneyHandler : MonoBehaviour
{
    private const string MONEY = "Money";
    private int _currentAmount;

	public event Action<int> AmountChanged;
	public int Amount => _currentAmount;

	private void Awake()
	{
		_currentAmount = PlayerPrefs.GetInt(MONEY);
	}

	private void OnDestroy()
	{
		PlayerPrefs.SetInt(MONEY, _currentAmount);
	}

	public bool CanAfford(int amount)
	{
		return _currentAmount >= amount;
	}

	public void Spend(int amount)
	{
		_currentAmount -= amount;
		AmountChanged?.Invoke(_currentAmount);
	}
}
