using UnityEngine;

public class Coin : MonoBehaviour
{
	public void SetActive(bool isActive)
	{
		gameObject.SetActive(isActive);
	}

	private void OnTriggerEnter2D(Collider2D collision)
	{
		if (collision.TryGetComponent(out CollectedMoneyManager manager))
		{
			manager.AddMoney();
			SetActive(false);
		}
	}
}
