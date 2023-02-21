using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameStart_ButtonManager : MonoBehaviour
{

    [SerializeField] private AudioSource sound;

    public void onClickStart()
    {
        // ���� ����� ���� ù ���� -> Ʃ��
        //SceneManager.LoadScene("MYROOM");

        sound.Play();

        if (DataManager.instance.saveData.isFirstExecute) {
            LoadingSceneManager.LoadScene("TutorialScene");
        } else {
            LoadingSceneManager.LoadScene("MYROOM");
        }
    }
}
