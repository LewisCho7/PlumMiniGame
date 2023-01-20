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

    private Ski_ScoreText scoreText;

    private int _score;
    public int Score
    {
        get { return _score; }
        set {
            scoreText.changeScoreText();
            _score = value; 
        }
    }

    private int _rescuedNum;

    public int Rescuednum
    {
        get { return _rescuedNum; }
        set { 
            scoreText.changeRescueText();
            _rescuedNum = value; 
        }
    }

    public float timer;

    public float gameSpeed;

    public bool isGameOver;

    public bool hasItem;

    public bool timerStart = false;

    private void Awake()
    {
        instance = this;
        scoreText = GetComponent<Ski_ScoreText>();
    }

    private void Update()
    {
        showItem();
        
        //Debug.Log(timer);
    }
    private IEnumerator Start()
    {
        StartCoroutine("init");
        StartCoroutine("changeSpeed");
        Application.targetFrameRate = 60;
        yield return new WaitForSeconds(4f);
        StartCoroutine(IE_IncreaseScore());
        countDown.SetActive(false);
        while (!isGameOver && timerStart)
        {
            yield return null;
            timer += Time.deltaTime;
        }
    }
   
    private IEnumerator IE_IncreaseScore()
    {
        while (!isGameOver)
        {
            Score += 20;
            yield return new WaitForSeconds(1f);
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
        Score = 0;
        Rescuednum = 0;
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
        Score += 40;
        Rescuednum++;
    }
}
