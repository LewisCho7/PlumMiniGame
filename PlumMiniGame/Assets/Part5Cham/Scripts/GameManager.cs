using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.XR;

public class GameManager : MonoBehaviour
{
    public static bool hard_mode;

    public static float round_time;
    public static float rest_time;
    public static float timer = 0;

    public static int round;
    public static int life;
    public static int score;

    public static bool is_rest;
    public static bool game_on_process;
    public static bool reverse_round;

    [SerializeField]
    private GameObject OX;
    [SerializeField] 
    private GameObject Heart;
    [SerializeField]
    private GameObject Combo;
    [SerializeField]
    private GameObject Hand;
    [SerializeField]
    private GameObject reverse;
    [SerializeField]
    private GameObject panda;
    void Start()
    {
        hard_mode = true;
        is_rest = true;

        if (hard_mode)
        {
            round_time = 5;
        }
        else
        {
            round_time = 8;
        }
        round = 0;
        rest_time = 0.5f;
        life = 3;

        game_on_process = false;

        StartCoroutine(GameProcess());
    }
    
    // Update is called once per frame
    void Update()
    {
        if (!is_rest)
        {
            timer += Time.deltaTime;
        }
        if (game_on_process && life == 0)
        {
            StopCoroutine(GameProcess());
            StartCoroutine(GameOver());
        }
        if (life == 0)
        {
            game_on_process = false;
        }
    }

    IEnumerator GameProcess()
    {
        while (!game_on_process)
        {
            yield return null;

            if (is_rest)
            {
                round++;
                Heart.GetComponent<Heart>().HeartUIUpdate();
                RoundTimeUpdate();
                yield return new WaitForSeconds(2);

                is_rest = false;
                if (round > 10 && Random.Range(1, 10) <= 3)
                {
                    reverse_round = true;
                }
                else
                {
                    reverse_round = false;
                }
                reverse.SetActive(reverse_round);
            }
            else
            {
                bool check; 

                if (HandControl.hand_turned)
                {
                    check = CheckAns();

                    if (timer <= (round_time / 2))
                    {
                        ComboControl.combo++;
                        Combo.GetComponent<ComboControl>().ComboUpdate();
                        StartCoroutine(Combo.GetComponent<ComboControl>().ComboUiPopup(check));
                    }
                    else
                    {
                        ComboControl.combo = 0;
                    }
                    Life(check);
                    OX.GetComponent<OX>().popresult(check);

                    yield return new WaitForSeconds(1);

                    panda.GetComponent<Pandas>().HitPanda(check);

                    is_rest = true;
                    timer = 0;
                }

                if (timer > round_time) //no behavior
                {
                    Life(false);
                    OX.GetComponent<OX>().popresult(false);
                    is_rest = true;
                    timer = 0;  
                }
            }
            
            if (life == 0)
            {
                game_on_process = true;
                break;
            }
        }
    }

    private bool CheckAns()
    {
        if (!reverse_round && Mathf.Abs(HandControl.hand_dir - Pandas.pandas_dir) == 2) //ordinary round
        {
            return true;
        }
        else if(reverse_round && HandControl.hand_dir == Pandas.pandas_dir) //reverse round
        {
            return true;
        }
        else
        {
            return false;
        }
    }

    private void Life(bool check)
    {
        if (!check)
        {
            life--;
            ComboControl.combo = 0;
        }
    }

    private void RoundTimeUpdate()
    {
        if (hard_mode)
        {
            if (round % 3 == 0)
            {
                if (round_time <= 1)
                  round_time = 0.5f;
                else
                    round_time--;
            }
        }
        else
        {
            if (round % 3 == 0)
            {
                if (round_time <= 1)
                    round_time = 0.8f;
                else
                    round_time--;
            }
        }

    }

    private IEnumerator GameOver()
    {
        yield return new WaitForSeconds(1);
        Heart.SetActive(false);
        SceneManager.LoadScene("EndingScene");
    }
}
