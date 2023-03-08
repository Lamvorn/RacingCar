using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class TabMenuScript : MonoBehaviour
{
    public TMP_Text m_textComponent1;
    public TMP_Text m_textComponent2;
    public GameObject tabFocus1;
    public GameObject tabFocus2;
    public GameObject powers_shop;
    public GameObject skins_shop;

    public void changeTabButton1() {
        tabFocus1.SetActive(false);
        tabFocus2.SetActive(true);
        m_textComponent2.color =new Color32(246, 225, 156, 255);
        m_textComponent1.color = new Color32(121, 110, 111, 255);
        powers_shop.SetActive(false);
        skins_shop.SetActive(true);
        //m_textComponent.text = " OVO JE NOVI TEXT0";
    }

    public void changeTabButton2()
    {
        powers_shop.SetActive(true);
        skins_shop.SetActive(false);
        tabFocus2.SetActive(false);
        tabFocus1.SetActive(true);
        m_textComponent1.color = new Color32(246, 225, 156, 255);
        m_textComponent2.color = new Color32(121, 110, 111, 255);
        //m_textComponent.text = " OVO JE NOVI TEXT0";
    }
}
