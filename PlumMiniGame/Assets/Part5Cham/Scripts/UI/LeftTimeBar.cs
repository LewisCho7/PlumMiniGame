using System.Collections;
using System.Collections.Generic;
using System.Threading;
using UnityEngine;
using UnityEngine.UI;

public class LeftTimeBar : MonoBehaviour
{
    [SerializeField]
    private Slider left_time_slider;
    // Start is called before the first frame update
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {
        if (!GameManager.is_rest)
        {
            left_time_slider.value = (GameManager.timer / GameManager.round_time);
        }
    }
}
