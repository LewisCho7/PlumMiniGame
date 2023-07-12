using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ComboNum : MonoBehaviour
{
    [SerializeField]
    private GameObject one;
    [SerializeField] 
    private GameObject ten;
    [SerializeField]
    private Sprite[] sprites;

    private SpriteRenderer osr;
    private SpriteRenderer tsr;

    // Start is called before the first frame update
    void Start()
    {
        osr = one.GetComponent<SpriteRenderer>();
        tsr = ten.GetComponent<SpriteRenderer>();
    }

    // Update is called once per frame
    void Update()
    {
        osr.sprite = sprites[ComboControl.combo % 10];
        tsr.sprite = sprites[ComboControl.combo / 10];
    }
}
