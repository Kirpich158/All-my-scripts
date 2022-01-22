using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerPower : MonoBehaviour
{
    private GameObject[] enemies;

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.F)) // If you press F key on keyboard, you activate your Power
        {

            Armagedon(); // Calling power function
            Debug.Log("TACTICAL NUKE INCOMING!!!"); // Just a joke :)
        }
    }

    void Armagedon() // Power function
    {
        enemies = GameObject.FindGameObjectsWithTag("Enemy");
        foreach (GameObject enemy in enemies)
            enemy.GetComponent<EnemyScript>().TakeDMG(3);
    }
}
