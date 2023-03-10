using System.Collections;
using System.Collections.Generic;
using Unity.Burst.Intrinsics;
using UnityEngine;

public class ThroneBrick : MonoBehaviour
{
    private GameObject player;
    private EdgeCollider2D col;

    private SpriteRenderer sr;
    [SerializeField]
    private Sprite[] thrones;

    private bool combo;
    // Start is called before the first frame update
    void Start()
    {
        combo = false;
        player = GameObject.Find("Character");
        col = GetComponent<EdgeCollider2D>();

        if (JumpGameManager.survived_time < 20)
        {
            if (Random.Range(1, 11) <= 6)
            {
                gameObject.transform.localScale = new Vector3(0.75f, 1.1424f, 1);
            }
            else
            {
                gameObject.transform.localScale = new Vector3(1, 1.1424f, 1);
            }
        }
        else
        {
            if (Random.Range(1, 11) <= 3)
            {
                gameObject.transform.localScale = new Vector3(1, 1.1424f, 1);
            }
            else
            {
                gameObject.transform.localScale = new Vector3(0.75f, 1.1424f, 1);
            }
        }

        sr = GetComponent<SpriteRenderer>();
        if(JumpGameManager.survived_time < 20)
        {
            sr.sprite = thrones[0];
        }
        else
        {
            sr.sprite = thrones[1];
        }
    }

    // Update is called once per frame
    void Update()
    {

    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        var position = player.transform.position;
        if(position.y - transform.position.y > 70)
        {
            if (!Character.is_shield)
            {
                JumpGameManager.game_continue = false;
            }
            else
            {
                Character.is_shield = false;
            }
        }

        Character.CharacterJump(collision);
        if (combo)
        {
            combo = false;
            StartCoroutine(queueControl());
        }
    }

    IEnumerator queueControl()
    {
        TextUI.queue.Enqueue(gameObject);
        yield return new WaitForSeconds(5);
        if (TextUI.queue.Count > 0)
            TextUI.queue.Dequeue();
    }
}
