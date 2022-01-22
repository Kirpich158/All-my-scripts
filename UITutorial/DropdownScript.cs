using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class DropdownScript : MonoBehaviour
{
    public TMP_Dropdown dropD;
    public void WhichOption()
    {
        Debug.Log(dropD.options[dropD.value].text);
    }
}
