using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LeftButton : MonoBehaviour
{
    [SerializeField]
    private GameObject hand;
    public void leftButtonClicked()
    {
        if (!HandControl.hand_turned)
        {
            hand.GetComponent<HandControl>().left_hand.SetActive(true);
            hand.GetComponent<HandControl>().front_hand.SetActive(false);
            hand.GetComponent<HandControl>().right_hand.SetActive(false);
            HandControl.hand_turned = true;
            HandControl.hand_dir = 0;

            Debug.Log(HandControl.hand_dir);
        }
    }
}
