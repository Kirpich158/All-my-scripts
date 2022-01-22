using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class UIScript : MonoBehaviour
{
    private void Start()
    {
        gameObject.SetActive(false);
    }

    public void Activation() // Function to activate disabled Game Over Screen
    {
        gameObject.SetActive(true);
    }

    public void RestartGame() // Function to restart GameScene if you pressed the Restart button
    {
        SceneManager.LoadScene("GameScene");
    }

    public void ExitGame() // Function to exit the game if you pressed the Exit button
    {
        Application.Quit();
    }
}
