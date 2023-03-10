using System.Collections;
using UnityEngine;
using UnityEngine.UIElements;

public class Character : MonoBehaviour
{

    public static float tilt_coefficient;
    public static float jump_power;
    public static bool is_shield;
    private bool is_editor;
    [SerializeField]
    private float move_speed;
    [SerializeField]
    private GameObject shield_on_img;

    private Rigidbody2D rb;
    

    void Start()
    {
        tilt_coefficient = 100;
        jump_power = 800;
        is_shield = false;
        if(gameObject.name == "shield")
        {
            gameObject.SetActive(false);
        }
        else
        {
            rb = GetComponent<Rigidbody2D>();
        }

#if UNITY_EDITOR
        is_editor = true;
#else
        is_editor = false;
#endif
    }

    void Update()
    {
        if (JumpGameManager.game_continue)
        {
            if(is_editor)
            {
                if (Input.GetKey(KeyCode.RightArrow) || Input.GetKey(KeyCode.D))
                {
                    gameObject.transform.position += new Vector3(move_speed, 0, 0);
                }
                else if (Input.GetKey(KeyCode.LeftArrow) || Input.GetKey(KeyCode.A))
                {
                    gameObject.transform.position -= new Vector3(move_speed, 0, 0);
                }
            }
            else
            {
                Vector3 dir = Vector3.zero;
                dir.x = Input.acceleration.x;
                dir.y = rb.velocity.y;
                rb.velocity = new Vector2(dir.x * move_speed * tilt_coefficient, dir.y); //x-axis movement by tilt
            }

            if (is_shield)
            {
                shield_on_img.SetActive(true);
            }
            else
            {
                shield_on_img.SetActive(false);
            }
        }
    }

    public static void CharacterJump(Collision2D collision)
    {
        if (collision.relativeVelocity.y <= 0)
        {
            Rigidbody2D rb = collision.collider.GetComponent<Rigidbody2D>();
            if (rb != null)
            {
                Vector2 velocity = rb.velocity;
                velocity.y = jump_power;
                rb.velocity = velocity;
            }
        }
    }
}
