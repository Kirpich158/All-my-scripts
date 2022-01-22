using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DTrigger2 : MonoBehaviour
{
    private void OnTriggerEnter(Collider other) {
        if (other.tag == "Player") {
            StartCoroutine(GameObject.Find("EDoor2").GetComponent<MoveScript>().Move(new Vector3(4f, transform.position.y + 1f, transform.position.z + 0.3f), 2f));
            StartCoroutine(GameObject.Find("EDoor2 (1)").GetComponent<MoveScript>().Move(new Vector3(-4f, transform.position.y + 1f, transform.position.z + 0.3f), 2f));
        }
    }

    private void OnTriggerExit(Collider other) {
        if (other.tag == "Player") {
            StartCoroutine(GameObject.Find("EDoor2").GetComponent<MoveScript>().Move(new Vector3(1.3f, transform.position.y + 1f, transform.position.z + 0.3f), 2f));
            StartCoroutine(GameObject.Find("EDoor2 (1)").GetComponent<MoveScript>().Move(new Vector3(-1.3f, transform.position.y + 1f, transform.position.z + 0.3f), 2f));
        }
    }
}
