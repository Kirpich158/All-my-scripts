using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TestingScript : MonoBehaviour {
    void Update()
    {
        float sca = Time.time.Pulse(2f, 5f, 1f);
        transform.localScale = new Vector3(sca, sca, sca);
    }
}
