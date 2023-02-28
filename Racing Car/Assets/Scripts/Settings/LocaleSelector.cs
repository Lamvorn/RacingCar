using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Localization.Settings;

public class LocaleSelector : MonoBehaviour
{
    private static string LANGUAGE = "Language";
    public GameObject iconEn;
    public GameObject iconFr;
    public GameObject iconSp;

    private void Awake()
    {
        int language = EncryptedPlayerPrefs.GetInt(LANGUAGE);
        StartCoroutine(SetLocale(language));
        switch (language) {
            case 0:
                iconEn.SetActive(true);
                iconFr.SetActive(false);
                iconSp.SetActive(false);
                break;
            case 1:
                iconEn.SetActive(false);
                iconFr.SetActive(true);
                iconSp.SetActive(false);
                break;
            case 2:
                iconEn.SetActive(false);
                iconFr.SetActive(false);
                iconSp.SetActive(true);
                break;
        }
    }
    public void ChangeLocale() {
        EncryptedPlayerPrefs.SetInt(LANGUAGE, EncryptedPlayerPrefs.GetInt(LANGUAGE)+1);
        if (EncryptedPlayerPrefs.GetInt(LANGUAGE) > 2) {
            EncryptedPlayerPrefs.SetInt(LANGUAGE, 0);
        }
        int language = EncryptedPlayerPrefs.GetInt(LANGUAGE);
        StartCoroutine(SetLocale(language));
        switch (language)
        {
            case 0:
                iconEn.SetActive(true);
                iconFr.SetActive(false);
                iconSp.SetActive(false);
                break;
            case 1:
                iconEn.SetActive(false);
                iconFr.SetActive(true);
                iconSp.SetActive(false);
                break;
            case 2:
                iconEn.SetActive(false);
                iconFr.SetActive(false);
                iconSp.SetActive(true);
                break;
        }
    }

    IEnumerator SetLocale(int _localId) { 
        yield return LocalizationSettings.InitializationOperation;
        LocalizationSettings.SelectedLocale = LocalizationSettings.AvailableLocales.Locales[_localId];
    }
}
