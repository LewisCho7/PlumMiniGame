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
    [SerializeField]
    private GameObject count_obj;
    [SerializeField]
    private Sprite[] count_sprite;

    private AudioSource dead_sound;
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
        count_obj.SetActive(false);
        dead_ui.SetActive(false);        
        dead_sound = GetComponent<AudioSource>();
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

        count_obj.SetActive(true);
        count_obj.GetComponent<SpriteRenderer>().sprite = count_sprite[0];
        yield return new WaitForSecondsRealtime(1);
        count_obj.GetComponent<SpriteRenderer>().sprite = count_sprite[1];
        yield return new WaitForSecondsRealtime(1);
        count_obj.GetComponent<SpriteRenderer>().sprite = count_sprite[2];
        yield return new WaitForSecondsRealtime(1);
        count_obj.GetComponent<SpriteRenderer>().sprite = count_sprite[3];
        yield return new WaitForSecondsRealtime(1);
        count_obj.SetActive(false);
        Time.timeScale = 1;

        while (game_continue)
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
    }
    
    IEnumerator GameOver()
    {
        dead_sound.Play();
        yield return null;
        yield return new WaitForSecondsRealtime(1);
        dead_ui.SetActive(true);

        main_camera.GetComponent<Rigidbody2D>().velocity = Vector3.zero;
    }
}
