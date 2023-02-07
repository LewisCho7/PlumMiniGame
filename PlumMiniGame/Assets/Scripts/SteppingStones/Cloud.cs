using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Cloud : MonoBehaviour
{
    private BoxCollider2D col;
    private SpriteRenderer sr;
    private GameObject player;
    private bool combo;

    [SerializeField]
    private Sprite[] cloud_sprites;

    // Start is called before the first frame update
    void Start()
    {
        combo = true;

        col = GetComponent<BoxCollider2D>();
        sr = GetComponent<SpriteRenderer>();
        player = GameObject.Find("Character");

/*        if (GameManager.survived_time < 20)
        {
            sr.sprite = cloud_sprites[0];
        }
        else
        {
            sr.sprite = cloud_sprites[1];
        }*/
    }

    void Update()
    {

    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.relativeVelocity.y <= 10 && collision.gameObject.name == "Character")
        {
            Rigidbody2D rb = collision.collider.GetComponent<Rigidbody2D>();
            if (rb != null)
            {
                Vector2 velocity = rb.velocity;
                velocity.y = Character.jump_power;
                rb.velocity = velocity;
            }
            Destroy(gameObject);
        }

        if (combo)
        {
            combo = false;
            StartCoroutine(QueueControl());
        }
    }

    IEnumerator QueueControl()
    {
        Score.queue.Enqueue(gameObject);
        yield return new WaitForSeconds(5);
        if(Score.queue.Count > 0)
        {
            try
            {
                Score.queue.Dequeue();
                throw new MissingReferenceException();
            }
            catch (MissingReferenceException)
            {

            }
        }
    }
}
