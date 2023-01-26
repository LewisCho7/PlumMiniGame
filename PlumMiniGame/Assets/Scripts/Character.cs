using System.Collections;
using UnityEngine;

public class Character : MonoBehaviour
{

    public static float jump_power;
    public static bool is_shield;

    [SerializeField]
    private float move_speed;

    private Rigidbody2D rb;
    void Start()
    {
        jump_power = 800;
        is_shield = false;
        rb = GetComponent<Rigidbody2D>();
        StartCoroutine(PlayerJump());
    }

    void Update()
    {
       // Debug.Log(jump_power);
        if (Input.GetKey(KeyCode.RightArrow) || Input.GetKey(KeyCode.D))
        {
            gameObject.transform.position += new Vector3(move_speed, 0, 0);
        }
        else if (Input.GetKey(KeyCode.LeftArrow) || Input.GetKey(KeyCode.A))
        {
            gameObject.transform.position -= new Vector3(move_speed, 0, 0);
        }

    }
    IEnumerator PlayerJump()
    {
        yield return null;
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        rb.velocity = Vector2.up * jump_power;
        if (Spring.spring)
        {
            Spring.spring = false;
            jump_power /= 2;
        }

    }
}
