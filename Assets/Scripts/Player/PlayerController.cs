using UnityEngine;

public class PlayerController : MonoBehaviour
{
    private const float FLOAT_MULTIPLIER = 0.001f;
	[SerializeField] private AbilityBase _playerAbility;
    [SerializeField] private PlayerInput _input;
    [SerializeField] private AnimationCurve _speedCurve;
    [SerializeField] private float _speedMultiplier;
    [SerializeField] private float _initialSpeed;
	public float bonusSpeed = 0;

	private void Start()
	{
		_input.AbilityActivated += ExecuteAbility;
	}

	void Update()
	{
		UpdatePosition();
	}

	private void OnDestroy()
	{
		_input.AbilityActivated -= ExecuteAbility;
	}

	private void UpdatePosition()
	{
		Vector3 newPosition = transform.position;
		float speedValueY = (_initialSpeed + bonusSpeed + (_speedCurve.Evaluate(Time.timeSinceLevelLoad * FLOAT_MULTIPLIER) * _speedMultiplier)) * Time.deltaTime;
		float speedValueX = (_initialSpeed + (_speedCurve.Evaluate(Time.timeSinceLevelLoad * FLOAT_MULTIPLIER) * _speedMultiplier)) * Time.deltaTime;
		newPosition.x += _input.HorizontalInputData * speedValueX;
		newPosition.y += speedValueY;
		transform.position = newPosition;
	}

	public void ExecuteAbility()
	{
		_playerAbility.Execute(this);
	}
}
