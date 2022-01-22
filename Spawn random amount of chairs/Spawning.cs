using UnityEngine;

public class Spawning : MonoBehaviour {
    [SerializeField] private GameObject prefab;

    void Update() {
        if (Input.GetKeyDown(KeyCode.F)) {
            Spawn();
        }
    }

    private void Spawn() {
        int rndCount = Random.Range(1, 11);
        transform.position = new Vector3(0f, 0.5f, 0f);
        for (int i = 0; i < Random.Range(1, 11); i++) {
            for (int j = 0; j < rndCount; j++) {
                Instantiate(prefab, transform.position, Quaternion.identity);
                transform.position = new Vector3(transform.position.x - 1f, transform.position.y, transform.position.z);
            }
            transform.position = new Vector3(0f, transform.position.y, transform.position.z + 1.5f);
        }
    }
}
