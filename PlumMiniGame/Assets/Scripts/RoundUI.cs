using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RoundUI : MonoBehaviour
{
    [SerializeField]
    private Sprite[] numbers;

    private SpriteRenderer[] sprites;
    void Start()
    {
        numbers = Resources.LoadAll<Sprite>("Sprites/UI/number");
    }

    void Update()
    {

        string round = GameManager.round.ToString();
        sprites = new SpriteRenderer[round.Length];
        int idx = 0;
        foreach (char c in round)
        {
            sprites[idx - 1].sprite = numbers[(int)c - 1];
        }
    }
}
