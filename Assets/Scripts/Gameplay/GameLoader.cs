using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameLoader : MonoBehaviour
{
	[SerializeField] private GameObject _loadingScreen;
    [SerializeField] private int _gameSceneId;
	[SerializeField] private float _loadingDuration;

	public void StartGame()
	{
		StartCoroutine(nameof(StartGameRoutine));
	}

	public IEnumerator StartGameRoutine()
	{
		_loadingScreen.SetActive(true);
		yield return new WaitForSeconds(_loadingDuration);
		SceneManager.LoadScene(_gameSceneId);
		_loadingScreen.SetActive(false);
	}
}
