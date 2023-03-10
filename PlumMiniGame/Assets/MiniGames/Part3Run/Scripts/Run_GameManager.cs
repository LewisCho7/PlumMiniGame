using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

// 전체적인 게임 흐름을 관할하는 스크립트
public class Run_GameManager : MonoBehaviour
{
    public static bool isEasyMode;

    // 3가지 생성 오브젝트 (장애물, 구출 캐릭터, 코인)
    public GameObject obstacleShooter, characterShooter;

    // 게임 시간
    static public float time;

    // 게임 점수
    static public int score;


    // for test
    public GameObject player;
    private Run_PlayerClickEvents click;



    void Awake() {

        isEasyMode = !DataManager.instance.isHardMode;

        time = 0;
        score = 0;

        Application.targetFrameRate = 60;

        // for test
        click = player.GetComponent<Run_PlayerClickEvents>();
    }

    void Update() {
        
        // 게임이 시작되면 각 오브젝트 생성 로직 시작
        if (time <= 0 && Run_Player.isAlive) {
            StartCoroutine(obstacleShooter.GetComponent<Run_ObstacleShooter>().shootStart());
            StartCoroutine(characterShooter.GetComponent<Run_CharacterShooter>().shootStart());
        }

        // 플레이어가 살아있는 동안 시간 갱신
        if (Run_Player.isAlive) {
            time += Time.deltaTime;
        }


        // for test
        if (Input.GetKeyDown(KeyCode.UpArrow)) click.Jump();
        
        if (Input.GetKeyDown(KeyCode.DownArrow)) click.Slide();

        if (Input.GetKeyUp(KeyCode.DownArrow)) click.SlideOff();

        if (Input.GetKeyDown(KeyCode.Space)) click.Rescue();
    }
}
