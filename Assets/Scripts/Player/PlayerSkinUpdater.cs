using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerSkinUpdater : MonoBehaviour
{
    [SerializeField] private PlayerSkins _skinsData;
    [SerializeField] private SpriteRenderer _playerRenderer;

	private void Awake()
	{
		_playerRenderer.sprite = _skinsData.Skins[_skinsData.SelectedId].Sprite;	
	}
}
