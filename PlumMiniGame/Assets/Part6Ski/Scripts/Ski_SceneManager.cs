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
        Debug.Log("returnedScene");
        SceneManager.LoadScene("Part6_SkiGame");
    }

    public void restartScene()
    {
        SceneManager.LoadScene("Ski_RestartScene");
    }
}
