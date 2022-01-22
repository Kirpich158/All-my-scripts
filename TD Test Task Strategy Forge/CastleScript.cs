using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class CastleScript : MonoBehaviour
{
    public int castleHP = 3; // HP of our main building
    public UIScript uiScript; // Reference to activate our GameOver script when HP will be 0

    private GameObject spawner; // Reference to our Spawner GameObject to disable spawning script when game will be over 
    private GameObject bublesHP;

    // Start is called before the first frame update
    void Start()
    {
        spawner = GameObject.Find("Spawner"); // Finding GameObject of name "Spawner"
        bublesHP = GameObject.Find("Castle Health");
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.collider.tag == "Enemy")
        {
            Destroy(collision.collider);
            castleHP--;
            if (bublesHP.transform.GetChild(0) != null)
            {
                Destroy(bublesHP.transform.GetChild(0).gameObject);
            }
            if (castleHP == 0) // If HP of our building will be 0, then the game is over
            {
                uiScript.Activation(); // GameOver screen will pop-up
                GameObject ui = GameObject.Find("Background (L)");
                ui.transform.GetChild(0).gameObject.SetActive(true);
                ui.transform.GetChild(1).gameObject.SetActive(false);
                spawner.GetComponent<EnemySpawner>().enabled = false; // Spawn of enemies will be disabled
                GameObject[] enemies = GameObject.FindGameObjectsWithTag("Enemy"); // Speed of enemies will be 0
                foreach (GameObject e in enemies)
                {
                    e.GetComponent<EnemyScript>().speed = 0f;
                }
                GameObject[] turrets = GameObject.FindGameObjectsWithTag("Turret"); // Speed of enemies will be 0
                foreach (GameObject t in turrets)
                {
                    t.GetComponent<TurretShooting>().enabled = false;
                }
            }
        }
    }
}
