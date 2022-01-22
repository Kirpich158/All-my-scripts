using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveScript : MonoBehaviour {
    public IEnumerator Move(Vector3 endValue, float duration) {
        float time = 0f;
        Vector3 startValue = transform.position;

        while (time < duration) {
            transform.position = Vector3.Lerp(startValue, endValue, time / duration);
            time += Time.deltaTime;
            yield return null;
        }
        transform.position = endValue;
    }
}
