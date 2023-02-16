using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ChamSettings : MonoBehaviour
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

    public void RestartButtonClicked()
    {
        SceneManager.LoadScene("Part5_cham");
    }
}
