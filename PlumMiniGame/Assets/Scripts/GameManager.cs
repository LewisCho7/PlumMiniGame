using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static GameManager instance = null;      // 싱글톤 기법

    // JSON에서 불러오기
    public bool IsFirstExecute;
    public int UnlockedGameNum;
    public bool[] IsFirstPlay = new bool[5] {true, true, true, true, true};
    public int[] HighScore = new int[5] {0,0,0,0,0};
    public int CurrentCharacter;
    public float CurrentBonus;
    public int CurrentCoin;
    public List<int> FurnatureList = new List<int>();
    public List<int> RescuedCharacter = new List<int>();
    public int DupNum;


    public bool isHardMode;
    private void Awake()
    {
        if(instance == null)
        {
            instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            if(instance != this)
            {
                Destroy(this.gameObject);   // 이미 존재한다면 새로 생성된 오브젝트 제거
            }
        }

    }
    private void Start()
    {
    }
}
