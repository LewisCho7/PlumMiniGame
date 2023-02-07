using System.Collections;
using System.Collections.Generic;
using Unity.Burst.Intrinsics;
using UnityEngine;

public class ComboControl : MonoBehaviour
{
    public static int combo;
    // Start is called before the first frame update
    void Start()
    {
        gameObject.SetActive(false);
        combo = 0;
    }

    public IEnumerator ComboUiPopup(bool check)
    {
        if (check)
        {
            gameObject.SetActive(true);
            yield return new WaitForSeconds(0.5f);
            gameObject.SetActive(false);
        }

    }

    public void ComboUpdate()
    {
        if(combo == 6)
        {
            combo = 1;
        }

        if (combo % 5 == 0)
        {
            if (ChamGameManager.hard_mode)
            {
                if (ChamGameManager.life < 3)
                    ChamGameManager.life++;
            }
            else
            {
                if (ChamGameManager.life < 6)
                {
                    ChamGameManager.life++;
                }
            }
        }
        GameManager.score += combo * 10;
    }
}
