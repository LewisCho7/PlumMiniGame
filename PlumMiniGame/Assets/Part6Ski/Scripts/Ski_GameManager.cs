using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ski_GameManager : MonoBehaviour
{
    public static Ski_GameManager instance;

    [SerializeField]
    private GameObject item;

    public float timer;

    public float gameSpeed;

    public bool isGameOver;

    public bool hasItem;

    private void Awake()
    {
        instance = this;
        init();
        StartCoroutine("changeSpeed");
    }

    private void Update()
    {
        if (!isGameOver)
        {
            timer += Time.deltaTime;
        }
        showItem();
        
        Debug.Log(timer);
    }

    private void showItem()
    {
        if (hasItem)
        {
            item.SetActive(true);
        }
        else
        {
            item.SetActive(false);
        }
    }
    private IEnumerator changeSpeed()
    {
        while (timer <= 25f && !isGameOver)
        {
            gameSpeed += 20f;

            yield return new WaitForSeconds(1f);
        }
    }
    
    public void GameOver()
    {
        isGameOver = true;
        gameSpeed = 0;
    }

    private void init()
    { // 난이도 별 차이 두기
        timer = 0f;
        gameSpeed = 400f;
        hasItem = false;
    }

    public void calculateSpeed()
    {



    }

    public void rescue()
    {

    }
}
