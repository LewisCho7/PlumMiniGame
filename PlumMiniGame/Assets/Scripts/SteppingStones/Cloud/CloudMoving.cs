using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CloudMoving : MonoBehaviour
{
    Rigidbody2D rb;
    float starting_x;
    // Start is called before the first frame update
    void Start()
    {
        gameObject.transform.position
            = new Vector3(Random.Range(-280, 280), 690, 0);

        rb = GetComponent<Rigidbody2D>();
        rb.velocity += new Vector2(0, -140);
        starting_x = transform.position.x;
    }

    // Update is called once per frame
    void Update()
    {
        rb.velocity = new Vector2(0, -140);
    }
}
