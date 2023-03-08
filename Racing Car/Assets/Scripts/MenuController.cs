using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.Localization.Settings;

public class MenuController : MonoBehaviour
{
    public GameObject background;
    public GameObject settings;

    private static string LANGUAGE = "Language";
    public void playGame()
    {
        Time.timeScale = 1.0f;
        SceneManager.LoadScene(1);
    }
    public void goToShop()
    {
        SceneManager.LoadScene(2);
    }
    public void exitGame()
    {
        Application.Quit();
    }
    public void goToMainMenu()
    {
        SceneManager.LoadScene(0);
    }

    public void goToSettings() {
        background.SetActive(false);
        settings.SetActive(true);
    }
    private void Awake()
    {
        int language = EncryptedPlayerPrefs.GetInt(LANGUAGE);
        StartCoroutine(SetLocale(language));
    }
    IEnumerator SetLocale(int _localId)
    {
        yield return LocalizationSettings.InitializationOperation;
        LocalizationSettings.SelectedLocale = LocalizationSettings.AvailableLocales.Locales[_localId];
    }
}
