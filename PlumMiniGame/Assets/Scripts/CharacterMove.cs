using System.Collections;
using UnityEngine;

public class CharacterMove : MonoBehaviour
{
    [SerializeField]
    private float jump_power;
    [SerializeField]
    private float move_speed;

    private Rigidbody2D rb;
    private bool jump;
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        StartCoroutine(PlayerJump());
        jump = true;
    }

    void Update()
    {

        if (Input.GetKey(KeyCode.RightArrow) || Input.GetKey(KeyCode.D))
            gameObject.transform.position += new Vector3(move_speed, 0, 0);
        else if (Input.GetKey(KeyCode.LeftArrow) || Input.GetKey(KeyCode.A))
            gameObject.transform.position -= new Vector3(move_speed, 0, 0);
    }
    IEnumerator PlayerJump()
    {
        //var jumping_term = new WaitForSeconds(0.8f);
        while (GameManager.game_continue)
        {
            yield return null;
            if (jump)
            {
                rb.velocity = Vector2.up * jump_power;
            }
            jump = false;
            //yield return jumping_term;
        }
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        jump = true;
    }
}
