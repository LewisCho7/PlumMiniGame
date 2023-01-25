using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Numbers : MonoBehaviour
{
    [SerializeField]
    Sprite[] numbers;
    // Start is called before the first frame update
    private SpriteRenderer sr;

    void Start()
    {
        sr = GetComponent<SpriteRenderer>();
    }

    void Update()
    {
        sr.sprite = numbers[ComboControl.combo - 1];
    }
}
