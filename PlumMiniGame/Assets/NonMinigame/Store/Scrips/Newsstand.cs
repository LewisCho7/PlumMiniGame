using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Newsstand : MonoBehaviour
{
    [SerializeField]
    private GameObject first_floor;
    [SerializeField]
    private GameObject second_floor;
    // Start is called before the first frame update
    void Start()
    {
        first_floor.GetComponent<SpriteRenderer>().sortingOrder = 4;
        second_floor.GetComponent<SpriteRenderer>().sortingOrder = 3;

        second_floor.GetComponent<SpriteRenderer>().color = new Color(1, 1, 1, 0.5f);
    }

    public void FirstFloorClicked()
    {
        first_floor.GetComponent<SpriteRenderer>().sortingOrder = 4;
        second_floor.GetComponent<SpriteRenderer>().sortingOrder = 3;

        first_floor.GetComponent<SpriteRenderer>().color = new Color(1, 1, 1, 1);
        second_floor.GetComponent<SpriteRenderer>().color = new Color(1, 1, 1, 0.5f);
    }

    public void SecondFloorClicked()
    {
        first_floor.GetComponent<SpriteRenderer>().sortingOrder = 3;
        second_floor.GetComponent<SpriteRenderer>().sortingOrder = 4;

        first_floor.GetComponent<SpriteRenderer>().color = new Color(1, 1, 1, 0.5f);
        second_floor.GetComponent<SpriteRenderer>().color = new Color(1, 1, 1, 1);
    }
}
