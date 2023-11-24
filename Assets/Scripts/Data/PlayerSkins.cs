using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "PlayerSkinData", menuName = "ScriptableObjects/PlayerSkins", order = 1)]
public class PlayerSkins : ScriptableObject
{
    [SerializeField] public List<Skin> Skins;
    [SerializeField] public int SelectedId;
}

[System.Serializable]
public class Skin
{
    public Sprite Preview;
    public Sprite Sprite;
    public string Name;
    public bool IsBought;
    public int Price;
}

