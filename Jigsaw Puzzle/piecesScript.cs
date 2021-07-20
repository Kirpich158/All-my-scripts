using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Rendering;

public class piecesScript : MonoBehaviour
{
    Vector3 rightPosition;
    public bool inRightPosition = false;
    public bool selected;

    // Start is called before the first frame update
    void Start()
    {
        rightPosition = transform.position;
        transform.position = new Vector3(Random.Range(2.5f, 9.5f), Random.Range(4f, -5f));
    }

    // Update is called once per frame
    void Update()
    {
        if(Vector3.Distance(transform.position, rightPosition) < 0.5f)
        {
            if (!selected)
            {
                if(inRightPosition == false)
                {
                    transform.position = rightPosition;
                    inRightPosition = true;
                    GetComponent<SortingGroup>().sortingOrder = 0;
                }                
            }            
        }
    }
}
