using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class InputfieldScript : MonoBehaviour
{
    public TMP_InputField input;

    public void GetInput()
    {
        Debug.Log(input.text);
    }
}
