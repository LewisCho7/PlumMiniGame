using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Setting : MonoBehaviour
{
    [SerializeField]
    private GameObject blur;
    private void Start()
    {
        blur.SetActive(false);
    }
    public virtual void RestartButtonClicked()
    {

    }

    public virtual void ExitButtonClicked()
    {

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
