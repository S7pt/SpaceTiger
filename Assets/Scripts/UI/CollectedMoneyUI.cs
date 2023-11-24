using TMPro;
using UnityEngine;

public class CollectedMoneyUI : MonoBehaviour
{
    [SerializeField] private CollectedMoneyManager _manager;
    [SerializeField] private TMP_Text _money;

	private void Start()
	{
		_manager.MoneyAmountChanged += this.OnMoneyAmountChanged;
	}

	private void OnMoneyAmountChanged(int money)
	{
		_money.text = money.ToString();
	}
}
