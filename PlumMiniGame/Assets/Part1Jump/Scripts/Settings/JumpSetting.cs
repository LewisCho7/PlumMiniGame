using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class JumpSetting : MonoBehaviour
{
    [SerializeField]
    private GameObject blur;
    private void Start()
    {
        blur.SetActive(false);
    }
    public void RestartButtonClicked()
    {
        SceneManager.LoadScene("Part1_jump");
    }

    public void SettingButtonclicked()
    {
        blur.SetActive(!blur.activeSelf);
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
