using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterBuyButtons : MonoBehaviour
{
    [SerializeField]
    private GameObject[] buttons;
    [SerializeField]
    private GameObject common;
    [SerializeField]
    private GameObject rare;
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

    public void CommonButtonClicked()
    {
        ButtonsDisappear();
        common.SetActive(true);
    }

    public void RareButtonClicked()
    {
        ButtonsDisappear();
    }

    public void CharBuy(int id)
    {
        if (!find(id))
        {
            GameManager.instance.RescuedCharacter.Add(id);
            DataManager.instance.SaveGame();
        }

    }

    private bool find(int id)
    {
        foreach (int i in GameManager.instance.RescuedCharacter)
        {
            if(i == id) return true;
        }
        return false;
    }
}
