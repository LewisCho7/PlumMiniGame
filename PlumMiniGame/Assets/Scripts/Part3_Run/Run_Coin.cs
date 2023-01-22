using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// 코인 오브젝트 스크립트
public class Run_Coin : MonoBehaviour
{
    // 충돌 감지
    void OnTriggerEnter2D(Collider2D collider) {

        // 생성된 위치에 장애물이나 구출 캐릭터가 있다면 즉시 파괴하여 중첩 방지
        if (collider.gameObject.tag != "Player") Destroy(this.gameObject);
        
        // 플레이어와 충돌
        // UI 반영 및 fadeout 효과
        if (collider.gameObject.tag == "Player") {
            Run_UIManager.coinUI.text = (int.Parse(Run_UIManager.coinUI.text) + 1).ToString();
            StartCoroutine(FadeOut(this.gameObject));
        }
    }

    // 0.2초에 걸쳐서 fadeout 효과를 구현하는 함수
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
