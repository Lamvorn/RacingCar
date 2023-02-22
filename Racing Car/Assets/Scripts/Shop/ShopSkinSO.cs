using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenuAttribute(fileName = "shopMenu", menuName = "Scriptable Objects/New Shop Skin", order = 2)]
public class ShopSkinSO : ScriptableObject
{
    public string title;
    public string description;
    public int baseCost;
    public string isPurchasedKey;
    public string title_of_image;
}
