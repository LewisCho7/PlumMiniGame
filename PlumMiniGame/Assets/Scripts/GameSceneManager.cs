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
        Time.timeScale = 1;
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

    public void CollectionSceneLoad() 
    {
        SceneManager.LoadScene("CollectionScene");
    }

    public void StoreSceneLoad()
    {
        SceneManager.LoadScene("MainStore");
    }

    // ���� �ѹ� �����ؾߵ�
    public void jumpGameLoad()
    {
        // ���� �ѹ� �����ؾߵ�
        SceneManager.LoadScene("Part1_jump");

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

        SceneManager.LoadScene("Part5_cham");

    }
    public void skiGameLoad()
    {
        // ���� �ѹ� �����ؾߵ�

        SceneManager.LoadScene("Part6_SkiGame");
    }

}
