using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using TMPro;
using UnityEngine;

public class FurnitureStoreButtonManager : MonoBehaviour
{
    [SerializeField]
    private GameObject[] stand_floor;
    [SerializeField]
    private GameObject theme_selector;
    [SerializeField]
    private GameObject warning;

    private bool floor_move;
    private int current_floor;

    // Start is called before the first frame update
    void Start()
    {
        floor_move = true;
        stand_floor[0].GetComponent<SpriteRenderer>().sortingOrder = 4;
        stand_floor[1].GetComponent<SpriteRenderer>().sortingOrder = 3;
        stand_floor[1].transform.GetChild(0).transform.GetChild(0).gameObject.SetActive(false);

        stand_floor[1].GetComponent<SpriteRenderer>().color = new Color(1, 1, 1, 0.5f);

        int i = 0;
        while (theme_selector.transform.GetChild(i) != null)
        {
            theme_selector.transform.GetChild(i).gameObject.SetActive(false);
            i++;
        }

        warning.SetActive(false);

        current_floor = 0;
    }

    public void FirstFloorClicked()
    {
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
        stand_floor[(int)id / 12].transform.GetChild(0).
            transform.GetChild(0).gameObject.SetActive(false);

        theme_selector.transform.GetChild(--id).gameObject.SetActive(true);
        floor_move = false;
    }

    public void FurnitureBuy(int id)
    {
        int price = (id % 10 <= 2) ? 100 : 200;
        price = (id % 10 == 4) ? 500 : price;
        string id_string = (id < 1000) ? "0" + id.ToString() : id.ToString();

        if (DataManager.instance.saveData.currentCoin >= price && !Find(id_string))
        {
            DataManager.instance.saveData.currentCoin -= price;
            DataManager.instance.saveData.furnatureList.Add(id_string);
        }
        else if(DataManager.instance.saveData.currentCoin >= price && !Find(id_string))
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

    public void Close()
    {
        warning.SetActive(false);
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
