using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraRotate : MonoBehaviour {

    [SerializeField] private Transform playerTransform;

    private Vector3 camOffset;

    [Range(0.01f, 1f)]
    [SerializeField] private float smoothFactor = 0.5f;

    [SerializeField] private bool lookAtPlayer = false;
    [SerializeField] private bool rotateAroundPlayer = true;
    [SerializeField] private float rotSpeed = 5f;

    private void Start() {
        camOffset = transform.position - playerTransform.position;
    }

    private void LateUpdate() {
        if (rotateAroundPlayer && Input.GetKey(KeyCode.Mouse2)) {
            Quaternion camTurnAngle = Quaternion.AngleAxis(Input.GetAxis("Mouse X") * rotSpeed, Vector3.up);

            camOffset = camTurnAngle * camOffset;
        }

        Vector3 newPos = playerTransform.position + camOffset;

        transform.position = Vector3.Slerp(transform.position, newPos, smoothFactor);

        if (lookAtPlayer || rotateAroundPlayer)
            transform.LookAt(playerTransform);
    }
}
