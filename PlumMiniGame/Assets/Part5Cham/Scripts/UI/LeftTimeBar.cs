using System.Collections;
using System.Collections.Generic;
using System.Threading;
using UnityEngine;
using UnityEngine.UI;

public class LeftTimeBar : MonoBehaviour
{
    [SerializeField]
    private Slider left_time_slider;
    private float timer;
    // Start is called before the first frame update
    void Start()
    {
        timer = 0;
    }

    // Update is called once per frame
    void Update()
    {
        if (!GameManager.is_rest)
        {
            timer = 0;
            left_time_slider.value = (GameManager.timer / GameManager.round_time);
        }
        else
        {
            left_time_slider.value = 0;
        }
    }
}
