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
        = { "�÷�", "����", "ĳ��", "����", "�Ƹ�", "�Ӹ�", "�α�", 
            "Ļ��", "�ڹ�", "����"};
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
        if (!Find(id)) 
        {
            DataManager.instance.saveData.currentCoin -= 150;
            if (DataManager.instance.saveData.currentCoin >= 150)
            {
                DataManager.instance.saveData.rescuedCharacter.Add(id + 1);
                DataManager.instance.SaveGame();
            }
        }

    }
    public void RareCharBuy(GameObject popping)
    {
        popping.transform.rotation = Quaternion.Euler(new Vector3(0, 0, -30));

        if (DataManager.instance.saveData.currentCoin >= 400)
        {
            rare_result.SetActive(true);
            RareResult();
        }
    }
    private void RareResult()
    {
        DataManager.instance.saveData.currentCoin -= 400;

        int id = Random.Range(1, 101);
        id = (id <= 91) ? (id % 7) : ((id % 3) + 7);
        Debug.Log(id);
        rare.transform.GetChild(0).transform.GetChild(3).
            transform.GetChild(0).gameObject.GetComponent<Image>().sprite = rare_portrait[id];
        rare.transform.GetChild(0).transform.GetChild(3).
            transform.GetChild(1).gameObject.GetComponent<TextMeshProUGUI>().text = character_name[id];
        rare.transform.GetChild(0).transform.GetChild(3).
            transform.GetChild(2).gameObject.GetComponent<TextMeshProUGUI>().text = "Rare";

        if (!Find(id))
        {
            DataManager.instance.saveData.rescuedCharacter.Add(id + 6);
            DataManager.instance.SaveGame();
        }
        else
        {
            //��í�� ���� ĳ���Ͱ� ������??
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
