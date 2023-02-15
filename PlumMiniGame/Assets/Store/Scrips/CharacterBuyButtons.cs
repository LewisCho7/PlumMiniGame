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
    [SerializeField]
    private GameObject rare_result;
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
        if (!find(id))
        {
            GameManager.instance.RescuedCharacter.Add(id);
            DataManager.instance.SaveGame();
        }

    }
    public void RareCharBuy(GameObject popping)
    {
        popping.transform.rotation = Quaternion.Euler(new Vector3(0, 0, -30));

        rare_result.SetActive(true);
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
