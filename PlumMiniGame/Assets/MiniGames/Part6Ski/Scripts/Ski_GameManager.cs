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

    public GameObject gameOverPanel;
    public GameObject gameOverImage;
    public GameObject tutorial;

    private Ski_ScoreText scoreText;

    public bool isHardMode;

    private int waitTime = 4;

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
        countDown.SetActive(false);
    }

    private void Update()
    {
        showItem();
        Debug.Log(timer);
        if(!isGameOver && timerStart)
        {
            timer += Time.deltaTime;
        }
    }
    private void Start()
    {
        StartCoroutine("IE_CountDown"); // 23/02/19 코루틴에 대한 이해!!!
        StartCoroutine("init");
        StartCoroutine("changeSpeed");
        Application.targetFrameRate = 60;
        isHardMode = DataManager.instance.isHardMode;
        StartCoroutine(IE_IncreaseScore());
        DataManager.instance.saveData.isFirstPlay[4] = false;
        DataManager.instance.SaveGame();   

    }
   
    private IEnumerator IE_CountDown()
    {
        if (DataManager.instance.saveData.isFirstPlay[4])
        {
            waitTime = 7;
            tutorial.SetActive(true);
            yield return new WaitForSeconds(3f);
            tutorial.SetActive(false);
        }
        countDown.SetActive(true);
        yield return new WaitForSeconds(4f);
        countDown.SetActive(false);
    }

    private IEnumerator IE_IncreaseScore()
    {
        yield return new WaitForSeconds(2f);
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
        //gameOverPanel.SetActive(true);

        StartCoroutine(IE_GameOver());
    }

    private IEnumerator init()
    { // 난이도 별 차이 두기
        Time.timeScale = 1f;
        timer = 0f;
        gameSpeed = 0f;
        Score = 0;
        Rescuednum = 0;
        hasItem = false;
        gameOverPanel.SetActive(false);
        for (int i = 0; i < buttons.Length; i++)
        {
            buttons[i].SetActive(false);
        }
        yield return new WaitForSeconds(waitTime);
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


    public void rescue()
    {
        Score += 40;
        Rescuednum++;
    }
    private IEnumerator IE_GameOver()
    {
        gameOverImage.SetActive(true);
        yield return new WaitForSeconds(1.5f);
        gameOverImage.SetActive(false);
        gameOverPanel.SetActive(true);

    }
}
