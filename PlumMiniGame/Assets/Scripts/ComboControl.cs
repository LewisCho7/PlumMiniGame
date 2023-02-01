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
        if (combo % 5 == 0)
        {
            if (GameManager.hard_mode)
            {
                if (GameManager.life < 3)
                    GameManager.life++;
            }
            else
            {
                if (GameManager.life < 6)
                {
                    GameManager.life++;
                }
            }
        }
    }
}
