using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

// 게임의 UI를 담당하는 스크립트
public class Run_UIManager : MonoBehaviour
{
    // 처음 카운트다운용 sprite
    [SerializeField] private Sprite[] CountingSprites = new Sprite[3];

    // 기본적인 정보들을 나타내는 sprite
    [SerializeField] private Sprite[] BasicSprites = new Sprite[3];
    private enum Sprites { start, go, gameover }

    // 위의 sprite를 띄우기 위한 panel
    private GameObject UIPanel;
    // panel의 내용을 담당하는 image
    private Image panelImage;

    // 점수 및 재화를 표시하는 textUI
    public static TextMeshProUGUI scoreUI, coinUI;

    // UI 바인딩
    void Awake() {
        UIPanel = transform.Find("PanelUI").gameObject;
        panelImage = UIPanel.transform.Find("Image").GetComponent<Image>();
        
        scoreUI = transform.Find("ScoreUI").Find("Text").GetComponent<TextMeshProUGUI>();
        coinUI = transform.Find("CoinUI").Find("Text").GetComponent<TextMeshProUGUI>();   
    }

    // 처음 미니게임 시작 시 호출
    // 3, 2, 1 카운트 다운 후 start -> go 출력
    // 시간당 점수 계산
    IEnumerator Start() {

        // panel 활성화
        UIPanel.SetActive(true);

        // 카운트 다운 출력
        for (int i = 2; i >= 0; i--) {
            panelImage.sprite = CountingSprites[i];
            yield return new WaitForSeconds(1);
        }

        // start -> go 출력
        panelImage.sprite = BasicSprites[(int) Sprites.start];
        yield return new WaitForSeconds(1);

        panelImage.sprite = BasicSprites[(int) Sprites.go];
        yield return new WaitForSeconds(0.8f);
        
        // 플레이어 생존 여부 true 변경과 함께 게임 시작
        Run_Player.isAlive = true;

        // panel 비활성화
        UIPanel.SetActive(false);

        // 시간당 점수 계산 및 체력 감소(HARD)
        while (Run_Player.isAlive) {
            yield return new WaitForSeconds(1);
            
            // 1초 기다리던 중에 죽었으면 끝
            if (!Run_Player.isAlive) break;

            // 점수 UI 업데이트
            scoreUI.text = (int.Parse(scoreUI.text) + 10).ToString();

            // HARD - 초당 체력 -2
            if (!Run_GameManager.isEasyMode) Run_Player.Life -= 2;
        }
    }

    void Update() { 
        // 플레이어가 죽었다면 gameover 출력
        if (Run_GameManager.time > 0 && !Run_Player.isAlive) {
            UIPanel.SetActive(true);
            panelImage.sprite = BasicSprites[(int) Sprites.gameover];
            UIPanel.GetComponent<Image>().color = new Color(0, 0, 0, 0.7f);

            Run_GameManager.time = 0;
        }
    }
}
