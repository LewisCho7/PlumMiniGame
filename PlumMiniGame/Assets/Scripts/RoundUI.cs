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
        sr.sprite = numbers[GameManager.round];
    }
}
