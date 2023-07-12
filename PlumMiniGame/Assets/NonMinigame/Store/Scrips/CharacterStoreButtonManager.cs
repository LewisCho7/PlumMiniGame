using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using TMPro;
//using UnityEditor.Tilemaps;
using UnityEngine;
using UnityEngine.UI;

public class CharacterStoreButtonManager : MonoBehaviour
{
    [SerializeField]
    private GameObject[] buttons;
    [SerializeField]
    private GameObject common;
    [SerializeField]
    private GameObject[] rare_coin;
    [SerializeField]
    private GameObject[] rare_result;
    [SerializeField]
    private GameObject rare_select;
    [SerializeField]
    private GameObject[] warning;
    [SerializeField]
    private GameObject char_buy_confirm;
    [SerializeField]
    private Sprite[] rare_portrait;
    [SerializeField]
    private Sprite[] rare_result_back;
    

    private string[] character_name
        = { "지바", "프럼", "이브", "알리", "코리",
            "플루", "돌이", "캐리", "해피", "아리", "앙리", "부기", 
            "캥붕", "자바", "세리"};
    // Start is called before the first frame update
    void Start()
    {
        common.SetActive(false);
        rare_select.SetActive(false);
        char_buy_confirm.SetActive(false);
        warning[4].SetActive(false);
        foreach(GameObject g in rare_coin) { g.SetActive(false); }
    }

    private void ButtonsDisappear()
    {
        ButtonSoundManager.instance.sound.Play();
        for (int i = 0; i < 2; i++)
        {
            buttons[i].SetActive(false);
        }
    }
    public void BlurClicked(GameObject g)
    {
        g.SetActive(false);
        foreach (GameObject obj in buttons)
        {
            obj.SetActive(true);
        }

    }
    public void CommonButtonClicked()
    {
        ButtonSoundManager.instance.sound.Play();
        ButtonsDisappear();
        common.SetActive(true);
    }

    public void RareRandomClicked()
    {
        ButtonSoundManager.instance.sound.Play();
        ButtonsDisappear();
        rare_coin[0].SetActive(true);
    }

    public void RareBuyClicked()
    {
        ButtonSoundManager.instance.sound.Play();
        ButtonsDisappear();
        rare_select.SetActive(true);
    }

/*    public void NormalCharBuy(int id)
    {
        ButtonSoundManager.instance.sound.Play();
        if (DataManager.instance.saveData.currentCoin >= 150 && !Find(id)) 
        {
            CharacterBuyConfirm.current_item_id = id;
            char_buy_confirm.SetActive(true);
        }
        else if (DataManager.instance.saveData.currentCoin >= 150 && Find(id))
        {
            warning.SetActive(true);
            warning.transform.GetChild(0).GetComponent<TextMeshProUGUI>().text
                = "이미 구출한 인질입니다!";

        }
        else if (DataManager.instance.saveData.dupNum < 150)
        {
            warning.SetActive(true);
            warning.transform.GetChild(0).GetComponent<TextMeshProUGUI>().text
                = "코인이 부족합니다!";
        }
    }*/

    public void SelectedCharacterBuy(int id)
    {
        ButtonSoundManager.instance.sound.Play();
        int price = (id <= 12) ? 100 : 200;
        if(!Find(id) && DataManager.instance.saveData.dupNum >= price) 
        {
            CharacterBuyConfirm.current_item_id = id;
            char_buy_confirm.SetActive(true);
        }
        else if (DataManager.instance.saveData.currentCoin >= price && Find(id))
        {
            foreach (GameObject g in warning)
            {
                g.SetActive(true);
            }
            warning[1].gameObject.GetComponent<TextMeshProUGUI>().text = "이미 구출한 인질입니다!";

        }
        else if (DataManager.instance.saveData.dupNum < price)
        {
            foreach(GameObject g in warning) 
            { 
                g.SetActive(true); 
            }
            warning[1].gameObject.GetComponent<TextMeshProUGUI>().text = "조각이 부족합니다!";
        }
    }

    public void RareCharBuy(GameObject popping)
    {
        ButtonSoundManager.instance.sound.Play();
        
        if (DataManager.instance.saveData.currentCoin >= 400)
        {
            popping.transform.rotation = Quaternion.Euler(new Vector3(0, 0, 30));
            rare_coin[1].SetActive(true);
            RareResult();
        }
        else
        {
            foreach (GameObject g in rare_result)
            {
                g.SetActive(true);
            }
            warning[1].gameObject.GetComponent<TextMeshProUGUI>().text = "재화가 부족합니다!";
        }
    }
    private void RareResult()
    {
        ButtonSoundManager.instance.sound.Play();
        DataManager.instance.saveData.currentCoin -= 400;

        int random_variable = Random.Range(700, 1000);
        int id = -1;
        if (random_variable < 700)
        {
            id = random_variable / 140 + 1;
        }
        else if (random_variable < 900)
        {
            id = random_variable & 7 + 6;
        }
        else
        {
            id = random_variable % 3 + 12;
        }
        rare_result[1].GetComponent<Image>().sprite = rare_portrait[id];
        rare_result[2].GetComponent<TextMeshProUGUI>().text = character_name[id];
        
        if (random_variable < 900)
        {
            rare_result[0].GetComponent<Image>().sprite = rare_result_back[0];
            rare_result[3].GetComponent<TextMeshProUGUI>().text = "Rare";
        }
        else
        {
            rare_result[0].GetComponent<Image>().sprite = rare_result_back[1];
            rare_result[3].GetComponent<TextMeshProUGUI>().text = "Unique";
        }

        if (!Find(id))
        {
            DataManager.instance.saveData.rescuedCharacter.Add(id);
            DataManager.instance.SaveGame();
        }
        else
        {
            DataManager.instance.saveData.dupNum += 20;
        }
    }

    public void Close()
    {
        ButtonSoundManager.instance.sound.Play();

        foreach (GameObject obj in rare_coin)
        {
            obj.SetActive(false);
        }

        foreach (GameObject obj in buttons)
        {
            obj.SetActive(true);
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
