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

    public ShopSkinSO[] shopSkinSO;
    public GameObject[] shopPanelsGO_skin;
    public ShopSkin[] shopPanels_skin;
    public Button[] myPurchaseBtns_skin;
    public Button[] myEquipBtns_skin;

    private static int MAXIMUM_POWER = 7;

    // Start is called before the first frame update
    void Start()
    {

        for (int i = 0; i < shopItemsSO.Length; i++)
        {
            shopPanelsGO[i].SetActive(true);
            shopPanelsGO[i].transform.GetChild(2).GetComponent<Image>().sprite = Resources.Load<Sprite>(shopItemsSO[i].title_of_image);
        }
        for (int i = 0; i < shopSkinSO.Length; i++)
        {
            shopPanelsGO_skin[i].SetActive(true);
            shopPanelsGO_skin[i].transform.GetChild(2).GetComponent<Image>().sprite = Resources.Load<Sprite>(shopSkinSO[i].title_of_image);
        }

        EncryptedPlayerPrefs.SetInt("PurchasedSkinKey0", 1);
        coins = EncryptedPlayerPrefs.GetInt("NumberOfCoinsKey");
        
        coinUI.text = coins.ToString();
        LoadPanels();
        CheckPurchaseable();
    }

    public void AddCoins() { 
        coins+=1000;
        EncryptedPlayerPrefs.SetInt("NumberOfCoinsKey", coins);
        coinUI.text = coins.ToString();
        CheckPurchaseable();
    }

    public void LoadPanels() {
        for (int i = 0; i < shopItemsSO.Length; i++)
        {
            //Debug.Log(EncryptedPlayerPrefs.GetInt(shopItemsSO[i].powerKey));

            shopPanels[i].titleTxt.text = shopItemsSO[i].title;
            shopPanels[i].descriptionTxt.text = shopItemsSO[i].description;
            shopPanels[i].costTxt.text = (shopItemsSO[i].baseCost + EncryptedPlayerPrefs.GetInt(shopItemsSO[i].pricePowerKey)).ToString();
            for (int j = 0; j < EncryptedPlayerPrefs.GetInt(shopPanels[i].powerKey); j++)
            {
                shopPanels[i].rawImage[j].gameObject.SetActive(true);
            }
        }
        for (int i = 0; i < shopSkinSO.Length; i++)
        {
            //Debug.Log(EncryptedPlayerPrefs.GetInt(shopItemsSO[i].powerKey));

            shopPanels_skin[i].titleTxt.text = shopSkinSO[i].title;
            //shopPanels_skin[i].descriptionTxt.text = shopSkinSO[i].description; TO REMOVE
            shopPanels_skin[i].costTxt.text = shopSkinSO[i].baseCost.ToString();
            if (EncryptedPlayerPrefs.GetInt(shopSkinSO[i].isPurchasedKey) == 0)
            {
                myPurchaseBtns_skin[i].gameObject.SetActive(true);
                myEquipBtns_skin[i].gameObject.SetActive(false);
            }
            else
            {
                myPurchaseBtns_skin[i].gameObject.SetActive(false);
                myEquipBtns_skin[i].gameObject.SetActive(true);
                if(EncryptedPlayerPrefs.GetInt("EquipedSkinKey") == i)
                {
                    //Debug.Log("USO " + EncryptedPlayerPrefs.GetInt("EquipedSkinKey"));
                    myEquipBtns_skin[i].GetComponentInChildren<TMP_Text>().text = "Equiped";    
                    myEquipBtns_skin[i].interactable = false;
                }else
                {
                    myEquipBtns_skin[i].interactable = true;
                }
            }
        }
    }
    public void PuchaseItem(int btnNum)
    {
        //Debug.Log(btnNum);
        if (coins >= shopItemsSO[btnNum].baseCost + EncryptedPlayerPrefs.GetInt(shopItemsSO[btnNum].pricePowerKey)) 
        {
            coins -= shopItemsSO[btnNum].baseCost + EncryptedPlayerPrefs.GetInt(shopItemsSO[btnNum].pricePowerKey);
            EncryptedPlayerPrefs.SetInt("NumberOfCoinsKey", coins);
            coinUI.text = coins.ToString();
            EncryptedPlayerPrefs.SetInt(shopItemsSO[btnNum].powerKey, EncryptedPlayerPrefs.GetInt(shopItemsSO[btnNum].powerKey) + 1);
            //EncryptedPlayerPrefs.SetInt(shopItemsSO[btnNum].powerCostValue, EncryptedPlayerPrefs.GetInt(shopItemsSO[btnNum].powerCostValue) + 1);
            EncryptedPlayerPrefs.SetInt(shopItemsSO[btnNum].pricePowerKey, EncryptedPlayerPrefs.GetInt(shopItemsSO[btnNum].pricePowerKey) + EncryptedPlayerPrefs.GetInt(shopItemsSO[btnNum].powerKey) * 100);
            Debug.Log(shopItemsSO[btnNum].powerKey + "   ovolko     " + EncryptedPlayerPrefs.GetInt(shopItemsSO[btnNum].powerKey));
        }
        CheckPurchaseable();
        LoadPanels(); 
    }

    public void purchaseSkin(int btnNum) {
        if (coins >= shopSkinSO[btnNum].baseCost)
        {
            coins -= shopSkinSO[btnNum].baseCost;
            EncryptedPlayerPrefs.SetInt("NumberOfCoinsKey", coins);
            coinUI.text = coins.ToString();
            EncryptedPlayerPrefs.SetInt(shopSkinSO[btnNum].isPurchasedKey, 1);
        }
        CheckPurchaseable();
        LoadPanels();
    }

    public void equipSkin(int btnNum) {
        myEquipBtns_skin[EncryptedPlayerPrefs.GetInt("EquipedSkinKey")].GetComponentInChildren<TMP_Text>().text = "Equip";  
        EncryptedPlayerPrefs.SetInt("EquipedSkinKey", btnNum);
        myEquipBtns_skin[btnNum].GetComponentInChildren<TMP_Text>().text = "Equiped";
        LoadPanels();
    }

    public void CheckPurchaseable()
    {
        for (int i = 0; i < shopItemsSO.Length; i++)
        {
            if (coins >= shopItemsSO[i].baseCost + EncryptedPlayerPrefs.GetInt(shopItemsSO[i].pricePowerKey) && EncryptedPlayerPrefs.GetInt(shopPanels[i].powerKey) < MAXIMUM_POWER)
                myPurchaseBtns[i].interactable = true;
            else
                myPurchaseBtns[i].interactable = false;
        }
        for (int i = 0; i < shopSkinSO.Length; i++)
        {
            if (coins >= shopSkinSO[i].baseCost)
                myPurchaseBtns_skin[i].interactable = true;
            else
                myPurchaseBtns_skin[i].interactable = false;
        }
    }
    //RESET BUTTON ONLY FOR DEVELOPER----------------------------------------------------
    public void RestartAllPowerAndCoins()
    {
        EncryptedPlayerPrefs.SetInt("PurchasedSkinKey1", 0);
        EncryptedPlayerPrefs.SetInt("PurchasedSkinKey2", 0);
        EncryptedPlayerPrefs.SetInt("PurchasedSkinKey0", 1);
        EncryptedPlayerPrefs.SetInt("EquipedSkinKey", 0);
        for (int i = 0; i < shopItemsSO.Length; i++)
        {
            EncryptedPlayerPrefs.SetInt(shopPanels[i].powerKey, 0);
            EncryptedPlayerPrefs.SetInt(shopPanels[i].pricePowerKey, 0);
            
        }
        for (int i = 0; i < shopSkinSO.Length; i++) {
            myEquipBtns_skin[i].GetComponentInChildren<TMP_Text>().text = "Equip";
        }
        baseCostReset();
        EncryptedPlayerPrefs.SetInt("NumberOfCoinsKey", 0);
        coins = EncryptedPlayerPrefs.GetInt("NumberOfCoinsKey");
        coinUI.text = coins.ToString();
        powerUpgradeReset();
        CheckPurchaseable();
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
