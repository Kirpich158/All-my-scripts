using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Rendering;

public class DragnDrop : MonoBehaviour
{
    public GameObject selectedPiece;
    int OIL = 1;

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKey("escape"))
        {
            Application.Quit();
            Debug.Log("Exit");
        }

        if (Input.GetMouseButtonDown(0))
        {
            RaycastHit2D hit = Physics2D.Raycast(Camera.main.ScreenToWorldPoint(Input.mousePosition), Vector2.zero);
            if (hit.transform.CompareTag("Puzzle"))
            {
                if (!hit.transform.GetComponent<piecesScript>().inRightPosition)
                {
                    selectedPiece = hit.transform.gameObject;
                    selectedPiece.GetComponent<piecesScript>().selected = true;
                    selectedPiece.GetComponent<SortingGroup>().sortingOrder = OIL;
                    OIL++;
                }
            }
        }

        if (Input.GetMouseButtonUp(0))
        {
            if(selectedPiece != null)
            {
                selectedPiece.GetComponent<piecesScript>().selected = false;
                selectedPiece = null;
            }                    
        }

        if(selectedPiece != null)
        {
            Vector3 mousePoint = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            selectedPiece.transform.position = new Vector3(mousePoint.x, mousePoint.y, 0);
        }
    }
}
