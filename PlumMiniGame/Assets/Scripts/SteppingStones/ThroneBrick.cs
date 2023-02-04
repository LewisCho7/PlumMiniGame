using System.Collections;
using System.Collections.Generic;
using Unity.Burst.Intrinsics;
using UnityEngine;

public class ThroneBrick : MonoBehaviour
{
    private GameObject player;
    private EdgeCollider2D col;

    private bool combo;
    // Start is called before the first frame update
    void Start()
    {
        combo = false;
        player = GameObject.Find("Character");
        col = GetComponent<EdgeCollider2D>();

        if (GameManager.survived_time < 20)
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
    }

    // Update is called once per frame
    void Update()
    {
        var position = player.transform.position;

        if (position.y - transform.position.y >= 50)
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
        if(position.y - transform.position.y > 70)
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
        if (Score.queue.Count > 0)
            Score.queue.Dequeue();
    }
}
