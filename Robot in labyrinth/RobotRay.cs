using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RobotRay : MonoBehaviour
{
    private float speed;
    public float Speed {
        get { return speed; }
        set { speed = value; }
    }

    [SerializeField]
    private EventScript eventS;

    private void Start() {
        speed = 0f;
        eventS.ExecuteStart();
    }

    void Update() {
        Ray ray = new Ray(transform.position, transform.forward);
        transform.Translate(Time.deltaTime * speed * Vector3.forward);
        if (Physics.Raycast(ray, 0.6f)) {
            // Dead end scenario
            if (Physics.Raycast(transform.position, -transform.right, 0.6f)
                && Physics.Raycast(transform.position, transform.right, 0.8f)) {
                StartCoroutine(Rotation(180f));
            }
            // Blocked from right side scenario
            if (Physics.Raycast(transform.position, -transform.right, 0.6f)) {
                StartCoroutine(Rotation(90f));
            }
            // Blocked from left side scenario
            if (Physics.Raycast(transform.position, transform.right, 0.6f)) {
                StartCoroutine(Rotation(-90f));
            }
            // Blocked from infront only scenario
            if (!Physics.Raycast(transform.position, -transform.right, 0.6f)
                && !Physics.Raycast(transform.position, transform.right, 0.6f)) {
                StartCoroutine(Rotation(90f));
            }
        }
    }

    private void OnTriggerEnter(Collider other) {
        if(other.gameObject.name == "EndPoint") {
            speed = 0f;
            eventS.ExecuteEnd();
        }
    }

    IEnumerator Rotation(float y) {
        transform.Rotate(0f, y, 0f);
        yield return new WaitForSecondsRealtime(1f);
        transform.Translate(Time.deltaTime * speed * Vector3.forward);
    }
}