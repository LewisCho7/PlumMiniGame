using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using DG.Tweening;

public class MYROOM_ButtonManager : MonoBehaviour
{
    public GameObject mainCanvas;
    public GameObject editCanvas;
    public GameObject characterCanvas;
    public List<GameObject> furnitures;
    public GameObject editButtons;
    private GameObject selectedFurn;

    public Button switchButton;
    public Button moreButton;
    public Button shopButton;
    public Button editButton;
    public Button bookButton;

    public RectTransform morePos;
    public RectTransform shopPos;
    public RectTransform editPos;
    public RectTransform bookPos;
    private RectTransform objectPos;
    private FurnitureManager furnitureManager;
    private MYROOM_Character characters;
    public Sprite[] switchButtonSprites;


    private bool isStretched;

    private void Awake()
    {
        furnitureManager = FindObjectOfType<FurnitureManager>();
        characters = FindObjectOfType<MYROOM_Character>();
    }
    private void Start()
    {
        isStretched = false;
        switchButton.gameObject.SetActive(DataManager.instance.saveData.secondFloorExtended);
    }

    public void onClickMore()
    {
        ButtonSoundManager.instance.sound.Play();

        if (!isStretched)
        {
            shopPos.DOAnchorPos(new Vector2(293, -460), 0.5f).From(new Vector2(293, -566.59f));
            editPos.DOAnchorPos(new Vector2(293, -350), 0.5f).From(new Vector2(293, -566.59f));
            bookPos.DOAnchorPos(new Vector2(293, -240), 0.5f).From(new Vector2(293, -566.59f));
            shopButton.interactable = true;
            editButton.interactable = true;
            bookButton.interactable = true;
            isStretched = true;
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
        ButtonSoundManager.instance.sound.Play();

        mainCanvas.SetActive(false);
        editCanvas.SetActive(true);
        characterCanvas.SetActive(false);
        // ��� ���� setInteractable
        foreach (GameObject furn in furnitures)
        {
            furn.GetComponent<Button>().interactable = true;
        }
    }

    public void onClickBack()
    {
        ButtonSoundManager.instance.sound.Play();

        mainCanvas.SetActive(true);
        editCanvas.SetActive(false);
        editButtons.SetActive(false);
        characterCanvas.SetActive(true);
        foreach (GameObject furn in furnitures)
        {
            furn.GetComponent<Button>().interactable = false;
        }
        // ���� �ý��� ����
    }

    public void onClickFurniture(int index)
    {
        // furniture �ٲ��ֱ� --> script �ʿ�

        ButtonSoundManager.instance.sound.Play();

        editButtons.SetActive(true);
        objectPos = furnitures[index - 3].GetComponent<RectTransform>();
        selectedFurn = furnitures[index - 3];
        if (index == 9)
        {
            editButtons.GetComponent<RectTransform>().anchoredPosition = objectPos.anchoredPosition + new Vector2(-100, 0);
        }
        else
        {
            editButtons.GetComponent<RectTransform>().anchoredPosition = objectPos.anchoredPosition + new Vector2(-100, 100);

        }
    }

    public void onClickCancel()
    {
        ButtonSoundManager.instance.sound.Play();
        editButtons.SetActive(false);
    }

    public void onClickStorage()
    {
        // ���� ������� ����
        ButtonSoundManager.instance.sound.Play();
        editButtons.SetActive(false);
        GameSceneManager.instance.storageSceneLoad();
    }

    public void onClickChange()
    {
        // ���� ������� ����
        ButtonSoundManager.instance.sound.Play();
        editButtons.SetActive(false);
        GameSceneManager.instance.storageSceneLoad();
        // ���� ���� ���� ����
    }

    public void onClickKeep()
    {
        // �����ϴ� �Լ�
        ButtonSoundManager.instance.sound.Play();
        editButtons.SetActive(false);
        selectedFurn.SetActive(false);
        if (DataManager.instance.saveData.myRoomFurnitures.Contains(selectedFurn.GetComponent<FurnitureObjects>().spriteID)){
            DataManager.instance.saveData.myRoomFurnitures.Remove(selectedFurn.GetComponent<FurnitureObjects>().spriteID);
            DataManager.instance.SaveGame();
        }

    }


    public void onClickSwitchFloor()
    {
        ButtonSoundManager.instance.sound.Play();
        StartCoroutine(SceneConvertAnimation.instance.FadeInOut());
        Invoke("switchUI", 0.45f);

        
    }
    private void switchUI()
    {
        if (furnitureManager != null)
        {
            furnitureManager.isSecond = !furnitureManager.isSecond;
            bool isSecond = furnitureManager.isSecond;
            furnitureManager.showSwitchedFurn();
            characters.enableChar(isSecond);
            int i = isSecond ? 0 : 1;

            switchButton.gameObject.GetComponent<Image>().sprite = switchButtonSprites[i];

        }
    }
}
