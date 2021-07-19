using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    public float minY = -4.4f, maxY = 4.4f;
    public GameObject asteroidPrefab; //public GameObject[] asteroidPrefabs; for multiple prefabs
    public GameObject enemyPrefab; //public GameObject[] enemyPrefabs; for multiple prefabs
    public float timer = 2f;

    // Start is called before the first frame update
    void Start()
    {
        Invoke("SpawnEnemies", timer);
    }

    void SpawnEnemies()
    {
        float posY = Random.Range(minY, maxY);
        Vector3 temp = transform.position;
        temp.y = posY;
        if(Random.Range(0, 2) > 0)
        {
            Instantiate(asteroidPrefab, temp, Quaternion.identity);
        }
        else
        {
            Instantiate(enemyPrefab, temp, Quaternion.Euler(0f, 0f, 90f));
        }

        Invoke("SpawnEnemies", timer);
    }
}
