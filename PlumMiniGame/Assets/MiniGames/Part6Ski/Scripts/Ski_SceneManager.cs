using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Ski_SceneManager : MonoBehaviour
{
    public static Ski_SceneManager instance;
    private void Awake()
    {
        instance = this;
    }
    public void returnScene()
    {
        ButtonSoundManager.instance.sound.Play();
        Debug.Log("returnedScene");
        SceneManager.LoadScene("Part6_SkiGame");
    }

    public void restartScene()
    {
        ButtonSoundManager.instance.sound.Play();
        SceneManager.LoadScene("Ski_RestartScene");
    }
}
