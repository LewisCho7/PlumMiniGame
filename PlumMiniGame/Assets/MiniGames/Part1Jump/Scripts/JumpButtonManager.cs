using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class JumpButtonManager : MonoBehaviour
{
    [SerializeField]
    private GameObject settings;
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }

    public void PauseGame()
    {
        ButtonSoundManager.instance.sound.Play();
        Time.timeScale = 0f;
        settings.SetActive(true);
    }

    public void ResumeGame()
    {
        ButtonSoundManager.instance.sound.Play();
        Time.timeScale = 1f;
        settings.SetActive(false);
    }
}
