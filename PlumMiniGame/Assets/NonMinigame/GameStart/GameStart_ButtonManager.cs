using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameStart_ButtonManager : MonoBehaviour
{
    public void onClickStart()
    {
        // 저장 결과에 따라 첫 실행 -> 튜토
        SceneManager.LoadScene("MYROOM");
    }
}
