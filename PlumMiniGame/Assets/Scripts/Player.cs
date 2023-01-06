using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    public Sprite CharacterSkin;

    void Awake() {
        GetComponent<SpriteRenderer>().sprite = CharacterSkin;
        gameObject.AddComponent<PolygonCollider2D>();
    }
}
