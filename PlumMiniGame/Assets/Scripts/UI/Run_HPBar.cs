using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Run_HPBar : MonoBehaviour
{
    private Slider slider;

    void Awake() {
        slider = transform.GetComponent<Slider>();
    }

    void Update() {
        slider.value = Run_Player.Life;

        transform.Find("Fill Area").gameObject.SetActive(slider.value > 0);
    }
}
