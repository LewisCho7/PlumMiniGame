using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static int round;
    public static float round_time;
    public static float rest_time;

    public static bool is_rest = true;
    public static int life;

    private bool game_is_end;
    private float timer = 0;

    [SerializeField]
    private GameObject take_some_rest;
    [SerializeField]
    private GameObject OX;
    [SerializeField] 
    private GameObject Heart;
    [SerializeField]
    private GameObject GameOver_indicator;
    [SerializeField]
    private GameObject Combo;
    void Start()
    {
        GameOver_indicator.SetActive(false);
        take_some_rest.SetActive(false);

        round = 0;
        rest_time = 0.5f;
        round_time = 5f;
        life = 3;

        game_is_end = false;

        StartCoroutine("GameProcess");
    }
    
    // Update is called once per frame
    void Update()
    {
        if (!is_rest)
        {
            timer += Time.deltaTime;
        }
        if (game_is_end)
        {
            StopCoroutine(GameProcess());
            StartCoroutine(GameOver());
        }
        if (life == 0)
        {
            game_is_end = false;
        }
    }

    IEnumerator GameProcess()
    {
        while (!game_is_end)
        {
            yield return null;

            if (is_rest)
            {
                round++;
                Heart.GetComponent<Heart>().HeartUIUpdate();
                take_some_rest.SetActive(true);
                RoundTimeUpdate();
                yield return new WaitForSeconds(2);

                is_rest = false;
            }
            else
            {
                Debug.Log(round_time);
                bool check; 
                take_some_rest.SetActive(false);

                if (HandControl.hand_turned) //choose his answer
                {
                    check = CheckAns();

                    if (timer <= (round_time / 2))
                    {
                        ComboControl.combo++;
                        Combo.GetComponent<ComboControl>().ComboUpdate();
                        StartCoroutine(Combo.GetComponent<ComboControl>().ComboUiPopup());

                    }

                    Life(check);
                    OX.GetComponent<OX>().Popresult(check);

                    yield return new WaitForSeconds((round_time - timer));
                    is_rest = true;
                    timer = 0;
                }

                if (timer > round_time) //no behavior
                {
                    Life(false);
                    OX.GetComponent<OX>().Popresult(false);
                    is_rest = true;
                    timer = 0;  
                }
            }
            
            if (life == 0)
            {
                game_is_end = true;
                break;
            }
        }
    }

    private bool CheckAns()
    {
        if (Mathf.Abs(HandControl.hand_dir - Pandas.pandas_dir) == 2)
        {
            return true;
        }
        else return false;
    }

    private void Life(bool check)
    {
        if (!check) life--;
    }

    private void RoundTimeUpdate()
    {
        if (round % 3 == 0)
        {
            if (round_time == 1)
                round_time = 0.5f;
            else
                round_time--;
        }
    }

    private IEnumerator GameOver()
    {
        yield return new WaitForSeconds(1);
        Heart.SetActive(false);
        GameOver_indicator.SetActive(true);
    }
}
