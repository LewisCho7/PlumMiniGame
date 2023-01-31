using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Stones : MonoBehaviour
{
    private Collider2D col;
    private GameObject player;
    // Start is called before the first frame update
    void Start()
    {
        col = null;
        try
        {
            col = GetComponent<BoxCollider2D>();
            if (col == null)
            {
                throw new MissingComponentException();
            }
        }
        catch (MissingComponentException)
        {
            col = GetComponent<CapsuleCollider2D>();
        }
        player = GameObject.Find("Character");

        if (GameManager.survived_time < 20)
        {
            gameObject.transform.localScale = new Vector3(0.6f, 1, 1);
        }
        else
        {
            if(Random.Range(1,11) <= 4)
            {
                gameObject.transform.localScale = new Vector3(1.5f, 1, 1);
            }
            else
            {
                gameObject.transform.localScale = new Vector3(0.6f, 1, 1);
            }
        }
    }

    // Update is called once per frame
    void Update()
    {
        var position = player.transform.position;

        if(position.y - transform.position.y > 80)
        {
            col.isTrigger = false;
        }
        else
        {
            col.isTrigger = true;
        }
    }
}
