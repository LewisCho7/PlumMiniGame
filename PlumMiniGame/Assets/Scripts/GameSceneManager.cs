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


    // 게임 넘버 전달해야됨
    public void jumpGameLoad()
    {
        // 게임 넘버 전달해야됨
        SceneManager.LoadScene("");

    }
    public void eatGameLoad()
    {
        // 게임 넘버 전달해야됨

        SceneManager.LoadScene("Part2_panda");

    }
    public void runGameLoad()
    {
        // 게임 넘버 전달해야됨

        SceneManager.LoadScene("Part3_Run");

    }
    public void chamGameLoad()
    {
        // 게임 넘버 전달해야됨

        SceneManager.LoadScene("Game_5");

    }
    public void skiGameLoad()
    {
        // 게임 넘버 전달해야됨

        SceneManager.LoadScene("Part6_SkiGame");
    }

}
