using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class SkinPanel : MonoBehaviour
{
    [SerializeField] private Button _selectionButton;
    [SerializeField] private Button _lockedPanel;
    [SerializeField] private Image _skinPreview;
    [SerializeField] private GameObject _selectedText;
    [SerializeField] private TMP_Text _priceText;
    [SerializeField] private TMP_Text _skinName;
    private int _skinId;

    public event Action<int> SkinSelected;
    public event Action<int> LockedSkinSelected;

    public void Init(Skin skin, int id, bool isSelected)
    {
        _skinName.text = skin.Name;
        _selectionButton.onClick.AddListener(OnSelectionButtonClicked);
        _skinPreview.sprite = skin.Preview;
        _selectedText.SetActive(isSelected);
        _lockedPanel.gameObject.SetActive(!skin.IsBought);
        _lockedPanel.onClick.AddListener(OnLockedSkinClicked);
        _priceText.text = skin.Price.ToString();

        _skinId = id;
    }

	private void OnLockedSkinClicked()
	{
        LockedSkinSelected?.Invoke(_skinId);
	}

	private void OnSelectionButtonClicked()
	{
        SkinSelected?.Invoke(_skinId);
	}

	public void SetSelected(bool isSelected)
	{
        _selectedText.SetActive(isSelected);
	}
}
