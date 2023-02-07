using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Settings : MonoBehaviour
{
    [SerializeField]
    private GameObject blur_img;
    void Start()
    {
        blur_img.SetActive(false);
    }

    public void SettingButtonClicked()
    {
        blur_img.SetActive(!blur_img.activeSelf);
        if (Time.timeScale == 0)
        {
            Time.timeScale= 1;
        }
        else
        {
            Time.timeScale = 0;
        }
    }

    protected void RestartButtonClicked()
    {
        SceneManager.LoadScene("Game_5");
    }

    protected void ExitButtonClicked()
    {
        //게임 나가기
    }
}
