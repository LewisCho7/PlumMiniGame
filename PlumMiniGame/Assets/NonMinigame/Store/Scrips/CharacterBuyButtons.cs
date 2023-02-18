using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class CharacterBuyButtons : MonoBehaviour
{
    [SerializeField]
    private GameObject[] buttons;
    [SerializeField]
    private GameObject common;
    [SerializeField]
    private GameObject rare;
    [SerializeField]
    private GameObject rare_result;
    [SerializeField]
    private Sprite[] rare_portrait;

    private string[] character_name
        = { "플루", "돌이", "캐리", "해피", "아리", "앙리", "부기", 
            "캥붕", "자바", "세리"};
    // Start is called before the first frame update
    void Start()
    {
        common.SetActive(false);
        rare.SetActive(false);
    }

    private void ButtonsDisappear()
    {
        for (int i = 0; i < 2; i++)
        {
            buttons[i].SetActive(false);
        }
    }
    public void BlurClicked()
    {
        common.SetActive(false);
        rare.SetActive(false);
        for (int i = 0; i < 2; i++)
        {
            buttons[i].SetActive(true);
        }
    }
    public void CommonButtonClicked()
    {
        ButtonsDisappear();
        common.SetActive(true);
    }

    public void RareButtonClicked()
    {
        ButtonsDisappear();
        rare.SetActive(true);
        rare_result.SetActive(false);
    }

    public void NormalCharBuy(int id)
    {
        if (GameManager.instance.CurrentCoin >= 150)
        {
            GameManager.instance.CurrentCoin -= 150;
            if (!Find(id))
            {
                DataManager.instance.saveData.rescuedCharacter.Add(id);
                DataManager.instance.SaveGame();
            }
        }

    }
    public void RareCharBuy(GameObject popping)
    {
        popping.transform.rotation = Quaternion.Euler(new Vector3(0, 0, -30));

        if(DataManager.instance.saveData.currentCoin >= 400)
            RareResult();
            rare_result.SetActive(true);
    }
    private void RareResult()
    {
        DataManager.instance.saveData.currentCoin -= 400;

        int id = Random.Range(1, 101);
        id = (id <= 91) ? (id % 7) : ((id % 3) + 7);

        rare.transform.GetChild(0).transform.GetChild(3).
            transform.GetChild(0).gameObject.GetComponent<Image>().sprite = rare_portrait[id];
        rare.transform.GetChild(0).transform.GetChild(3).
            transform.GetChild(1).gameObject.GetComponent<TextMeshProUGUI>().text = character_name[id];
        rare.transform.GetChild(0).transform.GetChild(3).
            transform.GetChild(2).gameObject.GetComponent<TextMeshProUGUI>().text = "Rare";

        if (!Find(id))
        {
            DataManager.instance.saveData.rescuedCharacter.Add(id);
            DataManager.instance.SaveGame();
        }
        else
        {
            //가챠로 뽑은 캐릭터가 있으면??
        }
    }
    private bool Find(int id)
    {
        foreach (int i in DataManager.instance.saveData.rescuedCharacter)
        {
            if(i == id) return true;
        }
        return false;
    }
}
