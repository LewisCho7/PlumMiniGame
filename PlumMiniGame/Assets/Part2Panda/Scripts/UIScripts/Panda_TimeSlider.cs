using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Panda_TimeSlider : MonoBehaviour
{
    private Slider slider;
    private GameObject fill;

    void Awake() {
        slider = GetComponent<Slider>();
        fill = transform.Find("Fill Area").gameObject;
    }

    void Update()
    {
        slider.value = 3 - Panda_UIManager.time;
        fill.SetActive(slider.value > 0);
    }
}
