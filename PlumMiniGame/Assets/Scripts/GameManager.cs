using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public static bool hard_mode = false;
    public static bool game_continue = true;

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
        survived_time = 0;
    }

    // Start is called before the first frame update
    void Start()
    {
        
        game_continue = true;
        blur.SetActive(false);
        StartCoroutine(GameProcess());
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
