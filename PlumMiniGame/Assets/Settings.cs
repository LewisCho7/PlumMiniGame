using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Settings : MonoBehaviour
{
    [SerializeField]
    private GameObject setting_button;
    public void SettingButtonClicked()
    {
        GameManager.game_on_process = !GameManager.game_on_process;
    }
}
