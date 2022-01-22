using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MyWindowController : MonoBehaviour {
    private Animator windowAnim;
    private bool windowOpen = false;

    private void Awake() {
        windowAnim = gameObject.GetComponent<Animator>();
    }

    public void PlayAnimation() {
        if (!windowOpen) {
            windowAnim.Play("WindowOpen", 0, 0.0f);
            windowOpen = true;
        }
        else {
            windowAnim.Play("WindowClose", 0, 0.0f);
            windowOpen = false;
        }
    }
}
