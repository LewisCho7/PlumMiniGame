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
        rb.velocity = new Vector2(0, 140);
        //StartCoroutine(CameraSpeed());
    }

    void Update()
    {
        if (!JumpGameManager.game_continue)
        {
            rb.velocity = new Vector3(0, 0, 0);
        }
    }

    IEnumerator CameraSpeed()
    {
        while (JumpGameManager.game_continue)
        {
            yield return null;

            int y = 140;
            while ( y < 280)
            {
                yield return null;
                y = (((int)JumpGameManager.survived_time + 5) / 5) * (140 / 5);
                rb.velocity = new Vector2(0, y);
            }
        }
    }
}
