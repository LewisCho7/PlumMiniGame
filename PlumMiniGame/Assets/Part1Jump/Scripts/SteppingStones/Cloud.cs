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

        Character.CharacterJump(collision);
        if (collision.relativeVelocity.y <= 10 && collision.gameObject.name == "Character")
            Destroy(gameObject);
        if (combo)
        {
            combo = false;
            StartCoroutine(QueueControl());
        }
    }

    IEnumerator QueueControl()
    {
        TextUI.queue.Enqueue(gameObject);
        yield return new WaitForSeconds(5);
        if(TextUI.queue.Count > 0)
        {
            try
            {
                TextUI.queue.Dequeue();
                throw new MissingReferenceException();
            }
            catch (MissingReferenceException)
            {

            }
        }
    }
}
