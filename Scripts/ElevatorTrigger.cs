using System.Collections;
using UnityEngine;

public class ElevatorTrigger : MonoBehaviour {
    [SerializeField] private GameObject elevator;
    [SerializeField] private ParticleSystem particle;

    private void OnTriggerStay(Collider other) {
        if (other.tag == "Player" && Input.GetKeyDown(KeyCode.C)) {
            StartCoroutine(elevator.GetComponent<ElevatorScript>().Move(new Vector3(transform.position.x - 0.85f, transform.position.y + 17f, transform.position.z), 5f));
            elevator.GetComponent<AudioSource>().Play();
            particle.Play();
        }

        if (other.tag == "Player" && Input.GetKeyDown(KeyCode.V)) {
            StartCoroutine(elevator.GetComponent<ElevatorScript>().Move(new Vector3(transform.position.x - 0.85f, transform.position.y - 13.2f, transform.position.z), 5f));
            elevator.GetComponent<AudioSource>().Play();
            particle.Play();
        }
    }
    // Доделать так, чтобы лифт оставался на втором этаже, а когда ты входишь в него снова, то ехал на низ
}
