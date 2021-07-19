using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChestObject : MonoBehaviour
{
    public int maxRanArrow = 5;
    public int maxRanPoisonArrow = 4;
    public bool isOpen = false;
    [HideInInspector]
    public bool isUsed = false;
    private int arrow;
    private int poisonArrow;

    private float delay = 0;

    // Start is called before the first frame update
    void Start()
    {
        arrow = Random.Range(1, maxRanArrow);
        poisonArrow = Random.Range(1, maxRanPoisonArrow);
    }

    private void Update()
    {
        if(delay > 0)
        {
            delay -= Time.deltaTime;
        }
    }

    public int GetArrow()
    {
        return arrow;
    }

    public int GetPoisonArrow()
    {
        return poisonArrow;
    }

    public void OpenChest()
    {
        GetComponent<Animator>().SetBool("OpenChest", true);
        this.gameObject.tag = "Untagged";
        isUsed = true;
    }

    public void ShowPopUp(string text)
    {
        if(delay <= 0)
        {
            Vector3 DmgPopupPos = transform.GetComponent<SpriteRenderer>().bounds.center;
            DmgPopupPos.y += transform.GetComponent<SpriteRenderer>().bounds.size.y / 2;
            DamagePopup.Create(DmgPopupPos, text, 0.5f, 0.5f);
            delay = 0.6f;
        }
    }

}
