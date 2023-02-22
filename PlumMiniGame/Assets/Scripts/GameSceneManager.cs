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
        ButtonSoundManager.instance.sound.Play();
        SceneManager.LoadScene("GameSelectScene");
    }

    public void myRoomSceneLoad()
    {
        ButtonSoundManager.instance.sound.Play();
        SceneManager.LoadScene("MYROOM");
    }
    public void storageSceneLoad()
    {
        ButtonSoundManager.instance.sound.Play();
        SceneManager.LoadScene("StorageScene");
    }

    public void CollectionSceneLoad() 
    {
        ButtonSoundManager.instance.sound.Play();
        SceneManager.LoadScene("CollectionScene");
    }

    public void StoreSceneLoad()
    {
        ButtonSoundManager.instance.sound.Play();
        SceneManager.LoadScene("MainStore");
    }

    public void FurnitureStoreLoad()
    {
        ButtonSoundManager.instance.sound.Play();
        SceneManager.LoadScene("FurnitureStore");
    }

    public void CharacterStoreLoad()
    {
        ButtonSoundManager.instance.sound.Play();
        SceneManager.LoadScene("CharacterStore");
    }

    // ���� �ѹ� �����ؾߵ�
    public void jumpGameLoad()
    {
        // ���� �ѹ� �����ؾߵ�
        ButtonSoundManager.instance.sound.Play();
        SceneManager.LoadScene("Part1_jump");

    }
    public void eatGameLoad()
    {
        // ���� �ѹ� �����ؾߵ�
        ButtonSoundManager.instance.sound.Play();
        SceneManager.LoadScene("Part2_panda");

    }
    public void runGameLoad()
    {
        // ���� �ѹ� �����ؾߵ�
        ButtonSoundManager.instance.sound.Play();
        SceneManager.LoadScene("Part3_Run");

    }
    public void chamGameLoad()
    {
        // ���� �ѹ� �����ؾߵ�
        ButtonSoundManager.instance.sound.Play();
        SceneManager.LoadScene("Part5_cham");

    }
    public void skiGameLoad()
    {
        // ���� �ѹ� �����ؾߵ�
        ButtonSoundManager.instance.sound.Play();
        SceneManager.LoadScene("Part6_SkiGame");
    }

}
