using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameStart_ButtonManager : MonoBehaviour
{
    public void onClickStart()
    {
        // ���� ����� ���� ù ���� -> Ʃ��
        //SceneManager.LoadScene("MYROOM");

        if (DataManager.instance.saveData.isFirstExecute) {
            LoadingSceneManager.LoadScene("TutorialScene");
        } else {
            LoadingSceneManager.LoadScene("MYROOM");
        }
    }
}
