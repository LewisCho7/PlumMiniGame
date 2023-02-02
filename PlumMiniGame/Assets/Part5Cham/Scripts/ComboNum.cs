using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ComboNum : MonoBehaviour
{
    private SpriteRenderer sr;
    [SerializeField]
    private Sprite[] sprites;
    // Start is called before the first frame update
    void Start()
    {
        sr = GetComponent<SpriteRenderer>();
    }

    // Update is called once per frame
    void Update()
    {
        sr.sprite = sprites[ComboControl.combo - 1];
    }
}
