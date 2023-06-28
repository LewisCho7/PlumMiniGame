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
        Time.timeScale = 1;
        ButtonSoundManager.instance.sound.Play();
        if (!BGMSoundManager.instance.sound.isPlaying)
        {
            BGMSoundManager.instance.sound.Play();
        }
        StartCoroutine(SceneConvertAnimation.instance.LoadScene("GameSelectScene"));
    }

    public void myRoomSceneLoad()
    {
        ButtonSoundManager.instance.sound.Play();
        SceneManager.LoadScene("MYROOM");
    }

    public void myRoomSceneLoadAni()
    {
        Time.timeScale = 1;
        ButtonSoundManager.instance.sound.Play();
        if (SceneManager.GetActiveScene().name == "GameSelectScene")
        {
            DataManager.instance.isHardMode = false;
        }
        StartCoroutine(SceneConvertAnimation.instance.LoadScene("MYROOM"));
    }
    
    public void storageSceneLoad()
    {
        Time.timeScale = 1;
        ButtonSoundManager.instance.sound.Play();
        StartCoroutine(SceneConvertAnimation.instance.LoadScene("StorageScene"));
    }

    public void CollectionSceneLoad() 
    {
        Time.timeScale = 1;
        ButtonSoundManager.instance.sound.Play();
        StartCoroutine(SceneConvertAnimation.instance.LoadScene("CollectionScene"));
    }

    public void StoreSceneLoad()
    {
        Time.timeScale = 1;
        ButtonSoundManager.instance.sound.Play();
        StartCoroutine(SceneConvertAnimation.instance.LoadScene("MainStore"));
    }

    public void FurnitureStoreLoad()
    {
        Time.timeScale = 1;
        ButtonSoundManager.instance.sound.Play();
        StartCoroutine(SceneConvertAnimation.instance.LoadScene("FurnitureStore"));
    }

    public void CharacterStoreLoad()
    {
        Time.timeScale = 1;
        ButtonSoundManager.instance.sound.Play();
        StartCoroutine(SceneConvertAnimation.instance.LoadScene("CharacterStore"));
    }

    // ���� �ѹ� �����ؾߵ�
    public void jumpGameLoad()
    {
        // ���� �ѹ� �����ؾߵ�
        Time.timeScale = 1;
        ButtonSoundManager.instance.sound.Play();
        BGMSoundManager.instance.sound.Stop();
        LoadingSceneManager.LoadScene("Part1_jump");
    }
    public void eatGameLoad()
    {
        // ���� �ѹ� �����ؾߵ�
        ButtonSoundManager.instance.sound.Play();
        BGMSoundManager.instance.sound.Stop();
        LoadingSceneManager.LoadScene("Part2_panda");
    }
    public void runGameLoad()
    {
        // ���� �ѹ� �����ؾߵ�
        ButtonSoundManager.instance.sound.Play();
        BGMSoundManager.instance.sound.Stop();
        LoadingSceneManager.LoadScene("Part3_Run");

    }
    public void chamGameLoad()
    {
        // ���� �ѹ� �����ؾߵ�
        Time.timeScale = 1;
        ButtonSoundManager.instance.sound.Play();
        BGMSoundManager.instance.sound.Stop();
        LoadingSceneManager.LoadScene("Part5_cham");

    }
    public void skiGameLoad()
    {
        // ���� �ѹ� �����ؾߵ�
        ButtonSoundManager.instance.sound.Play();
        BGMSoundManager.instance.sound.Stop();
        LoadingSceneManager.LoadScene("Part6_SkiGame");
    }

}
