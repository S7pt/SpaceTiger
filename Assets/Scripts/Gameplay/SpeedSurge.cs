using System.Collections;
using UnityEngine;

public class SpeedSurge : AbilityBase
{
	private const string AFFECTED = "Affected";
	private const string PLAYER = "Player";
	[SerializeField] private float _bonusSpeed;
	[SerializeField] private float _buffDuration;

	public override void Execute(PlayerController player)
	{
		StartCoroutine(nameof(ExecuteRoutine), player);
	}

	private IEnumerator ExecuteRoutine(PlayerController player)
	{
		player.bonusSpeed += _bonusSpeed;
		player.gameObject.layer = LayerMask.NameToLayer(AFFECTED);
		yield return new WaitForSeconds(_buffDuration);
		player.bonusSpeed -= _bonusSpeed;
		player.gameObject.layer = LayerMask.NameToLayer(PLAYER);
	}
}
