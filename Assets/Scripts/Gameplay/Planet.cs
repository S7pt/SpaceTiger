using System.Collections.Generic;
using UnityEngine;

public class Planet : MonoBehaviour
{
	[SerializeField] private SpriteRenderer _planetRenderer;
	[SerializeField] private List<Field> _planetFields;
	private Rigidbody2D _playerRb;
	private int _currentFieldId;
	public SpriteRenderer Renderer => _planetRenderer;

	private void Start()
	{
		for(int i = 0; i < _planetFields.Count; i++)
		{
			_planetFields[i].Init(i);
			_planetFields[i].FieldEntered += OnFieldEntered;
			_planetFields[i].FieldLeft += OnFieldLeft;
		}
	}

	private void OnFieldLeft(int id, Rigidbody2D player)
	{
		_currentFieldId = id;
		if(_currentFieldId == 0 && _playerRb == player)
		{
			_playerRb.velocity = Vector3.zero;
			_playerRb = null;
		}
	}

	private void Update()
	{
		if(_playerRb != null)
		{
			_playerRb.AddForce(((Vector3)_playerRb.position - transform.position).normalized * _planetFields[_currentFieldId].Force * Time.deltaTime * -1);
		}
	}

	private void OnFieldEntered(int id, Rigidbody2D player)
	{
		if(_playerRb == null)
		{
			_playerRb = player;
		}
		_currentFieldId = id;
	}

	private void OnCollisionEnter2D(Collision2D collision)
	{
		if (collision.gameObject.TryGetComponent(out PlayerStateHandler stateHandler))
		{
			stateHandler.SetState(PlayerState.DEAD);
		}
	}

	private void OnDestroy()
	{
		foreach(Field field in _planetFields)
		{
			field.FieldEntered -= OnFieldEntered;
			field.FieldLeft -= OnFieldLeft;
		}
	}
}
