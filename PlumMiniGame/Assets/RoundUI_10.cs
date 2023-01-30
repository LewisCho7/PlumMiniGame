using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RoundUI_10 : MonoBehaviour
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
        int ten = (int)(GameManager.round / 10);
        sr.sprite = numbers[ten];
    }
}
