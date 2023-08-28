using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bird : MonoBehaviour
{
    private GameObject main_cam;
    private GameObject player;

    private Rigidbody2D rb;
    // Start is called before the first frame update
    void Start()
    {
        main_cam = GameObject.Find("Main Camera");
        player = GameObject.Find("player");
        gameObject.transform.position
             = new Vector3(main_cam.transform.position.x - 400, main_cam.transform.position.y + 100);
        rb = GetComponent<Rigidbody2D>();
        rb.velocity = new Vector3(100, 0, 0);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            if (!Player.shield)
            {
                JumpGameManager.on_going = false;
                collision.gameObject.GetComponent<BoxCollider2D>().enabled = false;
            }

            else
            {
                Player.shield = false;
                Rigidbody2D p_rb = player.GetComponent<Rigidbody2D>();
                Vector2 velocity = p_rb.velocity;
                velocity.y = 800;
                p_rb.velocity = velocity;
            }
        }
    }
}
