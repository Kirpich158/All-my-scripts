using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MyLightController : MonoBehaviour {
    [SerializeField] private Animator lightAnim;
    private bool lightOpen = false;

    public void PlayAnimation() {
        if (!lightOpen) {
            lightAnim.Play("LightON", 0, 0.0f);
            lightOpen = true;
        }
        else {
            lightAnim.Play("LightOFF", 0, 0.0f);
            lightOpen = false;
        }
    }
}
