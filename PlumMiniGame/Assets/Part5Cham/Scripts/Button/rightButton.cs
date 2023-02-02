using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR;

public class rightButton : MonoBehaviour
{
    [SerializeField]
    private GameObject hand;

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.RightArrow))
        {
            hand.GetComponent<HandControl>().left_hand.SetActive(false);
            hand.GetComponent<HandControl>().front_hand.SetActive(false);
            hand.GetComponent<HandControl>().right_hand.SetActive(true);
            HandControl.hand_turned = true;
            HandControl.hand_dir = 2;
        }
    }
    public void rightButtonClicked()
    {
        if (!HandControl.hand_turned)
        {
            hand.GetComponent<HandControl>().left_hand.SetActive(false);
            hand.GetComponent<HandControl>().front_hand.SetActive(false);
            hand.GetComponent<HandControl>().right_hand.SetActive(true);
            HandControl.hand_turned = true;
            HandControl.hand_dir = 2;
        }
    }
}
