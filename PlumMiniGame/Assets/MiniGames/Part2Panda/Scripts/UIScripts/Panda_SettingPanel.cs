using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class Panda_SettingPanel : MonoBehaviour
{

    [SerializeField] private GameObject soundManager;
    private AudioSource audioSource;

    void Awake() {
        audioSource = soundManager.GetComponent<AudioSource>();
    }

    public void SettingButtonOnClick() {

        ButtonSoundManager.instance.sound.Play();

        if (Time.timeScale == 0) {
            Time.timeScale = 1;
            transform.gameObject.SetActive(false);

            audioSource.UnPause();
        } else {
            Time.timeScale = 0;
            transform.gameObject.SetActive(true);

            audioSource.Pause();
        }
    }

    public void ExitButtonOnClick() {
        ButtonSoundManager.instance.sound.Play();
        SceneManager.LoadScene("GameSelectScene");
    }

    public void RestartButtonOnClick() {
        ButtonSoundManager.instance.sound.Play();
        Time.timeScale = 1;
        SceneManager.LoadScene("Part2_panda");
    }
}
