using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class meteo : MonoBehaviour
{
    private GameObject main_cam;
    Rigidbody2D rb;
    // Start is called before the first frame update
    void Start()
    {
        main_cam = GameObject.Find("Main Camera");
        transform.position
            = new Vector3(Random.Range(-280, 280), main_cam.transform.position.y + 650, 0);
        rb = GetComponent<Rigidbody2D>();
        rb.velocity = new Vector3(0, -180, 0);
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
                Player.shield = false;
        }
    }
}
