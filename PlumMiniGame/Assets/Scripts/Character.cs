using System.Collections;
using UnityEngine;

public class Character : MonoBehaviour
{

    public static float jump_power;
    public static bool is_shield;

    [SerializeField]
    private float move_speed;
    [SerializeField]
    private GameObject shield_on_img;

    private Rigidbody2D rb;
    void Start()
    {
        jump_power = 800;
        is_shield = false;
        rb = GetComponent<Rigidbody2D>();
    }

    void Update()
    {
        if (Input.GetKey(KeyCode.RightArrow) || Input.GetKey(KeyCode.D))
        {
            gameObject.transform.position += new Vector3(move_speed, 0, 0);
        }
        else if (Input.GetKey(KeyCode.LeftArrow) || Input.GetKey(KeyCode.A))
        {
            gameObject.transform.position -= new Vector3(move_speed, 0, 0);
        }

        Vector3 dir = Vector3.zero;
        dir.x = Input.acceleration.x;
        if (dir.sqrMagnitude > 1) dir.Normalize();
        dir *= Time.deltaTime;
        dir.y = rb.velocity.y;
        rb.velocity = new Vector2(dir.x * move_speed, dir.y);

        if (is_shield)
        {
            shield_on_img.SetActive(true);
        }
        else
        {
            shield_on_img.SetActive(false);
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        rb.velocity = Vector2.up * jump_power;
        if (Spring.spring)
        {
            Spring.spring = false;
            jump_power /= 1.8f;
        }
    }
}
