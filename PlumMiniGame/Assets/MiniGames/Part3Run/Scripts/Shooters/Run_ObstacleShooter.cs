using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// 장애물 오브젝트를 생성하는 스크립트
public class Run_ObstacleShooter : MonoBehaviour
{
    // 바닥장애물 정보를 저장하는 배열
    public GameObject[] bottomObstacles = new GameObject[3];

    // 천장장애물 정보를 저장하는 배열
    public GameObject[] topObstacles = new GameObject[3];

    // 장애물 속도
    private int speed = 500;

    // EASY 모드
    // 30초 이후 생성 주기
    private float[] epoch = { 1.4f, 1.3f, 1.5f };
    

    // 오브젝트 발사 시작 함수
    public IEnumerator shootStart() {

        // 플레이어가 살아있을 때만 실행
        while (Run_Player.isAlive) {

            // 60% 확률로 바닥, 40% 확률로 천장 장애물 생성

            // 30초 이하 - 2초 주기
            if (Run_GameManager.time <= 30) {
                Shoot(Choose(new float[] {6, 4}));
                yield return new WaitForSeconds(2f);
            } 
            // 30초 이상일때 - 위의 주기를 따름
            else {
                for (int i = 0; i < 3; i++) {
                    Shoot(Choose(new float[] {6, 4}));
                    yield return new WaitForSeconds(epoch[i] * (Run_GameManager.isEasyMode ? 2 : 1));
                }
            }
        }
    }

    // 장애물 오브젝트 발사 함수
    private void Shoot(int index) {

        GameObject newObj;

        // 0이면 바닥, 1이면 천장 장애물 생성
        if (index == 0) {
            newObj = Instantiate(bottomObstacles[Choose(new float[] {33.3f, 33.3f, 33.3f})], new Vector2(800, 634), Quaternion.identity);
        } else {
            newObj = Instantiate(topObstacles[Choose(new float[] {33.3f, 33.3f, 33.3f})], new Vector2(800, 818), Quaternion.identity);
        }

        // 시간에 따른 속도 변화 반영
        int extraSpeed = (int)Run_GameManager.time / 5 * 100;
        extraSpeed = extraSpeed > 500 ? 500 : extraSpeed;

        newObj.GetComponent<Rigidbody2D>().velocity = new Vector2(-(speed + extraSpeed), 0);
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
