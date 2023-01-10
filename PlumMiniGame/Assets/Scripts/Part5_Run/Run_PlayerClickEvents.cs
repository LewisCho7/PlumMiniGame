using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Run_PlayerClickEvents : MonoBehaviour
{
    private Rigidbody2D rigid;
    public Sprite slidingSprite;
    public Sprite CharacterSkin;
    [SerializeField] private float jumpPower = 600f;
    private bool isOnGround = true;

    void Awake() {
        rigid = GetComponent<Rigidbody2D>();
    }

    public void Jump() {
        if (isOnGround) {
            // rigid.gravityScale = 0;
            // StartCoroutine(JumpMove(transform.position, new Vector3(0, 200, 0), 0.3f));
            
            // //StartCoroutine(LerpMove(transform.position, new Vector3(0, -200, 0), 0.2f));
            // rigid.gravityScale = 100;

            rigid.AddForce(Vector2.up * jumpPower, ForceMode2D.Impulse);
        }
    }

    private IEnumerator JumpMove(Vector3 startPosition, Vector3 distance, float time) {

        float timer = 0;
        while (transform.position.y < startPosition.y + 200) {
            timer += Time.deltaTime;
            float percent = timer / time;
            transform.position = startPosition + distance * percent;
            yield return null;
        }

        var pos = transform.position;

        timer = 0;
        while (timer <= time) {
            timer += Time.deltaTime;
            float percent = timer / time;
            transform.position = pos + new Vector3(0, -200, 0) * percent;
            yield return null;
        }
    }

    public void Slide() {
        transform.localScale = new Vector3(1, 1, 1);
        GetComponent<SpriteRenderer>().sprite = slidingSprite;
        Destroy(GetComponent<PolygonCollider2D>());
        gameObject.AddComponent<PolygonCollider2D>();

        rigid.velocity = Vector2.zero;
        rigid.AddForce(Vector2.down * jumpPower, ForceMode2D.Impulse);
    }

    public void SlideOff() {
        transform.localScale = new Vector3(-1, 1, 1);
        GetComponent<SpriteRenderer>().sprite = CharacterSkin;
        Destroy(GetComponent<PolygonCollider2D>());
        gameObject.AddComponent<PolygonCollider2D>();
    }

    private void OnCollisionEnter2D(Collision2D collision) {
        if (collision.gameObject.name == "Floor") isOnGround = true;
    }

    private void OnCollisionExit2D(Collision2D collision) {
        isOnGround = false;
    }
}
