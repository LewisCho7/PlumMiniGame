using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pandas : MonoBehaviour
{
    [SerializeField]
    Sprite[] panda_turn;
    [SerializeField]
    Sprite[] hit_motion;

    SpriteRenderer sr;

    private bool turned = false;

    public static int pandas_dir;
    void Start()
    {
        sr = GetComponent<SpriteRenderer>(); 
        sr.sprite = panda_turn[1];
    }

    void Update()
    {
        if (GameManager.is_rest)
        {
            sr.sprite = panda_turn[1];
            turned = false;
        }
        else
        {
            if (!turned)
            {
                pandas_dir = FaceTurning();
                turned = true;
            }
        }
    }

    int FaceTurning()
    {
        int dir = Random.Range(0, 2);
        if (dir == 0)
        {
            sr.sprite = panda_turn[0];
        }
        else if (dir == 1)
        {
            sr.sprite = panda_turn[2];
        }
        return dir == 0 ? dir : 2;
    }

    public void HitPanda(bool check)
    {
        StartCoroutine(HitPanda_Coroutine(check));
    }

    public IEnumerator HitPanda_Coroutine(bool check)
    {
        yield return null;

        if (check)
        {
            sr.sprite = hit_motion[0];
            yield return new WaitForSeconds(0.5f);
            sr.sprite = hit_motion[1];
            yield return new WaitForSeconds(0.5f);
        }
        else
        {
            yield return new WaitForSeconds(1);
        }
    }
}
