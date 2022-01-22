using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shoot : MonoBehaviour
{
    [SerializeField] private GameObject prefabToInstantiate;
    [SerializeField] private float speed = 7.0f;

    void Update()
    {
        if (Input.GetMouseButtonDown(0)) {
            Shooting();
        }
    }

    private void Shooting() {
        Ray mouseRay = Camera.main.ScreenPointToRay(Input.mousePosition);
        GameObject newGameObject = Instantiate(prefabToInstantiate, mouseRay.origin, Quaternion.identity);
        Rigidbody rb = newGameObject.GetComponent<Rigidbody>();

        if (rb != null) {
            rb.velocity = mouseRay.direction * speed;
        }
    }
}
