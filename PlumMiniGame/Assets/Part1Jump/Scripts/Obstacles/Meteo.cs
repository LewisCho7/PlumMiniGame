using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Meteo : MonoBehaviour
{
    private Rigidbody2D rb;
    private SpriteRenderer sr;
    private GameObject main_camera;
    [SerializeField]
    private Sprite[] meteo_sprite;

    private GameObject character;
    private bool score_checked;
    // Start is called before the first frame update
    void Start()
    {
        sr = GetComponent<SpriteRenderer>();
        sr.sprite = meteo_sprite[Random.Range(0, 2)];

        main_camera = GameObject.Find("Main Camera");
        character = GameObject.Find("Character");

        transform.position
            = new Vector3(Random.Range(-280, 280), main_camera.transform.position.y + 650, 0);
        rb = GetComponent<Rigidbody2D>();
        rb.velocity = new Vector3(0, -180, 0);
    }

    // Update is called once per frame
    void Update()
    {
        if (character.transform.position.y > transform.position.y && score_checked)
        {
            TextUI.score += 15;
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.gameObject.name == "Character")
        {
            if (!Character.is_shield)
            {
                JumpGameManager.game_continue = false;
            }
            else
            {
                Character.is_shield = false;
            }
        }
    }
}
