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
        Time.timeScale = 0;
        
        hard_mode = DataManager.instance.isHardMode;
        game_continue = true;
        
        survived_time = 0;
    }

    // Start is called before the first frame update
    void Start()
    {
        dead_ui.SetActive(false);
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
        }
    }

    IEnumerator GameProcess()
    {
        while (DataManager.instance.saveData.isFirstPlay[0])
        {
            yield return null;
        }

        while(game_continue)
        {
            yield return null;

            if (main_camera.transform.position.y - character.transform.position.y > 660)
            {
                game_continue = false;
            }
        }
    }

    public void TutorialDisappear()
    {
        tutorial.SetActive(false);
        DataManager.instance.saveData.isFirstPlay[0] = false;
        Time.timeScale = 1;
    }
    
    IEnumerator GameOver()
    {
        yield return null;
        yield return new WaitForSecondsRealtime(1);
        dead_ui.SetActive(true);

        main_camera.GetComponent<Rigidbody2D>().velocity = Vector3.zero;
    }
}
