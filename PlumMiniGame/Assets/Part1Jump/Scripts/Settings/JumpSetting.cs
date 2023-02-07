using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class JumpSetting : MonoBehaviour
{
    [SerializeField]
    private GameObject blur_img;
    void Start()
    {
        blur_img.SetActive(false);
    }

    public void RestartButtonClicked()
    {
        SceneManager.LoadScene("Part1_jump");
    }

    public void SettingButtonClicked()
    {
        blur_img.SetActive(!blur_img.activeSelf);
        if (Time.timeScale == 0)
        {
            Time.timeScale = 1;
        }
        else
        {
            Time.timeScale = 0;
        }
    }
}
