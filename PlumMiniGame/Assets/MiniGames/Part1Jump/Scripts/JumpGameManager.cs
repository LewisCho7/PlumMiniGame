using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UIElements;

public class JumpGameManager : MonoBehaviour
{
    [SerializeField]
    private GameObject player;
    [SerializeField]
    private GameObject camera;
    [SerializeField]
    private GameObject score_ui;
    private TextMeshProUGUI tmpro_score;
    [SerializeField]
    private GameObject rescue_num_ui;
    private TextMeshProUGUI tmpro_rescue;
    [SerializeField]
    private GameObject count_down;
    [SerializeField]
    private GameObject scoreboard;
    [SerializeField]
    private GameObject tutorial;
    [SerializeField]
    private GameObject bird;
    [SerializeField]
    private GameObject[] meteo;

    private AudioSource audio;
    private SpriteRenderer playerSprite;
    [SerializeField]
    private Sprite[] playerSprites;

    public static bool hard_mode;
    public static bool on_going;
    public static float survived_time;
    public static int score;
    public static int rescue_num;

    private void Awake()
    {
        playerSprite = player.GetComponent<SpriteRenderer>();
        
    }

    // Start is called before the first frame update
    void Start()
    {
        score = 0;
        rescue_num = 0;
        survived_time = 0;
        Time.timeScale = 1;
        on_going = false;
        hard_mode = DataManager.instance.isHardMode;
        tutorial.SetActive(!DataManager.instance.saveData.isFirstPlay[0]);

        player.GetComponent<BoxCollider2D>().enabled = true;
        tmpro_score = score_ui.transform.GetChild(0).GetComponent<TextMeshProUGUI>();
        tmpro_rescue = rescue_num_ui.transform.GetChild(0).GetComponent<TextMeshProUGUI>();
        playerSprite.sprite = playerSprites[DataManager.instance.saveData.currentCharacter - 1]; ;
        audio = GetComponent<AudioSource>();

        StartCoroutine(CountDown());
    }

    // Update is called once per frame
    void Update()
    {
        tmpro_score.text = score.ToString();
        tmpro_rescue.text = rescue_num.ToString();
        if (camera.transform.position.y - player.transform.position.y > 660)
            on_going = false;
        if (on_going)
            survived_time += Time.deltaTime;
    }

    public IEnumerator CameraSpeed()
    {
        float y = 150;
        Rigidbody2D rb = camera.GetComponent<Rigidbody2D>();
        while (y < 165 && on_going)
        {
            yield return null;
            y = ((survived_time + 10) / 10) * 150 / 2;
            rb.velocity = new Vector2(0, y);
        }
    }

    public IEnumerator CountDown()
    {
        if (DataManager.instance.saveData.isFirstPlay[0])
        {
            DataManager.instance.saveData.isFirstPlay[0] = false;
            tutorial.SetActive(true);
            yield return new WaitForSecondsRealtime(3);
        }
        tutorial.SetActive(false);
        count_down.SetActive(true);
        yield return new WaitForSeconds(4);
        count_down.SetActive(false);
        StartCoroutine(JumpGame());
    }

    public IEnumerator JumpGame()
    {
        yield return null;
        on_going = true;
        StartCoroutine(CameraSpeed());
        StartCoroutine(ObstacleGenerate());
        var cool_down = new WaitForSeconds(1);
        while (on_going)
        {
            yield return null;
            survived_time += Time.deltaTime;
            score += 10;
            yield return cool_down;
        }

        StartCoroutine(GameOver());
    }

    public IEnumerator GameOver()
    {
        StopCoroutine(JumpGame());
        StopCoroutine(CameraSpeed());
        camera.GetComponent<Rigidbody2D>().velocity = Vector3.zero;
        audio.Stop();
        JumpSoundManager.instance.audio.Play();
        scoreboard.SetActive(true);
        DataManager.instance.SaveGame();
        if (camera.transform.position.y - player.transform.position.y > 650)
            player.SetActive(false);
        yield return null;
    }

    IEnumerator ObstacleGenerate()
    {
        var cool_down = new WaitForSeconds(2);
        while (on_going)
        {
            yield return null;
            Debug.Log("obs");
            if (survived_time >= 20)
            {
                if (Random.Range(1, 5) < 6)
                {
                    GenerateBird();
                }
                yield return cool_down;
                if (Random.Range(1, 5) < 6)
                {
                    GenerateMeteo();
                }
                yield return cool_down;
            }
        }
    }
    private void GenerateBird()
    {
        GameObject new_bird = Instantiate(bird);
        Debug.Log("bird");
    }

    private void GenerateMeteo()
    {
        GameObject new_meteo = Instantiate(meteo[1]);
        Debug.Log("meteo");
    }
}
