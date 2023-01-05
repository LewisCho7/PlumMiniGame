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

    private bool game_stop;
    private float timer = 0;

    [SerializeField]
    private GameObject OX;
    [SerializeField] 
    private GameObject Heart;

    void Start()
    {
        round = 0;
        rest_time = 0.5f;
        round_time = 5f;
        life = 3;
        game_stop = false;
        StartCoroutine("GameProcess");
    }
    
    // Update is called once per frame
    void Update()
    {
        if (!is_rest)
        {
            timer += Time.deltaTime;
        }
        if (game_stop)
        {
            StopAllCoroutines();
        }
        if (life == 0)
        {
            game_stop = false;
        }
    }

    IEnumerator GameProcess()
    {
        while (!game_stop)
        {
            yield return null;

            if (is_rest)
            {
                Debug.Log("rest");

                round++;
                OX.GetComponent<OX>().TurnDown();
                Heart.GetComponent<Heart>().HeartUIUpdate();

                yield return new WaitForSeconds(2);

                is_rest = false;
            }
            else
            {
                Debug.Log("round");
                
                bool check;

                if (HandControl.hand_turned) //choose his answer
                {
                    check = CheckAns();
                    Life(check);
                    OX.GetComponent<OX>().Popresult(check);
                    is_rest = true;
                }

                if (timer > 5) //no behavior
                {
                    Life(false);
                    OX.GetComponent<OX>().Popresult(false);
                    is_rest = true;
                    timer = 0;  
                }
            }
            
            if (life == 0)
            {
                game_stop = true;
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

}
