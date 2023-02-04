using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Cloud : MonoBehaviour
{
    private CapsuleCollider2D col;
    private SpriteRenderer sr;
    private GameObject player;
    private bool combo;

    [SerializeField]
    private Sprite[] cloud_sprites;

    // Start is called before the first frame update
    void Start()
    {
        combo = true;

        col = GetComponent<CapsuleCollider2D>();
        sr = GetComponent<SpriteRenderer>();
        player = GameObject.Find("Character");

        if (GameManager.survived_time < 20)
        {
            sr.sprite = cloud_sprites[0];
        }
        else
        {
            sr.sprite = cloud_sprites[1];
        }
    }

    void Update()
    {
        var position = player.transform.position;

        if (position.y - transform.position.y > 65)
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

        if (combo)
        {
            combo = false;
            StartCoroutine(queueControl());
        }

    }

    IEnumerator queueControl()
    {
        Score.queue.Enqueue(gameObject);
        yield return new WaitForSeconds(5);
        if(Score.queue.Count > 0)
            Score.queue.Dequeue();
    }
}
