using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    public float posZ = -4.5f; // Z coordinate offset for enemies
    public GameObject enemyPrefab; // GameObject for enemy prefab in Unity

    // Wave variables
    public float countdown = 13f; // Starting delay before 1st wave will be 2sec
    public float waveCountdown = 0.3f;
    public int numberOfWaves = 10; // Max number of waves

    public int enemyCount, wave = 1; // Wave counter/index
    private int currentWave = 0;

    public UIScript uiScript; // Reference to activate our GameOver script when HP will be 0

    private GameObject spawner;

    private void Start()
    {
        spawner = GameObject.Find("Spawner"); // Finding GameObject of name "Spawner"
        var fooGroup = Resources.FindObjectsOfTypeAll<UIScript>();
        if (fooGroup.Length > 0)
        {
            uiScript = fooGroup[0];
        }
    }

    void Update()
    {
        if (wave <= numberOfWaves) // If our current wave isn't the last then ...
        {
            if (countdown <= 0f) // If starting countdown is equal or lower than 0 then we starting our coroutine
            {
                if(waveCountdown <= 0f)
                {
                    Vector3 temp = transform.position;
                    temp.z = posZ; // Z coordinate offset 
                    if(currentWave < wave)
                    {
                        Instantiate(enemyPrefab, temp, Quaternion.identity);
                        currentWave++;
                    }
                    else
                    {
                        wave++;
                        enemyCount = wave;
                        currentWave = 0;
                        countdown = 13f; // And time between waves will now be 5secs (custom)
                    }
                    waveCountdown = 0.3f;
                }
                else
                {
                    waveCountdown -= Time.deltaTime;
                }
            }
            else
            {
                countdown -= Time.deltaTime; // Decreasing our starting countdown to start spawning waves
            }
        }
    }

    IEnumerator SpawnEnemies() // Spawning each enemy in wave coroutine
    {
        Vector3 temp = transform.position;
        temp.z = posZ; // Z coordinate offset 
        for (int i = 0; i < wave; i++) // 
        {
            Instantiate(enemyPrefab, temp, Quaternion.identity);
            yield return new WaitForSeconds(0.3f);
        }
        wave++;
    }
}