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


    // ���� �ѹ� �����ؾߵ�
    public void jumpGameLoad()
    {
        // ���� �ѹ� �����ؾߵ�
        SceneManager.LoadScene("");

    }
    public void eatGameLoad()
    {
        // ���� �ѹ� �����ؾߵ�

        SceneManager.LoadScene("Part2_panda");

    }
    public void runGameLoad()
    {
        // ���� �ѹ� �����ؾߵ�

        SceneManager.LoadScene("Part3_Run");

    }
    public void chamGameLoad()
    {
        // ���� �ѹ� �����ؾߵ�

        SceneManager.LoadScene("Game_5");

    }
    public void skiGameLoad()
    {
        // ���� �ѹ� �����ؾߵ�

        SceneManager.LoadScene("Part6_SkiGame");
    }

}
