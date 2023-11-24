using System;
using UnityEngine;

public class PlayerStateHandler : MonoBehaviour
{
	[SerializeField] private PlayerController _controller;
	[SerializeField] private Rigidbody2D _playerRB;
    private PlayerState _currentState;

	public event Action PlayerDied;

    public void SetState(PlayerState state)
	{
		_currentState = state;
		switch (_currentState)
		{
			case PlayerState.ALIVE :
			{
				_controller.enabled = true;
				_playerRB.bodyType = RigidbodyType2D.Dynamic;
				break;
			}
			case PlayerState.DEAD :
			{
				PlayerDied?.Invoke();
				Destroy(_controller.gameObject);
				break;
			}
			case PlayerState.PAUSED:
			{
				_controller.enabled = false;
				_playerRB.bodyType = RigidbodyType2D.Kinematic;
				break;
			}
		}
	}
}
