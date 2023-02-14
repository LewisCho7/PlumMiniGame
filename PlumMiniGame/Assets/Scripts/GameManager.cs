using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static GameManager instance;

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


    private void Awake()
    {
        instance = this;
    }

}
