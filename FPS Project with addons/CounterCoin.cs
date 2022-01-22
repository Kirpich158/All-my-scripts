using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CounterCoin : MonoBehaviour
{
    private int counter = 0;
    public void AddCoin() {
        counter++;
        gameObject.GetComponent<Text>().text = "Points: " + counter;
    }
}
