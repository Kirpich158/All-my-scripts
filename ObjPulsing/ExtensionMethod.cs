using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class ExtensionMethods {

    private static Transform tran;

    public static float Pulse(this float time, float min, float max, float frequency) {

        if(time == 0f) {
            return min;
        }
        else {
            float amp = (max - min) / 2;
            float fin = Mathf.Sin(Time.time * frequency) * amp;
            return fin;
        }
    }
}
