using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class JumpGameManager : MonoBehaviour
{
    public static bool hard_mode;
    public static bool game_continue;
    public static bool first_play;

    public static int rescued_character = 0;

    public static float survived_time;

    [SerializeField]
    private GameObject character;
    [SerializeField]
    private GameObject main_camera;
    [SerializeField]
    private GameObject dead_ui;
    [SerializeField]
    private GameObject tutorial;
    void Awake()
    {
        Application.targetFrameRate = 60;
        Time.timeScale = 1;
        game_continue = true;
        survived_time = 0;
    }

    // Start is called before the first frame update
    void Start()
    {
        dead_ui.SetActive(false);

        hard_mode = DataManager.instance.isHardMode;
        first_play = DataManager.instance.saveData.isFirstPlay[0];

        StartCoroutine(Tutorial());
    }

    // Update is called once per frame
    void Update()
    {
        survived_time += Time.deltaTime;
        if (!game_continue)
        {
            StopCoroutine(GameProcess());
            StartCoroutine(GameOver());
            Time.timeScale = 0;
        }
    }

    IEnumerator GameProcess()
    {
        while(game_continue)
        {
            yield return null;

            if (main_camera.transform.position.y - character.transform.position.y > 660)
            {
                game_continue = false;
            }
        }
    }

    IEnumerator GameOver()
    {
        yield return null;
        yield return new WaitForSecondsRealtime(1);
        dead_ui.SetActive(true);
    }

    private IEnumerator Tutorial()
    {
        yield return null;

        Time.timeScale = 0;
        while (DataManager.instance.saveData.isFirstPlay[0])
        {
            yield return null;
            if (Input.GetMouseButtonDown(0))
            {
                DataManager.instance.saveData.isFirstPlay[0] = false;
                tutorial.SetActive(false);
                Time.timeScale = 1;
                break;
            }
        }

        StartCoroutine(GameProcess());
    }
}