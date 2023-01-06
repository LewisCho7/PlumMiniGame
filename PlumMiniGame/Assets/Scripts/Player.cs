using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    public Sprite CharacterSkin;
    static public bool isAlive = false;

    void Awake() {
        GetComponent<SpriteRenderer>().sprite = CharacterSkin;
        gameObject.AddComponent<PolygonCollider2D>();
    }

    void OnTriggerEnter2D(Collider2D collider2D) {
        if (collider2D.gameObject.tag == "Obstacle") isAlive = false; transform.gameObject.SetActive(false);
    }
}
