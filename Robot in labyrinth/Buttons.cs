using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class Buttons : MonoBehaviour
{
    [SerializeField]
    private RobotRay robot;

    public void Go()
    {
        robot.Speed = 5f;
        GameObject.Find("Start").SetActive(false);
    }

    public void Again()
    {
        SceneManager.LoadScene("SampleScene");
    }
}
