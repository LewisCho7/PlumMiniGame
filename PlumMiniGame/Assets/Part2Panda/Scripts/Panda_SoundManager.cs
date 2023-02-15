using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Panda_SoundManager : MonoBehaviour
{
    private AudioSource audioSource;

    private bool flag = true;

    void Awake() {
        flag = true;

        audioSource = GetComponent<AudioSource>();
    }

    void Update() {
        
        if (Panda_GameManager.isEnd && flag) {

            audioSource.Stop();

            flag = false;
        }
    }
}
