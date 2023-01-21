using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Meteo : MonoBehaviour
{
    Rigidbody2D rb;
    [SerializeField]
    private GameObject main_camera;
    // Start is called before the first frame update
    void Start()
    {
        main_camera = GameObject.Find("Main Camera");
        transform.position
            = new Vector3(Random.Range(-280, 280), main_camera.transform.position.y + 650, 0);
        rb = GetComponent<Rigidbody2D>();
        rb.velocity = new Vector3(0, -180, 0);
    }

    // Update is called once per frame
    void Update()
    {

    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        GameManager.game_continue = false;
    }
}
