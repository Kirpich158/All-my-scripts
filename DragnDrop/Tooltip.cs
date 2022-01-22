using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Tooltip : MonoBehaviour
{

    private static Tooltip instance;
    [SerializeField] private Camera uiCamera;

    private Text tooltipText;
    private RectTransform bgRectTransform;
    // private Image imgColor;
    
    private void Awake() {
        gameObject.SetActive(false);
        instance = this;
        bgRectTransform = transform.Find("TTImage").GetComponent<RectTransform>();
        // imgColor = transform.Find("TTImage").GetComponent<Image>();
        tooltipText = transform.Find("TTText").GetComponent<Text>();
    }

    private void Update() {
        Vector2 localPoint;
        RectTransformUtility.ScreenPointToLocalPointInRectangle(transform.parent.GetComponent<RectTransform>(), 
            Input.mousePosition, uiCamera, out localPoint);
        transform.localPosition = localPoint;
    }

    private void ShowTooltip(string tooltipSting) {
        gameObject.SetActive(true);
        // color
        tooltipText.text = tooltipSting;
        float textPaddingSize = 4f;
        Vector2 bgSize = new Vector2(tooltipText.preferredWidth + textPaddingSize * 2f, 
            tooltipText.preferredHeight + textPaddingSize * 2);
        bgRectTransform.sizeDelta = bgSize;
    }
    private void HideTooltip() {
        gameObject.SetActive(false);
    }

    public static void ShowTooltip_Static(string tooltipString) {
        instance.ShowTooltip(tooltipString);
    }

    public static void HideTooltip_Static() {
        instance.HideTooltip();
    }
}
