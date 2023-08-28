using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlatformJump : MonoBehaviour
{
    private float jumpforce;
    void Start()
    {
        jumpforce = 800f;
    }


    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.relativeVelocity.y <= 0f)
        {
            Rigidbody2D rb = collision.gameObject.GetComponent<Rigidbody2D>();
            if (rb != null)
            {
                Vector2 velocity = rb.velocity;
                velocity.y = jumpforce;
                rb.velocity = velocity;
            }
        }
    }
}
