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
    private static int MAXIMUM_POWER = 7;

    // Start is called before the first frame update
    void Start()
    {

        for (int i = 0; i < shopItemsSO.Length; i++)
        {
            shopPanelsGO[i].SetActive(true);
        }
        
        coins = EncryptedPlayerPrefs.GetInt("NumberOfCoinsKey");
        
        coinUI.text = "Coins: " + coins.ToString();
        LoadPanels();
        CheckPurchaseable(); 
    }

    public void AddCoins() { 
        coins+=1000;
        EncryptedPlayerPrefs.SetInt("NumberOfCoinsKey", coins);
        coinUI.text = "Coins: " + coins.ToString();
        CheckPurchaseable();
    }

    public void LoadPanels() {
        for (int i = 0; i < shopItemsSO.Length; i++)
        {
            //Debug.Log(EncryptedPlayerPrefs.GetInt(shopItemsSO[i].powerKey));

            shopPanels[i].titleTxt.text = shopItemsSO[i].title;
            shopPanels[i].descriptionTxt.text = shopItemsSO[i].description;
            shopPanels[i].costTxt.text = "Coins: " + (shopItemsSO[i].baseCost + EncryptedPlayerPrefs.GetInt(shopItemsSO[i].pricePowerKey)).ToString();
            for (int j = 0; j < EncryptedPlayerPrefs.GetInt(shopPanels[i].powerKey); j++)
            {
                shopPanels[i].rawImage[j].gameObject.SetActive(true);
            }
        }
    }

    public void PuchaseItem(int btnNum)
    {
        if (coins >= shopItemsSO[btnNum].baseCost + EncryptedPlayerPrefs.GetInt(shopItemsSO[btnNum].pricePowerKey)) 
        {
            Debug.Log(shopItemsSO[btnNum].powerKey);
            Debug.Log(EncryptedPlayerPrefs.GetInt(shopItemsSO[btnNum].powerKey));
            coins -= shopItemsSO[btnNum].baseCost + EncryptedPlayerPrefs.GetInt(shopItemsSO[btnNum].pricePowerKey);
            EncryptedPlayerPrefs.SetInt("NumberOfCoinsKey", coins);
            coinUI.text = "Coins: " + coins.ToString();
            EncryptedPlayerPrefs.SetInt(shopItemsSO[btnNum].powerKey, EncryptedPlayerPrefs.GetInt(shopItemsSO[btnNum].powerKey) + 1);
            //EncryptedPlayerPrefs.SetInt(shopItemsSO[btnNum].powerCostValue, EncryptedPlayerPrefs.GetInt(shopItemsSO[btnNum].powerCostValue) + 1);
            EncryptedPlayerPrefs.SetInt(shopItemsSO[btnNum].pricePowerKey, EncryptedPlayerPrefs.GetInt(shopItemsSO[btnNum].pricePowerKey) + EncryptedPlayerPrefs.GetInt(shopItemsSO[btnNum].powerKey) * 100);
            Debug.Log(shopItemsSO[btnNum].powerKey + "   ovolko     " + EncryptedPlayerPrefs.GetInt(shopItemsSO[btnNum].powerKey));
        }
        CheckPurchaseable();
        LoadPanels(); 
    }

    public void CheckPurchaseable()
    {
        for (int i = 0; i < shopItemsSO.Length; i++)
        {
            if (coins >= shopItemsSO[i].baseCost && EncryptedPlayerPrefs.GetInt(shopPanels[i].powerKey) < MAXIMUM_POWER)
                myPurchaseBtns[i].interactable = true;
            else
                myPurchaseBtns[i].interactable = false;
        }   
    }
    //RESET BUTTON ONLY FOR DEVELOPER----------------------------------------------------
    public void RestartAllPowerAndCoins()
    {
        for (int i = 0; i < shopItemsSO.Length; i++)
        {
            EncryptedPlayerPrefs.SetInt(shopPanels[i].powerKey, 0);
            EncryptedPlayerPrefs.SetInt(shopPanels[i].pricePowerKey, 0);
        }
        baseCostReset();
        EncryptedPlayerPrefs.SetInt("NumberOfCoinsKey", 0);
        coins = EncryptedPlayerPrefs.GetInt("NumberOfCoinsKey");
        coinUI.text = "Coins: " + coins.ToString();
        powerUpgradeReset();
        LoadPanels();
        
    }

    private void baseCostReset() {
        for (int i = 0; i < shopItemsSO.Length; i++) {
            shopItemsSO[i].baseCost = 50;
        }
    }

    private void powerUpgradeReset()
    {
        for (int i = 0; i < shopItemsSO.Length; i++)
        {
            shopPanels[i].rawImage[0].gameObject.SetActive(false);
            shopPanels[i].rawImage[1].gameObject.SetActive(false);
            shopPanels[i].rawImage[2].gameObject.SetActive(false);
            shopPanels[i].rawImage[3].gameObject.SetActive(false);
            shopPanels[i].rawImage[4].gameObject.SetActive(false);
            shopPanels[i].rawImage[5].gameObject.SetActive(false);
            shopPanels[i].rawImage[6].gameObject.SetActive(false);
        }
    }
    //END OF RESET BUTTON ONLY FOR DEVELOPER----------------------------------------------------
}
