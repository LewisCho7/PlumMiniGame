using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR;

public class rightButton : MonoBehaviour
{
    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.RightArrow))
        {
            HandControl.hand_dir = 2;
            HandControl.hand_turned = true;
        }
    }
    public void rightButtonClicked()
    {
        if (!HandControl.hand_turned)
        {
            HandControl.hand_turned = true;
            HandControl.hand_dir = 2;
        }
    }
}
