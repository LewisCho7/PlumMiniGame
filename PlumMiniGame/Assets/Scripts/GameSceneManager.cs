using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameSceneManager : MonoBehaviour
{
    public static GameSceneManager instance;

    private void Awake()
    {
        instance = this;
    }
    public void gameSelectSceneLoad()
    {
        SceneManager.LoadScene("GameSelectScene");
    }

    public void myRoomSceneLoad()
    {
        SceneManager.LoadScene("MYROOM");

    }
    public void storageSceneLoad()
    {
        SceneManager.LoadScene("StorageScene");
    }
}
