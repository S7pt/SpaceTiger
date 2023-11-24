using System;
using UnityEngine;
using UnityEngine.UI;

public class PlayerInput : MonoBehaviour
{
	[SerializeField] private Camera _playerCamera;
	[SerializeField] private AbilityButton _abilityButton;

	public event Action AbilityActivated;
	public int HorizontalInputData { get; set; }

	private void Start()
	{
		_abilityButton.AbilityUsed += OnAbilityUsed;
	}

	private void Update()
	{
		HandleInput();
	}

	private void OnDestroy()
	{
		_abilityButton.AbilityUsed -= OnAbilityUsed;
	}

	private void OnAbilityUsed()
	{
		AbilityActivated?.Invoke();
	}

	private void HandleInput()
	{
		HorizontalInputData = 0;
		if (Input.touchCount == 0)
		{
			return;
		}
		Touch playerTouch = Input.GetTouch(0);
		if (playerTouch.position.x > _playerCamera.pixelWidth / 2)
		{
			HorizontalInputData += 1;
		}
		else if (playerTouch.position.x < _playerCamera.pixelWidth / 2)
		{
			HorizontalInputData -= 1;
		}
	}
}
