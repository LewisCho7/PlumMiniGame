using System.Collections;
using System.Collections.Generic;
using Unity.Burst.Intrinsics;
using UnityEngine;

public class Brick : MonoBehaviour
{
    private bool combo;
    private SpriteRenderer sr;

    [SerializeField]
    private Sprite[] brick_sprites;

    // Start is called before the first frame update
    void Start()
    {
        combo = true;
        sr = GetComponent<SpriteRenderer>();
            
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
        if (Score.queue.Count > 0)
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
