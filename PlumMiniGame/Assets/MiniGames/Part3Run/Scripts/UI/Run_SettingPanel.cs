using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class Run_SettingPanel : MonoBehaviour
{
    [SerializeField] private GameObject SoundManager;

    public void SettingButtonOnClick() {
        ButtonSoundManager.instance.sound.Play();

        if (Time.timeScale == 0) {
            SoundManager.GetComponent<AudioSource>().UnPause();

            Time.timeScale = 1;
            transform.gameObject.SetActive(false);
        } else {
            SoundManager.GetComponent<AudioSource>().Pause();

            Time.timeScale = 0;
            transform.gameObject.SetActive(true);
        }
    }

    public void ExitButtonOnClick() {
        ButtonSoundManager.instance.sound.Play();
        SceneManager.LoadScene("GameSelectScene");
    }

    public void RestartButtonOnClick() {
        ButtonSoundManager.instance.sound.Play();
        Time.timeScale = 1;
        SceneManager.LoadScene("Part3_Run");
    }
}
