using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Settings : MonoBehaviour
{
    [SerializeField]
    private GameObject blur_img;
    public void SettingButtonClicked()
    {
        GameManager.game_on_process = !GameManager.game_on_process;
        blur_img.SetActive(!blur_img.activeSelf);
    }
}
