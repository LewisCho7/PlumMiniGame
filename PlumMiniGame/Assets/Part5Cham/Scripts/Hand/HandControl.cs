using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HandControl : MonoBehaviour
{
    [SerializeField]
    public Sprite[] hands;
    private SpriteRenderer sr;

    public static bool hand_turned;
    public static int hand_dir;

    // Start is called before the first frame update
    void Start()
    {
        sr = GetComponent<SpriteRenderer>();
        hand_dir = 1;
        hand_turned = false;
        sr.sprite = hands[hand_dir];
    }

    void Update()
    {
        if (ChamGameManager.is_rest)
        {
            hand_turned = false;
            hand_dir = 1;
        }
        sr.sprite = hands[hand_dir];
    }
}

