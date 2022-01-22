using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawn : MonoBehaviour
{
    [SerializeField] private GameObject prefab;

    void Start()
    {
        SpawnMethod();
    }

    private void SpawnMethod() {
        int rndCount = Random.Range(1, 11);
        transform.position = new Vector3(-9.29f, 4.04f, -39.6f);
        for (int i = 0; i < Random.Range(1, 11); i++) {
            for (int j = 0; j < rndCount; j++) {
                Instantiate(prefab, transform.position, Quaternion.identity);
                transform.position = new Vector3(transform.position.x - 1f, transform.position.y, transform.position.z);
            }
            transform.position = new Vector3(0f, transform.position.y, transform.position.z + 1.5f);
        }
    }
}
