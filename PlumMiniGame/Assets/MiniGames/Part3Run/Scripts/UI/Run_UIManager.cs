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
    [SerializeField] private Sprite[] BasicSprites = new Sprite[4];
    private enum Sprites { start, go, gameover, tutorial }

    // 위의 sprite를 띄우기 위한 panel
    private GameObject UIPanel;
    // panel의 내용을 담당하는 image
    private Image panelImage;

    private GameObject ScorePanel;

    // 점수 및 재화를 표시하는 textUI
    private TextMeshProUGUI scoreUI;

    private GameObject HPBar;


    [SerializeField] private GameObject SoundManager;
    [SerializeField] private AudioClip GameOverSound;

    // UI 바인딩
    void Awake() {
        UIPanel = transform.Find("PanelUI").gameObject;
        panelImage = UIPanel.transform.Find("Image").GetComponent<Image>();

        ScorePanel = transform.Find("ScorePanel").gameObject;
        
        scoreUI = transform.Find("ScoreUI").Find("Text").GetComponent<TextMeshProUGUI>();

        HPBar = transform.Find("HPBar").gameObject;
        HPBar.SetActive(!Run_GameManager.isEasyMode);
    }

    // 처음 미니게임 시작 시 호출
    // 3, 2, 1 카운트 다운 후 start -> go 출력
    // 시간당 점수 계산
    IEnumerator Start() {

        // panel 활성화
        UIPanel.SetActive(true);

        // 첫 실행이라면 튜토리얼 실행
        if (DataManager.instance.saveData.isFirstPlay[2]) {

            DataManager.instance.saveData.isFirstPlay[2] = false;
            DataManager.instance.SaveGame();

            panelImage.sprite = BasicSprites[(int) Sprites.tutorial];
            yield return new WaitForSeconds(3);
        }

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

            // 점수 업데이트
            Run_GameManager.score += 10;
        }
    }

    void Update() { 

        // 점수 UI 업데이트
        scoreUI.text = Run_GameManager.score.ToString();

        // 플레이어가 죽었다면 gameover 출력
        if (Run_GameManager.time > 0 && !Run_Player.isAlive) {
            StartCoroutine(GameOver());
            Run_GameManager.time = 0;


            AudioSource audio = SoundManager.GetComponent<AudioSource>();

            audio.clip = GameOverSound;
            audio.loop = false;
            audio.Play();
        }
    }

    private IEnumerator GameOver() {
        UIPanel.SetActive(true);
        panelImage.sprite = BasicSprites[(int) Sprites.gameover];
        UIPanel.GetComponent<Image>().color = new Color(0, 0, 0, 0.7f);

        yield return new WaitForSeconds(2);

        UIPanel.SetActive(false);
        ScorePanel.SetActive(true);

        ScorePanel.transform.Find("ScoreBoard").Find("ScoreText").GetComponent<TextMeshProUGUI>().text = Run_GameManager.score.ToString();
    }
}
