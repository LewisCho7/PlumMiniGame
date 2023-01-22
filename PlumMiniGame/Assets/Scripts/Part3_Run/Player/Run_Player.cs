using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Run_Player : MonoBehaviour
{
    // 캐릭터 스킨
    public Sprite CharacterSkin;

    // 플레이어의 생존 여부 저장 변수
    static public bool isAlive;

    // HARD 모드 전용
    // 플레이어 체력
    static public int Life;

    // 기본 설정
    void Awake() {

        isAlive = false;
        Life = 100;

        GetComponent<SpriteRenderer>().sprite = CharacterSkin;
        gameObject.AddComponent<PolygonCollider2D>();
    }

    // 장애물과 충돌 시 호출되는 함수
    private void OnTriggerEnter2D(Collider2D collider) {
        if (collider.gameObject.tag == "Obstacle") {
            isAlive = false;
            transform.gameObject.SetActive(false);
        }
    }
}
