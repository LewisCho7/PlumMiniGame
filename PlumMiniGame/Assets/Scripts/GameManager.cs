using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static GameManager instance = null;      // �̱��� ���

    // JSON���� �ҷ�����
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
                Destroy(this.gameObject);   // �̹� �����Ѵٸ� ���� ������ ������Ʈ ����
            }
        }

    }
    private void Start()
    {
    }
}
