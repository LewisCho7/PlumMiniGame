using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Panda_UIManager : MonoBehaviour
{
    // 숫자 Sprite를 저장하는 배열
    [SerializeField] private Sprite[] numberSprites = new Sprite[10];

    // 다양한 UI를 띄우기 위한 Sprite를 저장하는 배열
    [SerializeField] private Sprite[] basicSprites = new Sprite[6];
    enum Sprites { O, X, gameover, start, go, round}

    // UI를 띄우기 위한 panel
    [SerializeField] private GameObject panel;
    

    // UI의 크기를 변경하기 위해 RectTransform 컴포넌트를 저장하는 변수
    private RectTransform imgTransform;
    // UI의 Sprite를 변경하기 위해 Image 컴포넌트를 저장하는 변수
    private Image img;

    // 정답 고르는 3초를 위한 시간 변수
    private float time = 0;
    // 입력된 정답을 저장할 변수
    // default: -1 (고르지 않았다는 의미)
    public static int inputAnswer = -1;



    void Awake() {
        imgTransform = panel.transform.Find("Image").GetComponent<RectTransform>();
        img = panel.transform.Find("Image").GetComponent<Image>();
    }

    // 게임이 처음 실행될 때 실행
    // 3, 2, 1 카운트 다운
    // round1 -> start 까지 panel에 띄우는 로직
    IEnumerator Start() {
        panel.SetActive(true);

        for (int i = 3; i > 0; i--) {

            imgTransform.sizeDelta = new Vector2(numberSprites[i].rect.width, numberSprites[i].rect.height);

            img.sprite = numberSprites[i];
            yield return new WaitForSeconds(1);
        }

        imgTransform.sizeDelta = new Vector2(720, 1280);

        StartCoroutine(showRoundStartUI(1));
    }

    void Update() {
        if (Panda_GameManager.isChooseRoundStart) {
            time += Time.deltaTime;

            // 3초를 넘기면 오답 처리 및 update 함수 종료
            if (time > 3) {
                StartCoroutine(showOX(false));
                return;
            }

            if (inputAnswer == -1) return;

            time = 0;

            StartCoroutine(showOX(inputAnswer == Panda_GameManager.answerNum));
        }
    }

    // OX를 띄우는 함수
    private IEnumerator showOX(bool isCorrect) {

        // 이 함수가 호출되었다는 것은 선택 라운드가 끝났음을 의미
        Panda_GameManager.isChooseRoundStart = false;

        panel.SetActive(true);

        if (isCorrect) {
            img.sprite = basicSprites[(int) Sprites.O];
            yield return new WaitForSeconds(0.5f);

            panel.SetActive(false);
            yield return new WaitForSeconds(0.5f);
            panel.SetActive(true);

            StartCoroutine(showRoundStartUI(Panda_GameManager.currentRound));
        } else {
            Panda_GameManager.isEnd = true;

            img.sprite = basicSprites[(int) Sprites.X];
            yield return new WaitForSeconds(0.5f);
            
            panel.GetComponent<Image>().color = new Color(0, 0, 0, 0.7f);
            img.sprite = basicSprites[(int) Sprites.gameover];
        }
    }

    // round n -> start 띄우는 함수
    private IEnumerator showRoundStartUI(int currentRound) {
        img.sprite = basicSprites[(int) Sprites.round];
        yield return new WaitForSeconds(0.8f);

        img.sprite = basicSprites[(int) Sprites.start];
        yield return new WaitForSeconds(0.8f);

        panel.SetActive(false);

        Panda_GameManager.isEatingRoundStart = true;
    }
}
