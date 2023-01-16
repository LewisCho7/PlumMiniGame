using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.XR;

public class GameManager : MonoBehaviour
{
    public static int round;
    public static float round_time;
    public static float rest_time;

    public static bool is_rest = true;
    public static int life;

    public static bool game_on_process;
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
    [SerializeField]
    private GameObject Hand;
    void Start()
    {
        GameOver_indicator.SetActive(false);
        take_some_rest.SetActive(false);

        round = 0;
        rest_time = 0.5f;
        round_time = 5f;
        life = 3;

        game_on_process = false;

        StartCoroutine("GameProcess");
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

                if (Input.GetKeyDown(KeyCode.LeftArrow))
                {
                    Hand.GetComponent<HandControl>().left_hand.SetActive(true);
                    Hand.GetComponent<HandControl>().front_hand.SetActive(false);
                    Hand.GetComponent<HandControl>().right_hand.SetActive(false);
                    HandControl.hand_turned = true;
                    HandControl.hand_dir = 0;
                }
                else if (Input.GetKeyDown(KeyCode.RightArrow))
                {
                    Hand.GetComponent<HandControl>().left_hand.SetActive(false);
                    Hand.GetComponent<HandControl>().front_hand.SetActive(false);
                    Hand.GetComponent<HandControl>().right_hand.SetActive(true);
                    HandControl.hand_turned = true;
                    HandControl.hand_dir = 2;
                }

                if (HandControl.hand_turned) //choose his answer
                {
                    check = CheckAns();

                    if (timer <= (round_time / 2))
                    {
                        ComboControl.combo++;
                        Combo.GetComponent<ComboControl>().ComboUpdate();
                        StartCoroutine(Combo.GetComponent<ComboControl>().ComboUiPopup());
                    }
                    else
                    {
                        ComboControl.combo = 0;
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
                game_on_process = true;
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
        if (!check)
        {
            life--;
            ComboControl.combo = 0;
        }
    }

    private void RoundTimeUpdate()
    {
        if (round % 3 == 0)
        {
            if (round_time <= 1)
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