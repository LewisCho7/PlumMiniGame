using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using DG.Tweening;

public class MYROOM_ButtonManager : MonoBehaviour
{
    public GameObject mainCanvas;
    public GameObject editCanvas;
    public GameObject furniture;
    public GameObject editButtons;

    public Button moreButton;
    public Button shopButton;
    public Button editButton;
    public Button bookButton;

    public RectTransform morePos;
    public RectTransform shopPos;
    public RectTransform editPos;
    public RectTransform bookPos;
    private RectTransform objectPos;

    private bool isStretched;
    private bool isEditMode;

    private void Start()
    {
      isStretched = false;
      isEditMode = false;
    }

    public void onClickMore()
    {
        if (!isStretched)
        {
            shopPos.DOAnchorPos(new Vector2(293, -460), 0.5f).From(new Vector2(293, -566.59f));
            editPos.DOAnchorPos(new Vector2(293, -350), 0.5f).From(new Vector2(293, -566.59f));
            bookPos.DOAnchorPos(new Vector2(293, -240), 0.5f).From(new Vector2(293, -566.59f));
            shopButton.interactable = true;
            editButton.interactable = true;
            bookButton.interactable = true;
            isStretched=true;
        }
        else
        {
            shopButton.interactable = false;
            editButton.interactable = false;
            bookButton.interactable = false;
            shopPos.DOAnchorPos(new Vector2(293, -566.59f), 0.5f).From(new Vector2(293, -460));
            editPos.DOAnchorPos(new Vector2(293, -566.59f), 0.5f).From(new Vector2(293, -350));
            bookPos.DOAnchorPos(new Vector2(293, -566.59f), 0.5f).From(new Vector2(293, -240));

            isStretched = false;
        }
        
    }
    public void onClickEdit()
    {
        isEditMode = true;
        mainCanvas.SetActive(false);
        editCanvas.SetActive(true);
        // ��� ĳ���� setActive(false);
    }

    public void onClickBack()
    {
        isEditMode = false;
        mainCanvas.SetActive(true);
        editCanvas.SetActive(false);
        editButtons.SetActive(false);

        // ���� �ý��� ����
    }

    public void onClickFurniture()
    {
        // furniture �ٲ��ֱ� --> script �ʿ�
        editButtons.SetActive(true);
        objectPos = furniture.GetComponent<RectTransform>();
        editButtons.GetComponent<RectTransform>().anchoredPosition = objectPos.anchoredPosition + new Vector2(0, 150);
    }

    public void onClickCancel()
    {
        editButtons.SetActive(false);
    }

    public void onClickStorage()
    {
        // ���� ������� ����
        editButtons.SetActive(false);
        GameSceneManager.instance.storageSceneLoad();
    }

    public void onClickChange()
    {
        // ���� ������� ����
        editButtons.SetActive(false);
        GameSceneManager.instance.storageSceneLoad();
        // ���� ���� ���� ����
    }
}