using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MYROOM_Character : MonoBehaviour
{
    [SerializeField]
    private GameObject[] characters;

    FurnitureManager furnitureManager;
    private int unlockedChar;

    private void Awake()
    {
        furnitureManager = FindObjectOfType<FurnitureManager>();
    }
    private void Start()
    {
        unlockedChar = DataManager.instance.saveData.rescuedCharacter.Count;
        setSprite();
        enableChar(false);
    }

    private void setSprite()
    {
        for(int i = 0; i < unlockedChar; i++)
        {
            characters[i].SetActive(true);
            Image image = characters[i].GetComponent<Image>();
            string id = "" + DataManager.instance.saveData.rescuedCharacter[i];
            image.sprite = Resources.Load<Sprite>("CharacterSprites/" + id);
            characters[i].SetActive(false);
        }

    }

    public void enableChar(bool isSecond)
    {
        
        if (!isSecond)
        {
            if(unlockedChar < 8)
            {
                for (int i = 0; i < unlockedChar; i++)
                {
                    characters[i].SetActive(true);
                }
            }
            else
            {
                for(int i = 0; i < 7; i++)
                {
                    characters[i].SetActive(true);
                }
                for(int i=7; i < unlockedChar; i++)
                {
                    characters[i].SetActive(false);
                }
            }
           
        }
        else
        {
            for (int i = 0; i < 7; i++)
            {
                characters[i].SetActive(false);
            }
            for (int i = 7; i < unlockedChar; i++)
            {
                characters[i].SetActive(true);
            }
        }
    }

}
