using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.XR;

public class LeftButton : MonoBehaviour
{
    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.LeftArrow))
        {
            HandControl.hand_dir = 0;
            HandControl.hand_turned = true;
        }
    }
    public void leftButtonClicked()
    {
        if (!HandControl.hand_turned)
        {
            HandControl.hand_turned = true;
            HandControl.hand_dir = 0;
        }
    }
}
