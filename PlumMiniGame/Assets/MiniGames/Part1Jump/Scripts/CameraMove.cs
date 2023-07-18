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
        rb.velocity = new Vector2(0, 150);
        StartCoroutine(CameraSpeed());
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

            int y = 150;
            while ( y < 210)
            {
                yield return null;
                y = (((int)JumpGameManager.survived_time + 10) / 5) * 150 / 2;
                rb.velocity = new Vector2(0, y);
            }
        }
    }
}
