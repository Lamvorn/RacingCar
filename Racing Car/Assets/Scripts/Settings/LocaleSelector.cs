using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Localization.Settings;

public class LocaleSelector : MonoBehaviour
{
    private static string LANGUAGE = "Language";

    private void Awake()
    {
        int language = EncryptedPlayerPrefs.GetInt(LANGUAGE);
        StartCoroutine(SetLocale(language));
    }
    public void ChangeLocale() {
        EncryptedPlayerPrefs.SetInt(LANGUAGE, EncryptedPlayerPrefs.GetInt(LANGUAGE)+1);
        if (EncryptedPlayerPrefs.GetInt(LANGUAGE) > 2) {
            EncryptedPlayerPrefs.SetInt(LANGUAGE, 0);
        }
        int language = EncryptedPlayerPrefs.GetInt(LANGUAGE);
        StartCoroutine(SetLocale(language));
    }

    IEnumerator SetLocale(int _localId) {
        yield return LocalizationSettings.InitializationOperation;
        LocalizationSettings.SelectedLocale = LocalizationSettings.AvailableLocales.Locales[_localId];
    }
}
