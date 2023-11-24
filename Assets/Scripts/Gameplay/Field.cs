using System;
using UnityEngine;

public class Field : MonoBehaviour
{
	[SerializeField] private float _fieldForce;
    private int _fieldId;

    public event Action<int, Rigidbody2D> FieldEntered;
	public event Action<int, Rigidbody2D> FieldLeft;
	public float Force => _fieldForce;

    public void Init(int id)
	{
        _fieldId = id;
	}

	private void OnTriggerEnter2D(Collider2D collision)
	{
		if (collision.TryGetComponent(out Rigidbody2D playerRb))
		{
			FieldEntered?.Invoke(_fieldId, playerRb);
		}
	}

	private void OnTriggerExit2D(Collider2D collision)
	{
		if (collision.TryGetComponent(out Rigidbody2D rb))
		{
			FieldLeft?.Invoke(_fieldId, rb);
		}
	}
}
