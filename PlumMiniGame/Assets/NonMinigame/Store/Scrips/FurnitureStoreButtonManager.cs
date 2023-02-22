using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using UnityEngine;

public class FurnitureStoreButtonManager : MonoBehaviour
{
    [SerializeField]
    private GameObject[] stand_floor;
    [SerializeField]
    private GameObject theme_selector;

    private int current_floor;

    // Start is called before the first frame update
    void Start()
    {
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

        current_floor = 0;
    }

    public void FirstFloorClicked()
    {
        stand_floor[0].GetComponent<SpriteRenderer>().sortingOrder = 4;
        stand_floor[0].transform.GetChild(0).transform.GetChild(0).gameObject.SetActive(true);
        stand_floor[1].GetComponent<SpriteRenderer>().sortingOrder = 3;
        stand_floor[1].transform.GetChild(0).transform.GetChild(0).gameObject.SetActive(false);

        stand_floor[0].GetComponent<SpriteRenderer>().color = new Color(1, 1, 1, 1);
        stand_floor[1].GetComponent<SpriteRenderer>().color = new Color(1, 1, 1, 0.5f);

        current_floor = 0;
    }

    public void SecondFloorClicked()
    {
        stand_floor[0].GetComponent<SpriteRenderer>().sortingOrder = 3;
        stand_floor[0].transform.GetChild(0).transform.GetChild(0).gameObject.SetActive(false);
        stand_floor[1].GetComponent<SpriteRenderer>().sortingOrder = 4;
        stand_floor[1].transform.GetChild(0).transform.GetChild(0).gameObject.SetActive(true);


        stand_floor[0].GetComponent<SpriteRenderer>().color = new Color(1, 1, 1, 0.5f);
        stand_floor[1].GetComponent<SpriteRenderer>().color = new Color(1, 1, 1, 1);

        current_floor = 1;
    }

    public void FurnitureSelected(int id)
    {
        stand_floor[(int)id / 12].transform.GetChild(0).
            transform.GetChild(0).gameObject.SetActive(false);

        theme_selector.transform.GetChild(--id).gameObject.SetActive(true);
    }

    public void FurnitureBuy(int id)
    {
        int price = (id % 10 <= 2) ? 100 : 200;
        price = (id % 10 == 4) ? 500 : price;

        if(DataManager.instance.saveData.currentCoin >= price)
        {
            DataManager.instance.saveData.currentCoin -= price;
            string id_string = (id < 1000) ? "0" + id.ToString() : id.ToString();
            DataManager.instance.saveData.furnatureList.Add(id_string.ToString());
        }
    }

    public void BackButton()
    {
        stand_floor[current_floor].transform.GetChild(0).
            transform.GetChild(0).gameObject.SetActive(true);

        int i = 0;
        while (theme_selector.transform.GetChild(i) != null)
        {
            theme_selector.transform.GetChild(i).gameObject.SetActive(false);
            i++;
        }
    }
}
