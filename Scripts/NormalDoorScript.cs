using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class NormalDoorScript : MonoBehaviour
{
    [SerializeField] private int rayLength = 5;
    [SerializeField] private LayerMask layerMaskInteract;
    [SerializeField] private string excludeLayerName = null;
    [SerializeField] private KeyCode interactKey = KeyCode.F;
    [SerializeField] private Image crosshair = null;

    private MyDoorController doorObj;
    private MyWindowController windowObj;
    private MyLightController lightObj;
    private bool isCrossgairActive;
    private bool doOnce;
    private const string doorTag = "DoorObject";
    private const string windowTag = "WindowObject";
    private const string lightTag = "LightObject";

    private void Update() {
        RaycastHit hit;
        Vector3 fwd = transform.TransformDirection(Vector3.forward);

        int mask = 1 << LayerMask.NameToLayer(excludeLayerName) | layerMaskInteract.value;

        if(Physics.Raycast(transform.position, fwd, out hit, rayLength, mask)) {
            if (hit.collider.CompareTag(doorTag)) {
                if (!doOnce) {
                    doorObj = hit.collider.gameObject.GetComponent<MyDoorController>();
                    CrosshairChange(true);
                }

                isCrossgairActive = true;
                doOnce = true;

                if (Input.GetKeyDown(interactKey)) {
                    doorObj.PlayAnimation();
                }
            }
            if (hit.collider.CompareTag(windowTag)) {
                if (!doOnce) {
                    windowObj = hit.collider.gameObject.GetComponent<MyWindowController>();
                    CrosshairChange(true);
                }

                isCrossgairActive = true;
                doOnce = true;

                if (Input.GetKeyDown(interactKey)) {
                    windowObj.PlayAnimation();
                }
            }
            if (hit.collider.CompareTag(lightTag)) {
                if (!doOnce) {
                    lightObj = hit.collider.gameObject.GetComponent<MyLightController>();
                    CrosshairChange(true);
                }

                isCrossgairActive = true;
                doOnce = true;

                if (Input.GetKeyDown(interactKey)) {
                    lightObj.PlayAnimation();
                }
            }
        }
        else {
            if (isCrossgairActive) {
                CrosshairChange(false);
                doOnce = false;
            }
        }
    }
    
    void CrosshairChange(bool on) {
        if(on && !doOnce) {
            crosshair.color = Color.red;
        }
        else {
            crosshair.color = Color.white;
            isCrossgairActive = false;
        }
    }

}
