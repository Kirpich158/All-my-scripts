using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneManagerScript : MonoBehaviour
{
    public void NextScene(int sceneNumber)
    {
        SceneManager.LoadScene(sceneNumber);
        
        //if (Input.GetKey(KeyCode.Space)) //for testing
        //{
        //    SceneManager.LoadScene(0);
        //}

    }

    public void QuitGame()
    {
        Application.Quit();
    }
}
