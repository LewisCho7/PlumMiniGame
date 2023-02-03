using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Run_PlayerClickEvents : MonoBehaviour
{
    // 점프 구현을 위한 플레이어의 rigidbody2d 정보
    private Rigidbody2D rigid;

    // 슬라이딩 스킨
    public Sprite slidingSprite;
    // 캐릭터 스킨
    public Sprite CharacterSkin;

    // 점프 파워
    [SerializeField] private float jumpPower = 600f;

    // 플레이어가 땅에 접지 여부 저장하는 변수
    private bool isOnGround = true;

    // 구조 버튼의 활성화 여부 저장하는 변수
    private bool isRescueAvail = false;

    // 플레이어와 충돌한 구출 캐릭터 정보를 저장하는 변수
    private GameObject rescueCharacter;


    void Awake() {
        rigid = GetComponent<Rigidbody2D>();
    }

    // 점프
    public void Jump() {

        // 땅에 닿았을 때만 실행
        if (!isOnGround) return;

        rigid.AddForce(Vector2.up * jumpPower, ForceMode2D.Impulse);
    }

    // 슬라이딩
    public void Slide() {

        // 슬라이딩 스킨은 정방향이므로 방향 변경
        transform.localScale = new Vector3(1, 1, 1);

        // sprite 변경 및 collider 변경
        GetComponent<SpriteRenderer>().sprite = slidingSprite;
        Destroy(GetComponent<PolygonCollider2D>());
        gameObject.AddComponent<PolygonCollider2D>();

        rigid.velocity = Vector2.zero;  // 공중에서도 즉각적인 슬라이딩을 위해 속도 0으로 초기화
        rigid.AddForce(Vector2.down * (jumpPower / 2), ForceMode2D.Impulse);
    }

    // 슬라이딩 버튼에서 손 땠을 때 실행하는 함수
    public void SlideOff() {

        // 기본 스킨이 역방향이므로 방향 변경
        transform.localScale = new Vector3(-1, 1, 1);

        // sprite 변경 및 collider 변경
        GetComponent<SpriteRenderer>().sprite = CharacterSkin;
        Destroy(GetComponent<PolygonCollider2D>());
        gameObject.AddComponent<PolygonCollider2D>();
    }

    // 구출 캐릭터 구출
    public void Rescue() {

        // 버튼이 활성화 상태일때만 실행
        if (!isRescueAvail) return;

        // 점수 UI 업데이트 및 fadeout 효과 적용
        Run_GameManager.score += 100;
        StartCoroutine(FadeOut(rescueCharacter));

        // HARD - 체력 추가
        if (!Run_GameManager.isEasyMode) {
            if (Run_Player.Life + 20 > 100) Run_Player.Life = 100;
            else Run_Player.Life += 20;
        }
    }

    // 땅과 접촉했을 때 알려주는 함수
    private void OnCollisionEnter2D(Collision2D collision) {
        if (collision.gameObject.name == "Floor") isOnGround = true;
    }

    // 점프해서 땅에서 멀어졌을 때 알려주는 함수
    private void OnCollisionExit2D(Collision2D collision) {
        isOnGround = false;
    }

    // 구출 캐릭터랑 충돌 시 구출 버튼 활성화
    private void OnTriggerEnter2D(Collider2D collider) {
        if (collider.gameObject.tag == "Character") {
            isRescueAvail = true;
            rescueCharacter = collider.gameObject;
        }
    }

    // 구출 캐릭터에서 멀어지면 구출 버튼 비활성화
    private void OnTriggerExit2D(Collider2D collider) {
        if (collider.gameObject.tag == "Character") isRescueAvail = false;
    }

    // 0.2초에 걸쳐 fadeout 효과 적용
    private IEnumerator FadeOut(GameObject obj)
    {
        int i = 10;
        while (i > 0)
        {
            i -= 1;
            float f = i / 10.0f;
            Color c = new Color(1, 1, 1, f);
            obj.GetComponent<SpriteRenderer>().color = c;
            yield return new WaitForSeconds(0.02f);
        }

        Destroy(obj);
    }
}
