using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ETrigger : MonoBehaviour
{
    [SerializeField] private GameObject ePlatform;
    [SerializeField] private ParticleSystem[] particles;

    private void OnTriggerEnter(Collider other) {
        if(other.tag == "Player") {
            ePlatform.GetComponent<AudioSource>().Play();
        }
    }
    private void OnTriggerExit(Collider other) {
        if (other.tag == "Player") {
            ePlatform.GetComponent<AudioSource>().Stop();
        }
    }

    private void OnTriggerStay(Collider other) {
        if (other.tag == "Player" && Input.GetKeyDown(KeyCode.C)) {
            StartCoroutine(ePlatform.GetComponent<MoveScript>().Move(new Vector3(transform.position.x, 10.5f, transform.position.z), 2f));
            foreach(ParticleSystem particle in particles) {
                particle.Play();
            }
        }

        if (other.tag == "Player" && Input.GetKeyDown(KeyCode.V)) {
            StartCoroutine(ePlatform.GetComponent<MoveScript>().Move(new Vector3(transform.position.x, 3f, transform.position.z), 2f));
            foreach (ParticleSystem particle in particles) {
                particle.Play();
            }
        }
    }

    // Доделать так, чтобы лифт оставался на втором этаже, а когда ты входишь в него снова, то ехал на низ
}
