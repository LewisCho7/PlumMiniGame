using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CollideWithThrone : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            if (Player.shield)
                Player.shield = false;
            else
                JumpGameManager.on_going = false;
        }
    }
}
