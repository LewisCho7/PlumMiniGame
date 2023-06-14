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
    private GameObject warning;
    [SerializeField]
    private GameObject char_buy_confirm;
    [SerializeField]
    private Sprite[] rare_portrait;
    

    private string[] character_name
        = { "플루", "돌이", "캐리", "해피", "아리", "앙리", "부기", 
            "캥붕", "자바", "세리"};
    // Start is called before the first frame update
    void Start()
    {
        common.SetActive(false);
        rare_select.SetActive(false);
        warning.SetActive(false);
        char_buy_confirm.SetActive(false);
        foreach(GameObject g in rare_coin) { g.SetActive(false); }
        foreach (GameObject g in rare_result) { g.SetActive(false); }
    }

    private void ButtonsDisappear()
    {
        for (int i = 0; i < 3; i++)
        {
            buttons[i].SetActive(false);
        }
    }
    public void BlurClicked()
    {
        ButtonSoundManager.instance.sound.Play();
        common.SetActive(false);
        UnityEngine.Debug.Log("blur");
        
        rare_select.SetActive(false);
        foreach (GameObject g in rare_coin) 
        {
            g.SetActive(false);
        }
        foreach (GameObject g in rare_result)
        {
            g.SetActive(false);
        }
        for (int i = 0; i < 3; i++)
        {
            buttons[i].SetActive(true);
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
        foreach (GameObject g in rare_coin) 
        { 
            g.SetActive(true); 
        }

        rare_coin[1].transform.GetChild(0)
            .transform.rotation = Quaternion.Euler(new Vector3(0, 0, 0));
    }

    public void RareBuyClicked()
    {
        ButtonSoundManager.instance.sound.Play();
        ButtonsDisappear();
        rare_select.SetActive(true);
    }

    public void NormalCharBuy(int id)
    {
        ButtonSoundManager.instance.sound.Play();
        if (DataManager.instance.saveData.currentCoin >= 150 && !Find(id)) 
        {
            /*char_buy_confirm.SetActive(true);
            CharacterConfirmManager.current_item_id = id;*/
            DataManager.instance.saveData.currentCoin -= 150;
            DataManager.instance.saveData.rescuedCharacter.Add(id);
            DataManager.instance.SaveGame();
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
    }

    public void SelectedCharacterBuy(int id)
    {
        ButtonSoundManager.instance.sound.Play();
        int price = (id <= 12) ? 100 : 200;
        if(!Find(id) && DataManager.instance.saveData.dupNum >= price) 
        {
            DataManager.instance.saveData.dupNum -= price;
            DataManager.instance.saveData.rescuedCharacter.Add(id);
            DataManager.instance.SaveGame();
        }
        else if (DataManager.instance.saveData.currentCoin >= price && Find(id))
        {
            warning.SetActive(true);
            warning.transform.GetChild(0).GetComponent<TextMeshProUGUI>().text
                = "이미 구출한 인질입니다!";

        }
        else if (DataManager.instance.saveData.dupNum < price)
        {
            warning.SetActive(true);
            warning.transform.GetChild(0).GetComponent<TextMeshProUGUI>().text
                = "조각이 부족합니다!";
        }
    }

    public void RareCharBuy(GameObject popping)
    {
        ButtonSoundManager.instance.sound.Play();
        
        if (DataManager.instance.saveData.dupNum >= 400)
        {
            popping.transform.rotation = Quaternion.Euler(new Vector3(0, 0, 30));
            foreach (GameObject g in rare_result)
            {
                g.SetActive(true);
            }
            RareResult();
        }
        else
        {
            warning.SetActive(true);
            warning.transform.GetChild(0).gameObject.GetComponent<TextMeshProUGUI>().text = "재화가 부족합니다!";
        }
    }
    private void RareResult()
    {
        DataManager.instance.saveData.currentCoin -= 400;

        int random_variable = Random.Range(1, 101);
        int id = (random_variable <= 91) ? (random_variable % 7) : ((random_variable % 3) + 7);

        rare_result[1].GetComponent<Image>().sprite = rare_portrait[id];
        rare_result[2].GetComponent<TextMeshProUGUI>().text = character_name[id];
        rare_result[3].GetComponent<TextMeshProUGUI>().text = (random_variable <= 91) ? "RARE" : "UNIQUE";

        if (!Find(id+6))
        {
            DataManager.instance.saveData.rescuedCharacter.Add(id + 6);
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
        warning.SetActive(false);
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
