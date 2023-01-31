using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Cloud : MonoBehaviour
{
    private CapsuleCollider2D col;
    private GameObject player;

    // Start is called before the first frame update
    void Start()
    {
        col = GetComponent<CapsuleCollider2D>();
        player = GameObject.Find("Character");
    }

    void Update()
    {
        var position = player.transform.position;

        if (position.y - transform.position.y > 60)
        {
            col.isTrigger = false;
        }
        else
        {
            col.isTrigger = true;
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.name == "Character")
        {
            Destroy(gameObject);
        }
    }
}
