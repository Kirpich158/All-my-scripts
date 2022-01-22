using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class Armor : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler 
{
    [SerializeField] private int armor;
    [SerializeField] private int durability;
    [SerializeField] private string rarity;
    public Color color;
    public void OnPointerEnter(PointerEventData eventData) {
        Tooltip.ShowTooltip_Static("Armor: " + armor.ToString() + "\n" +
            "Durability: " + durability.ToString() + "\n" + "Rarity: " + rarity);
    }

    public void OnPointerExit(PointerEventData eventData) {
        Tooltip.HideTooltip_Static();
    }
}
