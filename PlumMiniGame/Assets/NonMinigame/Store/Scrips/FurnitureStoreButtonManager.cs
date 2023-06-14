using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Diagnostics;
using TMPro;
using Unity.VisualScripting;
using UnityEngine;

public class FurnitureStoreButtonManager : MonoBehaviour
{
    [SerializeField]
    private GameObject[] stand_floor;
    [SerializeField]
    private GameObject theme_selector;
    [SerializeField]
    private GameObject warning;
    [SerializeField]
    private GameObject purchase_confirm;

    private bool floor_move;
    private int current_floor;

    // Start is called before the first frame update
    void Start()
    {
        warning.SetActive(false);
        purchase_confirm.SetActive(false);

        floor_move = true;
        stand_floor[0].GetComponent<SpriteRenderer>().sortingOrder = 4;
        stand_floor[1].GetComponent<SpriteRenderer>().sortingOrder = 3;
        stand_floor[1].transform.GetChild(0).transform.GetChild(0).gameObject.SetActive(false);

        stand_floor[1].GetComponent<SpriteRenderer>().color = new Color(1, 1, 1, 0.5f);

        
        try
        {
            int i = 0;
            while (theme_selector.transform.GetChild(i) != null)
            {
                theme_selector.transform.GetChild(i).gameObject.SetActive(false);
                i++;
            }
        }
        catch
        {
            
        }

        current_floor = 0;
    }

    public void FirstFloorClicked()
    {
        ButtonSoundManager.instance.sound.Play();
        if (floor_move)
        {   
            stand_floor[0].GetComponent<SpriteRenderer>().sortingOrder = 4;
            stand_floor[0].transform.GetChild(0).transform.GetChild(0).gameObject.SetActive(true);
            stand_floor[1].GetComponent<SpriteRenderer>().sortingOrder = 3;
            stand_floor[1].transform.GetChild(0).transform.GetChild(0).gameObject.SetActive(false);

            stand_floor[0].GetComponent<SpriteRenderer>().color = new Color(1, 1, 1, 1);
            stand_floor[1].GetComponent<SpriteRenderer>().color = new Color(1, 1, 1, 0.5f);

            current_floor = 0;
        }
    }

    public void SecondFloorClicked()
    {
        ButtonSoundManager.instance.sound.Play();
        if (floor_move)
        {
            stand_floor[0].GetComponent<SpriteRenderer>().sortingOrder = 3;
            stand_floor[0].transform.GetChild(0).transform.GetChild(0).gameObject.SetActive(false);
            stand_floor[1].GetComponent<SpriteRenderer>().sortingOrder = 4;
            stand_floor[1].transform.GetChild(0).transform.GetChild(0).gameObject.SetActive(true);


            stand_floor[0].GetComponent<SpriteRenderer>().color = new Color(1, 1, 1, 0.5f);
            stand_floor[1].GetComponent<SpriteRenderer>().color = new Color(1, 1, 1, 1);

            current_floor = 1;
        }
    }

    public void FurnitureSelected(int id)
    {
        ButtonSoundManager.instance.sound.Play();
        stand_floor[(int)id / 12].transform.GetChild(0).
            transform.GetChild(0).gameObject.SetActive(false);

        theme_selector.transform.GetChild(--id).gameObject.SetActive(true);
        floor_move = false;
    }

    public void FurnitureBuy(int id)
    {
        ButtonSoundManager.instance.sound.Play();
        int price = (id % 10 <= 2) ? 100 : 200;
        price = (id % 10 == 4) ? 500 : price;
        string id_string = (id < 1000) ? "0" + id.ToString() : id.ToString();

        if (DataManager.instance.saveData.currentCoin >= price && !Find(id_string))
        {
            purchase_confirm.SetActive(true);
            FurnitureWarningManager.current_item_id = id;
        }
        else if(DataManager.instance.saveData.currentCoin >= price && Find(id_string))
        {
            warning.SetActive(true);
            warning.transform.GetChild(0).GetComponent<TextMeshProUGUI>().text
                = "이미 구매했습니다!";

        }
        else if (DataManager.instance.saveData.currentCoin < price)
        {
            warning.SetActive(true);
            warning.transform.GetChild(0).GetComponent<TextMeshProUGUI>().text
                = "코인이 부족합니다!";
        }
    }

    public void BackButton()
    {
        ButtonSoundManager.instance.sound.Play();
        floor_move = true;
        stand_floor[current_floor].transform.GetChild(0).
            transform.GetChild(0).gameObject.SetActive(true);

        int i = 0;
        while (theme_selector.transform.GetChild(i) != null)
        {
            theme_selector.transform.GetChild(i).gameObject.SetActive(false);
            i++;
        }
    }
    private bool Find(string id)
    {
        foreach (string i in DataManager.instance.saveData.furnatureList)
        {
            if (i == id) return true;
        }
        return false;
    }
}
