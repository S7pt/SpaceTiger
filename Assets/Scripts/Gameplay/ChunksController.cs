using System;
using System.Collections.Generic;
using UnityEngine;

public class ChunksController : MonoBehaviour
{
	[SerializeField] private GameObject _player;
	[SerializeField] private List<Chunk> _possibleChunks;
    [SerializeField] private Transform _newChunkLocation;
	[SerializeField] private Transform _defaultChunkLocation;
	private List<int> _activeChunkIds;
	private Queue<Chunk> _chunksQueue;
	private float _chunkStep;

	private void Start()
	{
		Setup();
	}

	private void Setup()
	{
		foreach (Chunk chunk in _possibleChunks)
		{
			chunk.Init(_player);
			chunk.transform.position = _defaultChunkLocation.position;
			chunk.ChunkExited += OnChunkExited;
			chunk.ChunkEntered += OnChunkEntered;
		}
		_chunksQueue = new Queue<Chunk>(3);
		_chunkStep = _possibleChunks[0].Renderer.sprite.rect.height / 100f;
		_activeChunkIds = new List<int>(3);
		for (float i = 0, j = _chunkStep * -1; i < 3; i++, j += _chunkStep)
		{
			_activeChunkIds.Add(Utility.RandomExcluding(0, _possibleChunks.Count - 1, _activeChunkIds));
			Chunk activeChunk = _possibleChunks[_activeChunkIds[(int)i]];
			activeChunk.ResetChunk();
			activeChunk.transform.position = new Vector3(0, j, 0);
			_chunksQueue.Enqueue(activeChunk);
		}
		
		_newChunkLocation.position = new Vector3(0, _chunkStep * (_activeChunkIds.Count - 1), 0);
	}

	private void OnChunkEntered(Chunk chunk)
	{
		int index = _possibleChunks.IndexOf(chunk);
		if (!_activeChunkIds.Contains(index))
		{
			_activeChunkIds.Add(_possibleChunks.IndexOf(chunk));
		}
	}

	private void OnChunkExited(Chunk chunk)
	{
		Chunk chunkToRemove = _chunksQueue.Dequeue();
		int newChunkId = Utility.RandomExcluding(0, _possibleChunks.Count - 1, _activeChunkIds);
		int chunkToRemoveId = _possibleChunks.IndexOf(chunkToRemove);
		_activeChunkIds[_activeChunkIds.IndexOf(chunkToRemoveId)] = newChunkId;
		chunkToRemove.transform.position = _defaultChunkLocation.transform.position;
		Chunk newChunk = _possibleChunks[newChunkId];
		newChunk.transform.position = _newChunkLocation.position;
		newChunk.ResetChunk();
		Vector3 newSpawnPosition = new Vector3(0, _newChunkLocation.position.y + _chunkStep, 0);
		_newChunkLocation.position = newSpawnPosition;
		_chunksQueue.Enqueue(newChunk);
	}

	private void OnDestroy()
	{
		foreach (Chunk chunk in _possibleChunks)
		{
			chunk.ChunkEntered -= OnChunkEntered;
			chunk.ChunkExited -= OnChunkExited;
		}
	}
}
