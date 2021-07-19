using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class NextScene : MonoBehaviour
{
    public void GameScene()
    {
        SceneManager.LoadScene("GrzegorzTestScene");
    }

    public void ExitScene()
    {
        Application.Quit();
    }
}
