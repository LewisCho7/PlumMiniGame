using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;
using UnityEngine;

public class BGMSoundManager : MonoBehaviour
{
    public AudioSource sound;

    public static BGMSoundManager instance = null;

    void Awake()
    {
        if (SceneManager.GetActiveScene() == SceneManager.GetSceneByName("GameStartScene")){
            sound.Play();
        }
        if (instance == null) instance = this;
        else if (instance != this) Destroy(gameObject);

        DontDestroyOnLoad(gameObject);
    }
}
