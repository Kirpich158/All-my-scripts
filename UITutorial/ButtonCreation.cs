using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class ButtonCreation : MonoBehaviour
{
    public GameObject buttonPrefab;
    public GameObject parentGrid;

    private TMP_Text buttonTxt;
    private int buttonNum = 1;

    public void CreateButton()
    {
        GameObject nexButton = Instantiate(buttonPrefab, Vector3.zero, Quaternion.identity);
        buttonTxt = nexButton.GetComponentInChildren<TMP_Text>(true);
        buttonTxt.text = "Lvl" + buttonNum;
        RectTransform rTransform = nexButton.GetComponent<RectTransform>();
        rTransform.SetParent(parentGrid.transform);
        buttonNum++;
    }
}
