using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Storage_Furniture : MonoBehaviour
{

    public GameObject selectButton;

    RectTransform rectTransform;

    private void Start()
    {
        rectTransform = GetComponent<RectTransform>();
    }

    public void onClickFurn()
    {
        selectButton.SetActive(true);
        selectButton.GetComponent<RectTransform>().anchoredPosition = rectTransform.anchoredPosition + new Vector2(0, -90f);
    }
}
