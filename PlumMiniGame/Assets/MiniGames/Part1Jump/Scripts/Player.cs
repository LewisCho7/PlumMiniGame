using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    [SerializeField]
    private int move_speed;
    [SerializeField]
    private int tilt_coef;
    [SerializeField]
    private GameObject shield_obj;
    public static bool shield;

    private AudioSource jumpsound;
    // Start is called before the first frame update
    void Start()
    {
        shield = false;
        jumpsound = GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {
        if (JumpGameManager.on_going)
        {
#if UNITY_EDITOR
            if (Input.GetKey(KeyCode.RightArrow) || Input.GetKey(KeyCode.D))
            {
                gameObject.transform.position += new Vector3(move_speed, 0, 0);
            }
            else if (Input.GetKey(KeyCode.LeftArrow) || Input.GetKey(KeyCode.A))
            {
                gameObject.transform.position -= new Vector3(move_speed, 0, 0);
            }
#else
            Vector3 dir = Vector3.zero;
            dir.x = Input.acceleration.x;
            dir.y = rb.velocity.y;
            rb.velocity = new Vector2(dir.x * move_speed * tilt_coef, dir.y);
#endif // UNITY_EDITOR
        }
        shield_obj.SetActive(shield);
    }

/*    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.transform.tag == "Item")
        {
            shield = true;
            Destroy(collision.gameObject);
        }
    }*/

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.transform.tag == "Item")
        {
            shield = true;
            Destroy(collision.gameObject);
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.transform.tag == "Stepped")
        {
            if (collision.relativeVelocity.y >= 0)
                jumpsound.Play();
        }
    }
}
