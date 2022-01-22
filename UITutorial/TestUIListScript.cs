using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using Random = System.Random;
using TMPro;

public class TestUIListScript : MonoBehaviour
{
    public GameObject prefab;
    private string[] txts = { "Test", "Hello", "World", "I", "don't", "know", "what", "to", "type", "here"};
    Random rnd = new Random();

    [SerializeField]
    private UIList list;
    
    private void Start()
    {
        for (int i = 0; i < 10; i++)
        {
            list.AddEntry<Text>(prefab, ChangeText);
        }
    }
    public void ChangeText(GameObject go)
    {
        TextMeshProUGUI txt = go.GetComponent<TextMeshProUGUI>();
        txt.text = txts[rnd.Next(0, 10)];
        txt.fontSize = rnd.Next(30, 59);
        txt.color = new Color32((byte)rnd.Next(0, 255), (byte)rnd.Next(0, 255), (byte)rnd.Next(0, 255), 255);
    }
}
