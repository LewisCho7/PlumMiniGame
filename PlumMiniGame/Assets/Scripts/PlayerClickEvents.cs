using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerClickEvents : MonoBehaviour
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
            rigid.AddForce(Vector2.up * jumpPower, ForceMode2D.Impulse);
            //transform.position = Vector3.Lerp(transform.position, transform.position + new Vector3(0, 200, 0), 1f);
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
