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
