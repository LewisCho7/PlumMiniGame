using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SkiPlayerMovement : MonoBehaviour
{

    private Rigidbody2D rb;
    private float dx;
    private float moveSpeed;
    private bool isEditor;
    private void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
    }
    private void Start()
    {
        StartCoroutine(IE_StartMovement());
#if UNITY_EDITOR
        isEditor = true;
#else   
        isEditor = false;
#endif
    }
    private void Update()
    {
        if (!Ski_GameManager.instance.isGameOver)
        {
            if (isEditor)
            {
                dx = Input.GetAxisRaw("Horizontal") * moveSpeed;
            }
            else
                dx = Input.acceleration.x * moveSpeed;
        }
        else
        {
            dx = 0;
        }


        if (Ski_GameManager.instance.timer > 0f)
        {
            transform.position += Vector3.down * Ski_GameManager.instance.gameSpeed * Time.deltaTime;

        }
        rb.velocity = new Vector2(dx, 0f);
    }
 
    private IEnumerator IE_StartMovement()
    {
        moveSpeed = 0f;
        if (DataManager.instance.saveData.isFirstPlay[4])
        {
            yield return new WaitForSeconds(3f);
        }
        yield return new WaitForSeconds(6f);
        moveSpeed = 700f;
    }
}
