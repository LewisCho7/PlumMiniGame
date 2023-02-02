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
        int one = GameManager.round % 10;
        sr.sprite = numbers[one];
    }
}
