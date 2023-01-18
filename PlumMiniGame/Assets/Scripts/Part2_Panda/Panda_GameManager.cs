using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Panda_GameManager : MonoBehaviour
{
    // Sprite 정보가 담긴 배열
    [SerializeField] private Sprite[] Imgs = new Sprite[2];
    enum Sprites { panda_default, panda_eat }

    // 판다 정보가 담긴 배열
    [SerializeField] private GameObject[] pandas = new GameObject[3];
    private int[] pandaCnts = {0, 0, 0};

    // 라운드의 시작 및 상태를 알리는 변수
    public static bool isEatingRoundStart = false;
    public static bool isChooseRoundStart = false;

    // 정답 번호를 저장하는 변수
    public static int answerNum;

    // 게임이 끝났는지 상태를 저장하는 변수
    public static bool isEnd = false;

    // 현재 라운드를 저장하는 함수
    public static int currentRound = 0;


    void Update() {
        // 매 라운드마다 실행됨
        // 판다가 먹이를 먹는 로직이 실행됨
        if (isEatingRoundStart && !isEnd) {

            isEatingRoundStart = false;

            currentRound++;

            // 데이터 초기화
            Init();

            if (currentRound <= 11) StartCoroutine(Eat(8 + currentRound / 3, 0.8f - 0.1f * (currentRound / 3)));
            else StartCoroutine(Eat(12, 0.5f));
        }
    }

    /// <summary>
    /// 게임 구현 함수 - 이 함수가 하나의 라운드임
    /// </summary>
    /// <param name="cnt">판다들이 먹을 먹이의 개수(최댓값이 둘 이상이면 +1 가능)</param>
    /// <param name="speed">판다들이 먹이를 먹는 속도</param>
    private IEnumerator Eat(int cnt, float speed) {

        int index;

        while (cnt > 0) {
            // 남은 개수가 1개면 한번만 먹도록 함
            int mode = cnt == 1 ? 0 : Choose(new float[] {4, 6});

            if (mode == 0) {
                cnt--;
                index = Choose(new float[] {33.3f, 33.3f, 33.3f});

                pandaCnts[index]++;

                pandas[index].GetComponent<Image>().sprite = Imgs[(int)Sprites.panda_eat];
                yield return new WaitForSeconds(0.3f);

                pandas[index].GetComponent<Image>().sprite = Imgs[(int)Sprites.panda_default];
                yield return new WaitForSeconds(speed - 0.3f);
                
            } else {
                cnt -= 2;
                index = Choose(new float[] {33.3f, 33.3f, 33.3f});
                
                // 셋 중에 하나를 뽑으면, 그것을 제외한 2개의 인덱스를 구하는 로직
                if (index == 2) index = -1;
                int panda1Index = ++index;
                if (index == 2) index = -1;
                int panda2Index = ++index;

                pandaCnts[panda1Index]++;
                pandaCnts[panda2Index]++;

                pandas[panda1Index].GetComponent<Image>().sprite 
                = pandas[panda2Index].GetComponent<Image>().sprite 
                = Imgs[(int)Sprites.panda_eat];
                yield return new WaitForSeconds(0.3f);

                pandas[panda1Index].GetComponent<Image>().sprite 
                = pandas[panda2Index].GetComponent<Image>().sprite 
                = Imgs[(int)Sprites.panda_default];
                yield return new WaitForSeconds(speed - 0.3f);
            }

            Debug.Log(pandaCnts[0] + " " + pandaCnts[1] + " " + pandaCnts[2]);
        }


        // 최댓값이 하나인지 확인하는 변수
        bool isMaxOnly = false;

        // 최댓값 중복 확인
        // 최댓값이 2개 이상이라면, 그 중 하나를 더 뽑아 한번 더 먹더록 함
        if (pandaCnts[0] == pandaCnts[1]) {

            if (pandaCnts[0] == pandaCnts[2]) answerNum = Choose(new float[] {33.3f, 33.3f, 33.3f});
            else if (pandaCnts[0] > pandaCnts[2]) answerNum = Choose(new float[] {50, 50});
            else { answerNum = 2; isMaxOnly = true; }
        } 
        else {
            int maxIndex = pandaCnts[0] > pandaCnts[1] ? 0 : 1;

            if (pandaCnts[maxIndex] == pandaCnts[2]) answerNum = Choose(new float[] {50 * ~maxIndex, 50 * maxIndex, 50});
            else { answerNum = pandaCnts[maxIndex] > pandaCnts[2] ? maxIndex : 2; isMaxOnly = true; }
        }

        // 최댓값이 중복이었던 경우
        // 판다가 먹이 먹는 모션 추가로 실행
        if (!isMaxOnly) {
            
            Debug.Log("max value is not single!");
            pandaCnts[answerNum]++;
            Debug.Log(pandaCnts[0] + " " + pandaCnts[1] + " " + pandaCnts[2]);

            pandas[answerNum].GetComponent<Image>().sprite = Imgs[(int)Sprites.panda_eat];
            yield return new WaitForSeconds(0.3f);

            pandas[answerNum].GetComponent<Image>().sprite = Imgs[(int)Sprites.panda_default];
            yield return new WaitForSeconds(speed - 0.3f);
        }

        Debug.Log(answerNum);
        isChooseRoundStart = true;
    }

    // 변수 초기화 함수
    private void Init() {
        pandaCnts = new int[] {0, 0, 0};
        Panda_UIManager.inputAnswer = -1;
    }

    // 랜덤 구현 함수
    int Choose (float[] probs) {

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
