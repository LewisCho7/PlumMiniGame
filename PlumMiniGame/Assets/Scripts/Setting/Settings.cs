using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Settings : MonoBehaviour
{
    [SerializeField]
    private GameObject blur_img;
    [SerializeField]
    private GameObject buttons;

    void Start()
    {
        buttons.SetActive(false);
    }

    public void SettingButtonClicked()
    {
        blur_img.SetActive(!blur_img.activeSelf);
        buttons.SetActive(!buttons.activeSelf);
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
