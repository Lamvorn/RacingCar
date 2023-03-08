using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

[CreateAssetMenuAttribute(fileName = "shopMenu", menuName = "Scriptable Objects/New Shop Item", order = 1)]
public class ShopItemSO : ScriptableObject
{
    public string title;
    public string description;
    public int baseCost;
    public string powerKey;
    public string pricePowerKey;
    public string title_of_image;
}
