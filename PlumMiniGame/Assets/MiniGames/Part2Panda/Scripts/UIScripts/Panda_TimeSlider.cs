using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Panda_TimeSlider : MonoBehaviour
{
    private Slider slider;
    private GameObject fill;
    private AudioSource audioSource;

    private bool flag = true;

    void Awake() {
        slider = GetComponent<Slider>();
        fill = transform.Find("Fill Area").gameObject;
        audioSource = GetComponent<AudioSource>();
    }

    void Update()
    {
        slider.value = 3 - Panda_UIManager.time;

        if (slider.value < 3 && slider.value > 0 && flag) {
            audioSource.Play();
            flag = false;
        }

        if (slider.value == 3) {
            audioSource.Stop();
            flag = true;
        }

        fill.SetActive(slider.value > 0);
    }
}
