using System.Collections;
using System.Collections.Generic;
using Unity.Burst.Intrinsics;
using UnityEngine;

public class ComboControl : MonoBehaviour
{
    public static int combo;
    private AudioSource combo_sound;

    private void Awake()
    {
        combo = 0;
    }

    // Start is called before the first frame update
    void Start()
    {
        gameObject.SetActive(false);
        combo_sound = GetComponent<AudioSource>();
    }

    public IEnumerator ComboUiPopup(bool check)
    {
        if (check)
        {
            combo_sound.Play();
            gameObject.SetActive(true);
            yield return new WaitForSeconds(0.5f);
            gameObject.SetActive(false);
        }

    }

    public void ComboUpdate()
    {
        if (combo % 5 == 0)
        {
            if (ChamGameManager.hard_mode)
            {
                if (ChamGameManager.life < 3)
                {
                    ChamGameManager.life++;
                }

            }
            else
            {
                if (ChamGameManager.life < 6)
                {
                    ChamGameManager.life++;
                }
            }
        }
        ChamGameManager.score += combo * 10;
    }
}
