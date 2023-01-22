using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// 코인을 생성하는 스크립트
public class Run_CoinShooter : MonoBehaviour
{
    // 코인 prefab 정보
    [SerializeField] private GameObject coin;

    // 발사 시작 함수
    public IEnumerator shootStart() {

        // 플레이어가 살아있을 때만 코인 생성
        while (Run_Player.isAlive) {

            // 20%의 확률로 코인 생성
            if (Choose(new float[] {2, 8}) == 0) Shoot();
            
            // 1초 대기
            yield return new WaitForSeconds(1);
        }
    }
    
    // 코인 오브젝트 생성 함수
    private void Shoot() {

        GameObject newObj;  // 새로 생성될 오브젝트를 저장하는 변수

        // 코인 오브젝트 생성
        newObj = Instantiate(coin, transform.position, Quaternion.identity);

        // 시간에 따른 속도 변화 반영
        int extraSpeed = (int)Run_GameManager.time / 5 * 100;
        extraSpeed = extraSpeed > 500 ? 500 : extraSpeed;

        newObj.GetComponent<Rigidbody2D>().velocity = new Vector2(-(500 + extraSpeed), 0);
        Destroy(newObj, 5f);
    }

    private int Choose (float[] probs) {

        float total = 0;

        foreach (float elem in probs) {
            total += elem;
        }

        float randomPoint = Random.value * total;

        for (int i= 0; i < probs.Length; i++) {
            if (randomPoint < probs[i]) {
                return i;
            }
            else {
                randomPoint -= probs[i];
            }
        }
        return probs.Length - 1;
    }
}
