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

    public GameObject[] buttons;

    private Ski_ScoreText scoreText;

    public bool isHardMode;

    private int _score;
    public int Score
    {
        get { return _score; }
        set {
            _score = value;
            scoreText.changeScoreText();

        }
    }

    private int _rescuedNum;

    public int Rescuednum
    {
        get {
            return _rescuedNum; }
        set {

            _rescuedNum = value;
            scoreText.changeRescueText();

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
        Debug.Log(Rescuednum);
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
        Time.timeScale = 1f;
        timer = 0f;
        gameSpeed = 0f;
        Score = 0;
        Rescuednum = 0;
        hasItem = false;
        for (int i = 0; i < buttons.Length; i++)
        {
            buttons[i].SetActive(false);
        }
        yield return new WaitForSeconds(4f);
        timerStart = true;
        gameSpeed = 400f;

    }

    public void pauseGame()
    {
        Debug.Log("Game Paused");
        for(int i = 0; i  < buttons.Length; i++)
        {
            buttons[i].SetActive(true);
        }
        Time.timeScale = 0f;
    }

    public void calculateSpeed()
    {



    }

    public void rescue()
    {
        Debug.Log("Rescued");
        Score += 40;
        Rescuednum++;
    }
}
