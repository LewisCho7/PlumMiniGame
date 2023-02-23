using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class Run_SettingPanel : MonoBehaviour
{
    [SerializeField] private GameObject SoundManager;

    void Awake() {
        transform.Find("ExitButton").GetComponent<Image>().alphaHitTestMinimumThreshold
        = transform.Find("RestartButton").GetComponent<Image>().alphaHitTestMinimumThreshold = 0.1f;
    }

    public void SettingButtonOnClick() {

        // 음악 중지
        SoundManager.GetComponent<AudioSource>().Pause();

        Time.timeScale = 0;
        transform.GetComponent<Image>().color = new Color(0, 0, 0, 0.7f);
        transform.gameObject.SetActive(true);
    }

    public void ExitButtonOnClick() {
        ButtonSoundManager.instance.sound.Play();
        //StartCoroutine(SceneConvertAnimation.instance.LoadScene("GameSelectScene"));
        SceneManager.LoadScene("GameSelectScene");
    }

    public void RestartButtonOnClick() {
        Time.timeScale = 1;
        SceneManager.LoadScene("Part3_Run");
    }
}
