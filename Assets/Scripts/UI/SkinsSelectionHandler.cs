using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SkinsSelectionHandler : UIWindow
{
    [SerializeField] private PlayerSkins _skinData;
	[SerializeField] private SkinPanel _panelPrefab;
	[SerializeField] private SkinPurchaseWindow _purchaseWindow;
	private List<SkinPanel> _skinPanels;

	public void Init()
	{
		_skinPanels = new List<SkinPanel>(_skinData.Skins.Count);
		_purchaseWindow.SkinPurchased += OnSkinPurchased;
		for(int i = 0; i < _skinData.Skins.Count; i++)
		{
			SkinPanel mappedSkin = Instantiate(_panelPrefab, transform);
			mappedSkin.Init(_skinData.Skins[i], i, i == _skinData.SelectedId);
			mappedSkin.SkinSelected += OnSkinSelected;
			mappedSkin.LockedSkinSelected += OnLockedSkinSelected;
			_skinPanels.Add(mappedSkin);
		}
	}

	private void OnSkinPurchased(int id)
	{
		_skinData.Skins[id].IsBought = true;
		_skinPanels[id].Init(_skinData.Skins[id], id, id == _skinData.SelectedId);
	}

	private void OnLockedSkinSelected(int id)
	{
		_purchaseWindow.Init(_skinData.Skins[id], id);
	}

	private void OnSkinSelected(int id)
	{
		_skinPanels[_skinData.SelectedId].SetSelected(false);
		_skinPanels[id].SetSelected(true);
		_skinData.SelectedId = id;
	}

	private void OnDestroy()
	{
		foreach(SkinPanel panel in _skinPanels)
		{
			panel.SkinSelected -= OnSkinSelected;
		}
	}
}
