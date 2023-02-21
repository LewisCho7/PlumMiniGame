using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Newsstand : MonoBehaviour
{
    [SerializeField]
    private GameObject[] stand_floor;
    [SerializeField]
    private GameObject theme_selector;
    private int current_floor;

    private Sprite[] sprites;
    // Start is called before the first frame update
    void Start()
    {
        stand_floor[0].GetComponent<SpriteRenderer>().sortingOrder = 4;
        stand_floor[1].GetComponent<SpriteRenderer>().sortingOrder = 3;
        stand_floor[1].transform.GetChild(0).gameObject.SetActive(false);

        stand_floor[1].GetComponent<SpriteRenderer>().color = new Color(1, 1, 1, 0.5f);

        theme_selector.SetActive(false);

        current_floor = 0;
    }

    public void FirstFloorClicked()
    {
        stand_floor[0].GetComponent<SpriteRenderer>().sortingOrder = 4;
        stand_floor[1].GetComponent<SpriteRenderer>().sortingOrder = 3;
        stand_floor[1].transform.GetChild(0).gameObject.SetActive(false);

        stand_floor[0].GetComponent<SpriteRenderer>().color = new Color(1, 1, 1, 1);
        stand_floor[1].GetComponent<SpriteRenderer>().color = new Color(1, 1, 1, 0.5f);

        current_floor = 0;
    }

    public void SecondFloorClicked()
    {
        stand_floor[0].GetComponent<SpriteRenderer>().sortingOrder = 3;
        stand_floor[0].transform.GetChild(0).gameObject.SetActive(false);
        stand_floor[1].GetComponent<SpriteRenderer>().sortingOrder = 4;
        

        stand_floor[0].GetComponent<SpriteRenderer>().color = new Color(1, 1, 1, 0.5f);
        stand_floor[1].GetComponent<SpriteRenderer>().color = new Color(1, 1, 1, 1);

        current_floor = 1;
    }

    public void FurnitureSelected(int id)
    {
        stand_floor[(int)id / 12].transform.GetChild(0).
            transform.GetChild(0).gameObject.SetActive(false);
        string path = "Assets/NonMinigame/Store/Sprite/FurnitureStore" + id.ToString();
        sprites = Resources.LoadAll<Sprite>(path);
    }

    public void BackButton()
    {
        stand_floor[current_floor].transform.GetChild(0).
            transform.GetChild(0).gameObject.SetActive(true);
        sprites = null;
    }
}
