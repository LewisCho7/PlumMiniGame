using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class CameraMove : MonoBehaviour
{
    private Rigidbody2D rb;
    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        rb.velocity += new Vector2(0, 140);
    }

    void Update()
    {
        if (!GameManager.game_continue)
        {
            rb.velocity = new Vector3(0, 0, 0);
        }
    }

    IEnumerator CameraSpeed()
    {
        while (GameManager.game_continue)
        {
            yield return null;
            int y = (((int)GameManager.survived_time + 5) / 5) * (140 / 5);
            if (y > 280)
            {
                y = 280;
            }
            rb.velocity = new Vector2(0, y);
        }
    }
}
