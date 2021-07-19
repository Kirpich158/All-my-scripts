using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class Inventory : MonoBehaviour
{
    public int arrowCurrent = 5;
    public int arrowMax = 10;
    public int arrowPoisonCurrent = 3;
    public int arrowPoisonMax = 10;
    public TextMeshProUGUI arrowDisplay;
    public TextMeshProUGUI arrowPoisonDisplay;

    bool canPickArrow = false;
    bool canPickPoisonArrow = false;
    bool canPickFromChest = false;
    GameObject pickingObject;


    private void Start()
    {
        arrowDisplay.text = arrowCurrent.ToString();
        arrowPoisonDisplay.text = arrowPoisonCurrent.ToString();
    }


    // Update is called once per frame
    void Update()
    {

        if (Input.GetKeyDown(KeyCode.F))
        {
            PickingUp();
        }
    }

   public void RemoveArrow()
    {
        arrowCurrent -= 1;
        arrowDisplay.text = arrowCurrent.ToString();
    }
   public void RemovePoisonArrow()
    {
        arrowPoisonCurrent -= 1;
        arrowPoisonDisplay.text = arrowPoisonCurrent.ToString();
    }

    // Pick up arrows
    void PickingUp()
    {
        if (canPickArrow)
        {
            arrowCurrent += 1;
            arrowDisplay.text = arrowCurrent.ToString();
            Destroy(pickingObject);
        }

        if (canPickPoisonArrow)
        {
            arrowPoisonCurrent += 1;
            arrowPoisonDisplay.text = arrowPoisonCurrent.ToString();
            Destroy(pickingObject);
        }

        if (canPickFromChest)
        {
            ChestObject chest = pickingObject.GetComponent<ChestObject>();
            if(chest.isOpen)
            {
                if(!chest.isUsed)
                {
                    int arrows = chest.GetArrow();
                    int poisonarrows = chest.GetPoisonArrow();

                    arrowCurrent += arrows; //do ustalenia granic
                    if (arrowCurrent > arrowMax)
                        arrowCurrent = arrowMax;
                    arrowPoisonCurrent += poisonarrows; //do ustalenia granic
                    if (arrowPoisonCurrent > arrowPoisonMax)
                        arrowPoisonCurrent = arrowPoisonMax;

                    arrowDisplay.text = arrowCurrent.ToString();
                    arrowPoisonDisplay.text = arrowPoisonCurrent.ToString();

                    chest.ShowPopUp("+" + arrows.ToString() + " arrows" + "\n" + "+" + poisonarrows.ToString() + " poison");

                    chest.OpenChest();
                }
            }
            else
            {
                chest.ShowPopUp("Chest is locked!");
            }
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "ArrowObject" && arrowCurrent < arrowMax)
        {
            canPickArrow = true;
            pickingObject = collision.gameObject;
        }

        if(collision.tag == "PoisonObject" && arrowPoisonCurrent < arrowPoisonMax)
        {
            canPickPoisonArrow = true;
            pickingObject = collision.gameObject;
        }

        if(collision.tag == "Chest" && arrowCurrent < arrowMax && arrowPoisonCurrent < arrowPoisonMax)
        {
            canPickFromChest = true;
            pickingObject = collision.gameObject;
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.tag == "ArrowObject")
        {
            canPickArrow = false;
            pickingObject = null;
        }

        if (collision.tag == "PoisonObject")
        {
            canPickPoisonArrow = false;
            pickingObject = null;
        }

        if (collision.tag == "Chest")
        {
            canPickFromChest = false;
            pickingObject = null;
        }
    }

    public bool IsArrow()
    {
        if (arrowCurrent <= 0)
            return false;
        
        return true;
    }
    public bool IsPoisonArrow()
    {
        if (arrowPoisonCurrent <= 0)
            return false;
         
        return true;
    }
}