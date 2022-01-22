using System.Collections;
using UnityEngine;
using UnityEngine.UI;

public class CoinScript : MonoBehaviour { 

    private void Start() {
        transform.rotation = Quaternion.Euler(90f, 0f, 0f);
    }

    private void Update() {
        transform.Rotate(0, 0, 50 * Time.deltaTime);
    }

    private void OnTriggerEnter(Collider other) {
        if(other.tag == "Player") {
            GameObject.Find("MScore").GetComponent<CounterCoin>().AddCoin();
            Destroy(gameObject);
        }
    }
}
