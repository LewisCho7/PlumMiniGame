using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Stones : MonoBehaviour
{
    private Collider2D col;
    private GameObject player;
    private SpriteRenderer sr;
    [SerializeField]
    private Sprite[] brick_sprites;
    // Start is called before the first frame update
    void Start()
    {
        col = GetComponent<BoxCollider2D>();
        sr = GetComponent<SpriteRenderer>();

        player = GameObject.Find("Character");

        if(GameManager.survived_time < 20)
        {
            sr.sprite = brick_sprites[0];
        }
        else
        {
            sr.sprite = brick_sprites[1];
        }


        if (GameManager.survived_time < 20)
        {   
            if(Random.Range(1,11) <= 4)
            {
                gameObject.transform.localScale = new Vector3(0.75f, 0.625f, 1);
            }
            else
            {
                gameObject.transform.localScale = new Vector3(1, 0.625f, 1);
            }
        }
        else
        {
            if(Random.Range(1,11) <= 2)
            {
                gameObject.transform.localScale = new Vector3(1, 0.625f, 1);
            }
            else
            {
                gameObject.transform.localScale = new Vector3(0.75f, 0.625f, 1);
            }
        }
    }

    // Update is called once per frame
    void Update()
    {
        var position = player.transform.position;

        if(position.y - transform.position.y >= 60)
        {
            col.isTrigger = false;
        }
        else
        {
            col.isTrigger = true;
        }
    }
}
