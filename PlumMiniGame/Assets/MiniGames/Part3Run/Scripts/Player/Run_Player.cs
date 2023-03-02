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
    static public float Life;

    // 기본 설정
    void Awake() {

        isAlive = false;
        Life = 100;

        GetComponent<SpriteRenderer>().sprite = CharacterSkin;
        gameObject.AddComponent<PolygonCollider2D>();
    }

    private bool flag = true;

    void Update() {

        Debug.Log(Life);

        if (Life <= 0) isAlive = false;

        if (Run_GameManager.time > 0) {

            // 게임 시작하면 애니메이션 시작
            // 한번만 실행하기 위해 flag 변수 사용
            if (flag) {
                GetComponent<Animator>().enabled = true;
                flag = false;
            }

            if (!Run_GameManager.isEasyMode) Life -= Time.deltaTime * 2;
        }
    }

    // 장애물과 충돌 시 호출되는 함수
    private void OnTriggerEnter2D(Collider2D collider) {
        if (collider.gameObject.tag == "Obstacle") {
            Life = 0;
            isAlive = false;
            transform.gameObject.SetActive(false);
        }
    }
}
