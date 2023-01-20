using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ski_GameManager : MonoBehaviour
{
    public static Ski_GameManager instance;

    [SerializeField]
    private GameObject item;

    [SerializeField]
    private GameObject countDown;

    public int Score;

    public float timer;

    public float gameSpeed;

    public bool isGameOver;

    public bool hasItem;

    public bool timerStart = false;

    private void Awake()
    {
        instance = this;
        StartCoroutine("init");
        StartCoroutine("changeSpeed");
    }

    private void Update()
    {
        showItem();
        
        //Debug.Log(timer);
    }
    private IEnumerator Start()
    {
        Application.targetFrameRate = 60;
        yield return new WaitForSeconds(4f);
        countDown.SetActive(false);
        while (!isGameOver && timerStart)
        {
            yield return null;
            timer += Time.deltaTime;
        }
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
        while (timer <= 40f && !isGameOver)
        {
            if (!timerStart)
            {
                yield return null;
                continue;
            }
            gameSpeed += 20f;

            yield return new WaitForSeconds(1f);
        }
    }
    
    public void GameOver()
    {
        isGameOver = true;
        gameSpeed = 0;
    }

    private IEnumerator init()
    { // 난이도 별 차이 두기
        timer = 0f;
        gameSpeed = 0f;
        hasItem = false;
        yield return new WaitForSeconds(4f);
        timerStart = true;
        gameSpeed = 400f;

    }

    public void calculateSpeed()
    {



    }

    public void rescue()
    {

    }
}
