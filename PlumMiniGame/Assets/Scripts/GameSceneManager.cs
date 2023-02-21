using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameSceneManager : MonoBehaviour
{
    public static GameSceneManager instance;

    [SerializeField] private AudioSource sound;

    private void Awake()
    {
        instance = this;
        Time.timeScale = 1;
    }
    public void gameSelectSceneLoad()
    {
        sound.Play();
        SceneManager.LoadScene("GameSelectScene");
    }

    public void myRoomSceneLoad()
    {
        sound.Play();
        SceneManager.LoadScene("MYROOM");
    }
    public void storageSceneLoad()
    {
        sound.Play();
        SceneManager.LoadScene("StorageScene");
    }

    public void CollectionSceneLoad() 
    {
        sound.Play();
        SceneManager.LoadScene("CollectionScene");
    }

    public void StoreSceneLoad()
    {
        sound.Play();
        SceneManager.LoadScene("MainStore");
    }

    public void FurnitureStoreLoad()
    {
        sound.Play();
        SceneManager.LoadScene("FurnitureStore");
    }

    public void CharacterStoreLoad()
    {
        sound.Play();
        SceneManager.LoadScene("CharacterStore");
    }

    // ���� �ѹ� �����ؾߵ�
    public void jumpGameLoad()
    {
        // ���� �ѹ� �����ؾߵ�
        sound.Play();
        SceneManager.LoadScene("Part1_jump");

    }
    public void eatGameLoad()
    {
        // ���� �ѹ� �����ؾߵ�
        sound.Play();
        SceneManager.LoadScene("Part2_panda");

    }
    public void runGameLoad()
    {
        // ���� �ѹ� �����ؾߵ�
        sound.Play();
        SceneManager.LoadScene("Part3_Run");

    }
    public void chamGameLoad()
    {
        // ���� �ѹ� �����ؾߵ�
        sound.Play();
        SceneManager.LoadScene("Part5_cham");

    }
    public void skiGameLoad()
    {
        // ���� �ѹ� �����ؾߵ�
        sound.Play();
        SceneManager.LoadScene("Part6_SkiGame");
    }

}
