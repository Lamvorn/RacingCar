using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class GameOverScreen : MonoBehaviour
{
    public TMP_Text scoreTxt;
    public TMP_Text highScoreTxt;
    public TMP_Text coinsText;
    private static string HIGH_SCORE = "HighScore";
    public void showGameOver(int score, int coin) {
        //Debug.Log("USO");
        gameObject.SetActive(true);
        if (score > EncryptedPlayerPrefs.GetInt(HIGH_SCORE))
        {
            scoreTxt.gameObject.SetActive(false);
            highScoreTxt.gameObject.SetActive(true);
            highScoreTxt.text += score;
            EncryptedPlayerPrefs.SetInt(HIGH_SCORE, score);
            coinsText.text += coin;
        }
        else {
            scoreTxt.gameObject.SetActive(true);
            highScoreTxt.gameObject.SetActive(false);
            scoreTxt.text += score;
            coinsText.text += coin;
        }
    }

    public void closeGameOver() {
        gameObject.SetActive(false);
    }
}
