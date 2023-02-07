using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class ShopManager : MonoBehaviour
{
    public int coins;
    public TMP_Text coinUI;
    public ShopItemSO[] shopItemsSO;
    public GameObject[] shopPanelsGO;
    public ShopTemplate[] shopPanels;
    public Button[] myPurchaseBtns;

    // Start is called before the first frame update
    void Start()
    {

        for (int i = 0; i < shopItemsSO.Length; i++)
        {
            shopPanelsGO[i].SetActive(true);
        }
        if (EncryptedPlayerPrefs.HasKey("123Vasic")) {
            coins = EncryptedPlayerPrefs.GetInt("123Vasic");
        }
        coinUI.text = "Coins: " + coins.ToString();
        LoadPanels();
        CheckPurchaseable(); 
    }

    public void AddCoins() { 
        coins+=10;
        EncryptedPlayerPrefs.SetInt("123Vasic", coins);
        coinUI.text = "Coins: " + coins.ToString();
        CheckPurchaseable();
    }

    public void LoadPanels() { 
        for (int i = 0; i < shopItemsSO.Length; i++)
        {
            shopPanels[i].titleTxt.text = shopItemsSO[i].title;
            shopPanels[i].descriptionTxt.text = shopItemsSO[i].description;
            shopPanels[i].costTxt.text = "Coins: " + shopItemsSO[i].baseCost.ToString();
        }
    }

    public void PuchaseItem(int btnNum)
    {
        if (coins >= shopItemsSO[btnNum].baseCost)
        {
            coins -= shopItemsSO[btnNum].baseCost;
            EncryptedPlayerPrefs.SetInt("123Vasic", coins);
            coinUI.text = "Coins: " + coins.ToString();
            CheckPurchaseable() ;
        }
    }

    public void CheckPurchaseable()
    {
        for (int i = 0; i < shopItemsSO.Length; i++)
        {
            if (coins >= shopItemsSO[i].baseCost)
                myPurchaseBtns[i].interactable = true;
            else
                myPurchaseBtns[i].interactable = false;
        }   
    }

}
