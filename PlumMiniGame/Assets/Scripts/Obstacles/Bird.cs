using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bird : MonoBehaviour
{
    Rigidbody2D rb;
    [SerializeField]
    private GameObject main_camera;
    // Start is called before the first frame update
    void Start()
    {
        main_camera = GameObject.Find("Main Camera");
        gameObject.transform.position = main_camera.transform.position;
        rb = GetComponent<Rigidbody2D>();
        rb.velocity = new Vector3(100, 0, 0);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (!Character.is_shield)
        {
            GameManager.game_continue = false;
        }
        else
        {
            Character.is_shield = !Character.is_shield;
        }
    }
}
