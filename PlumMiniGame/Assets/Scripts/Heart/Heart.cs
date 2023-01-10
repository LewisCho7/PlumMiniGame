using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using UnityEngine;


public class Heart : MonoBehaviour
{
    [SerializeField]
    private GameObject red_heart;
    [SerializeField]
    private GameObject yellow_heart;

    private GameObject[] red_heart_arr;
    private GameObject[] yellow_heart_arr;
    void Start()
    {
        yellow_heart.SetActive(false);
    }

    public void HeartUIUpdate()
    {
        if (GameManager.life > 3)
        {
            yellow_heart.SetActive(true);
            for (int i = 0; i < 3; i++)
            {
                if (i < GameManager.life-3)
                    yellow_heart.GetComponent<YellowHeart>().yellow_arr[i].SetActive(true);
                else
                    yellow_heart.GetComponent<YellowHeart>().yellow_arr[i].SetActive(false);
            }
        }
        else
        {
            yellow_heart.SetActive(false);
            for (int i = 0; i < 3; i++)
            {
                if (i < GameManager.life)
                    red_heart.GetComponent<RedHeart>().red_arr[i].SetActive(true);
                else
                    red_heart.GetComponent<RedHeart>().red_arr[i].SetActive(false);
            }
        }
    }
}
