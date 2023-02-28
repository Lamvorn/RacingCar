using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Localization;
using TMPro;
using System;

public class ShowScore : MonoBehaviour
{
    [SerializeField] private LocalizedString localStringScore;
    [SerializeField] private TextMeshProUGUI textComp;

    private static string HIGH_SCORE = "HighScore";

    private void OnEnable()
    {
        localStringScore.Arguments = new object[] { EncryptedPlayerPrefs.GetInt(HIGH_SCORE) };
        localStringScore.StringChanged += UpdateText;
        localStringScore.Arguments[0] = EncryptedPlayerPrefs.GetInt(HIGH_SCORE);
        localStringScore.RefreshString();
    }

    private void OnDisable()
    {
        localStringScore.StringChanged -= UpdateText;
    }

    private void UpdateText(string value)
    {
        textComp.text = value;
    }
}
