using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class Panda_UIManager : MonoBehaviour
{
    // 다양한 UI를 띄우기 위한 Sprite를 저장하는 배열
    [SerializeField] private Sprite[] basicSprites = new Sprite[9];
    enum Sprites { O = 3, X, gameover, start, go, tutorial }

    // 점수를 나타낼 scroeUI
    private TextMeshProUGUI scoreUI;

    // 재화를 나타낼 coinUI
    private TextMeshProUGUI coinUI;

    // UI를 띄우기 위한 panel
    private GameObject UIpanel;
    // UI의 Sprite를 변경하기 위해 Image 컴포넌트를 저장하는 변수
    private Image img;

    // RoundUI
    [SerializeField] private GameObject RoundPanel;

    // 정답 고르는 3초를 위한 시간 변수
    public static float time = 0;
    // 입력된 정답을 저장할 변수
    // default: -1 (고르지 않았다는 의미)
    public static int inputAnswer = -1;



    void Awake() {
        scoreUI = transform.Find("ScoreUI").Find("Text").GetComponent<TextMeshProUGUI>();

        UIpanel = transform.Find("UIPanel").gameObject;
        img = UIpanel.transform.Find("Image").GetComponent<Image>();
    }

    // 게임이 처음 실행될 때 실행
    // 3, 2, 1 카운트 다운
    // round1 -> start 까지 panel에 띄우는 로직
    IEnumerator Start() {
        UIpanel.SetActive(true);

        // 최초 실행이라면 실행
        // (지금은 무조건 뜨도록 설정)
        if (true) {
            img.sprite = basicSprites[(int)Sprites.tutorial];
            yield return new WaitForSeconds(3);
        }

        for (int i = 2; i >= 0; i--) {
            img.sprite = basicSprites[i];
            yield return new WaitForSeconds(1);
        }

        StartCoroutine(showRoundStartUI(Panda_GameManager.currentRound++));
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

        UIpanel.SetActive(true);

        if (isCorrect) {
            img.sprite = basicSprites[(int) Sprites.O];
            yield return new WaitForSeconds(1);

            scoreUI.text = (int.Parse(scoreUI.text) + 30).ToString();

            // 휴식시간
            UIpanel.SetActive(false);
            yield return new WaitForSeconds(2);
            UIpanel.SetActive(true);

            StartCoroutine(showRoundStartUI(Panda_GameManager.currentRound++));
        } else {
            Panda_GameManager.isEnd = true;

            img.sprite = basicSprites[(int) Sprites.X];
            yield return new WaitForSeconds(1);
            
            UIpanel.GetComponent<Image>().color = new Color(0, 0, 0, 0.7f);
            img.sprite = basicSprites[(int) Sprites.gameover];
        }
    }

    // round n -> start 띄우는 함수
    private IEnumerator showRoundStartUI(int currentRound) {

        UIpanel.SetActive(false);
        StartCoroutine(RoundPanel.GetComponent<Panda_RoundPanel>().ShowRoundPanel(currentRound));
        yield return new WaitForSeconds(1);

        UIpanel.SetActive(true);
        img.sprite = basicSprites[(int) Sprites.start];
        yield return new WaitForSeconds(0.8f);

        UIpanel.SetActive(false);

        // 휴식시간
        yield return new WaitForSeconds(1);

        Panda_GameManager.isEatingRoundStart = true;
    }
}
