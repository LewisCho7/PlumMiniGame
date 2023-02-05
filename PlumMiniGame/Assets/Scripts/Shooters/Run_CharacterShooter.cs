using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// 구출 캐릭터를 생성하는 스크립트
public class Run_CharacterShooter : MonoBehaviour
{
    // 구출 캐릭터 prefab 배열
    [SerializeField] private GameObject[] characterSprites = new GameObject[3];

    // 발사 시작 함수
    public IEnumerator shootStart() {

        bool isCalled = false;

        // 플레이어가 살아있을 때만 실행
        while (Run_Player.isAlive) {

            // 1초, 13초, 25초에 구출 캐릭터를 생성하기 위한 로직
            if (Run_GameManager.time >= 1 && !isCalled) {
                isCalled = true;
                for (int i = 0; i < 2; i++) {
                    Shoot();
                    yield return new WaitForSeconds(12);
                }
            }

            // EASY - 33.3초 이후에는 50% 확률로 4.2초의 텀을 두고 생성함
            // HARD - 30초 이후에는 동일 확률로 8.4초의 텀을 두고 생성함
            if (Run_GameManager.time >= (Run_GameManager.isEasyMode ? 33.3f : 30)) {
                if (Choose(new float[] {5, 5}) == 1) Shoot();
                yield return new WaitForSeconds(4.2f * (Run_GameManager.isEasyMode ? 1 : 2));
            } else yield return null;
        }
    }
    
    private void Shoot() {

        GameObject newObj;  // 새로 생성될 오브젝트를 저장하는 변수

        // 구출 캐릭터 생성
        newObj = Instantiate(characterSprites[Random.Range(0, 3)], transform.position, Quaternion.identity);

        // 시간 흐름에 따른 속도 변화 반영
        int extraSpeed = (int)Run_GameManager.time / 5 * 100;
        extraSpeed = extraSpeed > 500 ? 500 : extraSpeed;

        newObj.GetComponent<Rigidbody2D>().velocity = new Vector2(-(500 + extraSpeed), 0);
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
