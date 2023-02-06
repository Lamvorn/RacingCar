using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuController : MonoBehaviour
{
    public void playGame()
    {
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

}
