using System.Collections;
using UnityEngine;

public class CharacterMove : MonoBehaviour
{
    [SerializeField]
    private float jump_power;
    [SerializeField]
    private float move_speed;

    private Rigidbody2D rb;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        StartCoroutine(PlayerMove());
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.RightArrow) || Input.GetKeyDown(KeyCode.D))
            gameObject.transform.position += new Vector3(move_speed, 0, 0);
        else if (Input.GetKeyDown(KeyCode.LeftArrow) || Input.GetKeyDown(KeyCode.A))
            gameObject.transform.position -= new Vector3(move_speed, 0, 0);
    }
    IEnumerator PlayerMove()
    {
        var jumping_term = new WaitForSeconds(0.8f);
        while (true)
        {
            yield return null;
            rb.velocity = Vector2.up * jump_power;
            yield return jumping_term;
        }
    }
}
