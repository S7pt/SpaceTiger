using System;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class AbilityButton : MonoBehaviour
{
    [SerializeField] private Button _abilityUIButton;
	[SerializeField] private TMP_Text _cooldownText;
	[SerializeField] private GameObject _cooldownPanel;
    [SerializeField] private AbilityBase _ability;
	private float _lastUsageTime = 0;
	private bool _isOnCooldown;
	private float _cooldown;

	public event Action AbilityUsed;

	private void Start()
	{
		_abilityUIButton.onClick.AddListener(OnAbilityUsed);
	}

	private void Update()
	{
		_cooldown -= Time.deltaTime;
		_isOnCooldown = _cooldown > 0;
		_cooldownPanel.SetActive(_isOnCooldown);
		if (_isOnCooldown)
		{
			_cooldownText.text = $"{(int)(_cooldown / 60)}:{(int)(_cooldown % 60)}";
		}
	}

	private void OnAbilityUsed()
	{
		if (!_isOnCooldown)
		{
			AbilityUsed?.Invoke();
			_lastUsageTime = Time.time;
			_isOnCooldown = true;
			_cooldown = _ability.Cooldown;
		}
	}
}
