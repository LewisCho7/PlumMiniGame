using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Select_Difficulty : MonoBehaviour
{
    public Sprite[] backgroundSprites;
    public GameObject[] difficulty;
    public GameObject selectSceneManager;
    private SpriteRenderer sp;
    private Select_Manager manager;

    public static bool isHard;

    private void Awake()
    {
        sp = GetComponent<SpriteRenderer>();
        manager = selectSceneManager.GetComponent<Select_Manager>();
    }
    private void Start()
    {
        changeMode();
    }
    public void setNormalMode()
    {
        DataManager.instance.isHardMode = false;
        changeMode();
    }

    public void setHardMode()
    {
        DataManager.instance.isHardMode = true;
        changeMode();
    }

    private void changeMode()
    {
        if (DataManager.instance.isHardMode == false)
        {
            Debug.Log("false");
            sp.sprite = backgroundSprites[0];
            difficulty[0].SetActive(true);
            difficulty[1].SetActive(false);
        }
        else
        {
            sp.sprite = backgroundSprites[1];
            difficulty[0].SetActive(false);
            difficulty[1].SetActive(true);
        }

        manager.unlockedGameSet();
    }
}
