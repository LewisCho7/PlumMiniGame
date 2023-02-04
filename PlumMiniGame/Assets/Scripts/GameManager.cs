using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public static bool hard_mode;
    public static bool game_continue;

    public static int rescued_character = 0;

    public static float survived_time;
    [SerializeField]
    private GameObject character;
    [SerializeField]
    private GameObject main_camera;
    [SerializeField]
    private GameObject blur;

    void Awake()
    {
        Application.targetFrameRate = 60;
        Time.timeScale = 1;
    }

    // Start is called before the first frame update
    void Start()
    {
        hard_mode = true;
        survived_time = 0;
        game_continue = true;
        blur.SetActive(false);
        StartCoroutine(GameProcess());
    }

    // Update is called once per frame
    void Update()
    {
        survived_time += Time.deltaTime;
        Debug.Log(survived_time);
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

            if (main_camera.transform.position.y - character.transform.position.y
                > 660)
            {
                game_continue = false;
            }
        }
    }

    IEnumerator GameOver()
    {
        yield return null;
        yield return new WaitForSecondsRealtime(1);
        SceneManager.LoadScene("Ending_Scene");
    }
}
