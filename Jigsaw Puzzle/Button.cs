using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Button : MonoBehaviour
{
    public void PlayScene()
    {
        SceneManager.LoadScene("Game");
    }

    public void ChooseLvl()
    {
        SceneManager.LoadScene("Choose");
    }

    public void ChooseLvl1()
    {
        SceneManager.LoadScene("Game");
    }

    public void ChooseLvl2()
    {
        SceneManager.LoadScene("Game2");
    }

    public void ChooseLvl3()
    {
        SceneManager.LoadScene("Game3");
    }

    public void ExitGame()
    {
        Application.Quit();
    }

    public void RestartGame()
    {
        SceneManager.LoadScene("Game");
    }

    public void Back2Menu()
    {
        SceneManager.LoadScene("MainMenu");
    }
}
