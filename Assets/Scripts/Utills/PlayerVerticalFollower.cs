using UnityEngine;

public class PlayerVerticalFollower : MonoBehaviour
{
	[SerializeField] private Transform _player;
	[SerializeField] private Vector3 _offset;


	private void Update()
	{
		UpdatePosition();
	}

	private void UpdatePosition()
	{
		if (_player != null)
		{
			Vector3 newPosition = new Vector3(0, _player.transform.position.y, 0) + _offset;
			transform.position = newPosition;
		}
	}
}
