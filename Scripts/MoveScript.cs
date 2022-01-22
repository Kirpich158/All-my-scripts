using System.Collections;
using UnityEngine;

public class MoveScript : MonoBehaviour {
    public IEnumerator Open(Vector3 endValue, float duration) {
        float time = 0f;
        Vector3 startValue = transform.localScale;

        while (time < duration) {
            transform.localScale = Vector3.Lerp(startValue, endValue, time / duration);
            time += Time.deltaTime;
            yield return null;
        }
        transform.localScale = endValue;
    }
}
