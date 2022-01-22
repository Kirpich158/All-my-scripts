using UnityEngine;

public class EDoorTrigger : MonoBehaviour {

    [SerializeField] private GameObject door1;
    [SerializeField] private GameObject door2;
    
    [SerializeField] private float scale1;
    [SerializeField] private float scale2;
    [SerializeField] private float scale3;
    [SerializeField] private float scale4;

    private void OnTriggerEnter(Collider other) {
        if (other.tag == "Player") {
            StartCoroutine(door1.GetComponent<MoveScript>().Open(new Vector3(transform.localScale.x / transform.localScale.x, transform.localScale.y, scale1), 2f));
            StartCoroutine(door2.GetComponent<MoveScript>().Open(new Vector3(transform.localScale.x / transform.localScale.x, transform.localScale.y, scale2), 2f));
        }
    }

    private void OnTriggerExit(Collider other) {
        if (other.tag == "Player") {
            StartCoroutine(door1.GetComponent<MoveScript>().Open(new Vector3(transform.localScale.x / transform.localScale.x, transform.localScale.y, scale3), 2f));
            StartCoroutine(door2.GetComponent<MoveScript>().Open(new Vector3(transform.localScale.x / transform.localScale.x, transform.localScale.y, scale4), 2f));
        }
    }
}
