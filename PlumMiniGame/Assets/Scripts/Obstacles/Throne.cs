using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Throne : MonoBehaviour
{
    private GameObject player;
    private CapsuleCollider2D col;
    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.Find("Character");
        col = GetComponent<CapsuleCollider2D>();
    }

    // Update is called once per frame
    void Update()
    {
        var position = player.transform.position;
        if (position.y - transform.position.y > 80)
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
        var position = player.transform.position;

        if(position.y - transform.position.y > 50)
        {
            if (!Character.is_shield)
            {
                GameManager.game_continue = false;
            }
            else
            {
                Character.is_shield = false;
            }
        }
    }
}
