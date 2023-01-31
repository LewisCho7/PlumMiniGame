using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using DG.Tweening;

public class MYROOM_ButtonManager : MonoBehaviour
{
    public Button moreButton;
    public Button shopButton;
    public Button settingsButton;

    public RectTransform morePos;
    public RectTransform shopPos;
    public RectTransform settingsPos;

    private void Start()
    {
      
    }

    public void onClickMore()
    {
        shopButton.gameObject.SetActive(true);
        settingsButton.gameObject.SetActive(true);
        shopPos.DOAnchorPos(new Vector2(293, -460), 0.5f).From(new Vector2(293, -566.59f));
        settingsPos.DOAnchorPos(new Vector2(293, -350), 0.5f).From(new Vector2(293, -566.59f));


    }



}
