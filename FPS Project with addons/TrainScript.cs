using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TrainScript : MonoBehaviour
{
    [SerializeField] private float speed = 7f;
    [SerializeField] private float countdown;
    private Transform target;

    private void Start() {
        target = WayPtsScript.pts[1];
        countdown = 3f;
    }

    private void Update() {
        Vector3 dir = target.position - transform.position;
        transform.Translate(dir.normalized * speed * Time.deltaTime, Space.World);

        if (Vector3.Distance(transform.position, target.position) <= 0.01f) {
            speed = 0f;
            if (countdown <= 0f)
            {
                speed = 7f;
                if(target == WayPtsScript.pts[1]) {
                    target = WayPtsScript.pts[0];
                }
                else {
                    target = WayPtsScript.pts[1];
                }
                countdown = 3f;
            }
            else {
                countdown -= Time.deltaTime;
            }
        }
    }
}
