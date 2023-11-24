using System;
using System.Collections.Generic;
using UnityEngine;

public class Chunk : MonoBehaviour
{
	[SerializeField] private SpriteRenderer _renderer;
	[SerializeField] private List<Planet> _planets;
	[SerializeField] private List<Coin> _coins;
	private GameObject _player;

	public event Action<Chunk> ChunkEntered;
	public event Action<Chunk> ChunkExited;

	public SpriteRenderer Renderer => _renderer;

	private void OnTriggerExit2D(Collider2D other)
	{
		if(other.gameObject == _player)
		{
			ChunkExited?.Invoke(this);
		}
	}

	private void OnTriggerEnter2D(Collider2D other)
	{
		if (other.gameObject == _player)
		{
			ChunkEntered?.Invoke(this);
		}
	}

	public void Init(GameObject player)
	{
		_player = player;
		if (_renderer == null)
		{
			_renderer = GetComponent<SpriteRenderer>();
		}
	}

	public void ResetChunk()
	{
		foreach(Coin coin in _coins)
		{
			coin.SetActive(true);
		}
		foreach(Planet planet in _planets)
		{
			planet.Renderer.color = Utility.RandomColor();
		}
	}
}
