using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TiltSlider : MonoBehaviour
{
    [SerializeField]
    private Slider tilt_slider;

    private float tilt_coefficient_max;
    // Start is called before the first frame update
    void Start()
    {
        tilt_slider.value = 0.5f;
        tilt_coefficient_max = 200;
        Character.tilt_coefficient = tilt_slider.value * tilt_coefficient_max;
    }

    // Update is called once per frame
    void Update()
    {
        Character.tilt_coefficient = tilt_slider.value * tilt_coefficient_max;
    }
}
