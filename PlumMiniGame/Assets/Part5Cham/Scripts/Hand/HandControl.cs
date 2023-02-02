using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HandControl : MonoBehaviour
{
    [SerializeField]
    public GameObject left_hand;
    [SerializeField]
    public GameObject front_hand;
    [SerializeField]
    public GameObject right_hand;
    public static bool hand_turned;

    public static int hand_dir;
    // Start is called before the first frame update
    void Start()
    {
        hand_dir = 1;
        hand_turned = false;
        left_hand.SetActive(false);
        right_hand.SetActive(false);
    }

    void Update()
    {
        if (GameManager.is_rest)
        {
            hand_turned = false;
            left_hand.SetActive(false);
            front_hand.SetActive(true);
            right_hand.SetActive(false);
        }
    }
}

