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
        if(GameManager.instance.CurrentCoin >= 150)
        {
            GameManager.instance.CurrentCoin -= 150;
            if (!Find(id))
            {
                GameManager.instance.RescuedCharacter.Add(id);
                DataManager.instance.SaveGame();
            }
        }

    }
    public void RareCharBuy(GameObject popping)
    {
        popping.transform.rotation = Quaternion.Euler(new Vector3(0, 0, -30));

        int id = Random.Range(6, 16);

        RareResult(id);

/*        if (!Find(id))
        {
            GameManager.instance.RescuedCharacter.Add(id);
            DataManager.instance.SaveGame();
        }*/

        rare_result.SetActive(true);
    }

    private bool Find(int id)
    {
        foreach (int i in GameManager.instance.RescuedCharacter)
        {
            if(i == id) return true;
        }
        return false;
    }

    private void RareResult(int id)
    {
        rare.transform.GetChild(0).transform.GetChild(3).
            transform.GetChild(0).gameObject.GetComponent<Image>().sprite = rare_portrait[id - 6]; //portrait

        rare.transform.GetChild(0).transform.GetChild(3).
            transform.GetChild(1).gameObject.GetComponent<TextMeshProUGUI>().text = character_name[id - 6]; //name

        if (id <= 12)
        {
            rare.transform.GetChild(0).transform.GetChild(3).
                transform.GetChild(2).gameObject.GetComponent<TextMeshProUGUI>().text = "Rare";
        }
        else
        {
            rare.transform.GetChild(0).transform.GetChild(3).
                transform.GetChild(2).gameObject.GetComponent<TextMeshProUGUI>().text = "Unique";
        }
    }
}
