using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WayPtsScript : MonoBehaviour
{
    public static Transform[] pts; // Empty array for waypoints

    void Awake()
    {
        pts = new Transform[transform.childCount]; // How many values our array will have

        for (int i = 0; i < pts.Length; i++)
        {
            pts[i] = transform.GetChild(i); // Rewriting children parametrs of gameObject to our array
        }
    }
}
