using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Panda_SoundManager : MonoBehaviour
{
    [SerializeField] private AudioClip[] Audio = new AudioClip[2];
    enum AudioClips {bg, gameover};

    private AudioSource audioSource;

    private bool flag = true;

    void Awake() {
        flag = true;

        audioSource = GetComponent<AudioSource>();
        audioSource.clip = Audio[(int)AudioClips.bg];
        audioSource.loop = true;
        audioSource.Play();
    }

    void Update() {
        
        if (Panda_GameManager.isEnd && flag) {

            audioSource.clip = Audio[(int)AudioClips.gameover];
            audioSource.loop = false;
            audioSource.Play();

            flag = false;
        }
    }
}
