using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RoundUI : MonoBehaviour
{
    private SpriteRenderer sr;
    [SerializeField]
    private Sprite[] numbers = new Sprite[10];
    void Start()
    {
        sr = GetComponent<SpriteRenderer>();
    }

    void Update()
    {
        if(gameObject.name == "numbers_10")
        {
            sr.sprite = numbers[(int)GameManager.round / 10];
        }
        else if (gameObject.name == "numbers_1")
        {
            sr.sprite = numbers[GameManager.round % 10];
        }
    }
}
