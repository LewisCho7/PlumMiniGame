using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Select_Difficulty : MonoBehaviour
{
    public Sprite[] backgroundSprites;
    public GameObject[] difficulty; 
    private SpriteRenderer sp;

    private void Awake()
    {
        sp = GetComponent<SpriteRenderer>();
    }
    private void Start()
    {
        changeMode();
    }
    public void setNormalMode()
    {
        GameManager.instance.isHardMode = false;
        changeMode();
    }

    public void setHardMode()
    {
        GameManager.instance.isHardMode = true;
        changeMode();
    }

    private void changeMode()
    {
        if (GameManager.instance.isHardMode == false)
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
    }
}
