using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ski_SoundManager : MonoBehaviour
{
    private AudioSource audioSource;

    private bool flag = true;

    void Awake()
    {
        flag = true;

        audioSource = GetComponent<AudioSource>();
    }

    void Update()
    {

        if (Ski_GameManager.instance.isGameOver && flag)
        {

            audioSource.Stop();

            flag = false;
        }
    }


}
