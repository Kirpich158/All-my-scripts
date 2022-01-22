using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class QualityScript : MonoBehaviour
{
    public void Q1() {
        QualitySettings.SetQualityLevel(1, false);
        Cursor.visible = false;
        Debug.Log(QualitySettings.GetQualityLevel());
    }

    public void Q2() {
        QualitySettings.SetQualityLevel(2, false);
        Cursor.visible = false;
        Debug.Log(QualitySettings.GetQualityLevel());
    }

    public void Q3() {
        QualitySettings.SetQualityLevel(3, true);
        Cursor.visible = false;
        Debug.Log(QualitySettings.GetQualityLevel());
    }
}
