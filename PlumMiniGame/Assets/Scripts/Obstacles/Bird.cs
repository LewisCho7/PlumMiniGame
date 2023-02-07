using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bird : MonoBehaviour
{
    private Rigidbody2D rb;
    private GameObject main_camera;
    private GameObject character;
    private bool score_checked;
    // Start is called before the first frame update
    void Start()
    {
        main_camera = GameObject.Find("Main Camera");
        character = GameObject.Find("Character");
        gameObject.transform.position
            = new Vector3(main_camera.transform.position.x - 400, main_camera.transform.position.y + 100);
        rb = GetComponent<Rigidbody2D>();
        rb.velocity = new Vector3(100, 0, 0);
    }

    // Update is called once per frame
    void Update()
    {
        if(character.transform.position.y > transform.position.y && score_checked)
        {
            TextUI.score += 15;
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.name == "Character")
        {
            if (!Character.is_shield)
            {
                GameManager.game_continue = false;
                Rigidbody2D rb = collision.collider.GetComponent<Rigidbody2D>();
                if (rb != null)
                {
                    Vector2 velocity = rb.velocity;
                    velocity.y = Character.jump_power;
                    rb.velocity = velocity;
                }
            }
            else
            {
                Character.is_shield = !Character.is_shield;
            }
        }
    }
}
