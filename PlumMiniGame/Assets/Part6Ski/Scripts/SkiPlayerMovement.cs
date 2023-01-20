using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SkiPlayerMovement : MonoBehaviour
{

    private Rigidbody2D rb;
    private float dx;
    private float moveSpeed;
    private void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
    }
    private void Start()
    {
        StartCoroutine(IE_StartMovement());
    }
    private void Update()
    {
        if (!Ski_GameManager.instance.isGameOver)
        {
            dx = Input.GetAxisRaw("Horizontal") * moveSpeed;
        }
        else
        {
            dx = 0;
        }
        //dx = Input.acceleration.x * moveSpeed;

        transform.position += Vector3.down * Ski_GameManager.instance.gameSpeed * Time.deltaTime;
        rb.velocity = new Vector2(dx, 0f);
    }
    private void FixedUpdate()
    {
       
    }   
    private IEnumerator IE_StartMovement()
    {
        moveSpeed = 0f;
        yield return new WaitForSeconds(6f);
        moveSpeed = 500f;
    }
}
