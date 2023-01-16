using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BricksMoving : MonoBehaviour
{
    Rigidbody2D rb;
    // Start is called before the first frame update
    void Start()
    {
        gameObject.transform.position 
            = new Vector3(Random.Range(-280, 280), 690, 0);

        rb = GetComponent<Rigidbody2D>();
        rb.velocity += new Vector2(0, -140);
    }

    // Update is called once per frame
    void Update()
    {
        rb.velocity = new Vector2(0, -140);
    }
}
