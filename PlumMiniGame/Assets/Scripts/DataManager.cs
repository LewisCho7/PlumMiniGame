using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;


[System.Serializable]
public class SaveData
{
    public bool isFirstExecute; // 게임 최초 실행 (튜토리얼)
    public int unlockedGameNum; // 잠금 해제된 게임 수
    public bool[] isFirstPlay; // 각 게임별 최초 실행 여부 (튜토리얼)
    public int[] highScore;    // 각 게임별 최고 점수
    public int currentCharacter; // 현재 대표 캐릭터

    public float currentBonus; // 현재 점수 보너스
    public int currentCoin;    // 현재 보유 코인

    public List<int> furnatureList;
    // 가구 리스트
    public List<int> rescuedCharacter;
    // 구출한 캐릭터 목록
    public int dupNum;
    // 삼각형 유리조각으로 변경


}



public class DataManager : MonoBehaviour
{
    public static DataManager instance;
    string path;
    public SaveData saveData;
    public bool isHardMode;

    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            if (instance != this)
            {
                Destroy(this.gameObject);   // 이미 존재한다면 새로 생성된 오브젝트 제거
            }
        }
    }
    private void Start()
    {
#if UNITY_EDITOR
        path = Path.Combine(Application.dataPath, "database.json");

#else   
        path = Path.Combine(Application.persistentDataPath, "database.json");
#endif
        LoadGame();
    }

    public void LoadGame()
    {
        saveData = new SaveData();

        if (!File.Exists(path))
        {
            InitData();
        }
        else
        {
            string loadJson = File.ReadAllText(path);
            saveData = JsonUtility.FromJson<SaveData>(loadJson);
            /*if(saveData != null)
            {
                LoadData();
            }*/
        }
    }

    public void SaveGame()
    {
        /*saveData = new SaveData();
        saveData.isFirstExecute = GameManager.instance.IsFirstExecute;
        saveData.unlockedGameNum = GameManager.instance.UnlockedGameNum;
        saveData.currentCharacter = GameManager.instance.CurrentCharacter;
        saveData.currentBonus = GameManager.instance.CurrentBonus;
        saveData.currentCoin = GameManager.instance.CurrentCoin;
        saveData.isFirstPlay = new bool[5];
        saveData.highScore = new int[5];
        saveData.furnatureList = new List<int>();
        saveData.rescuedCharacter = new List<int>();

        for (int i = 0; i < GameManager.instance.IsFirstPlay.Length; i++)
        {
            saveData.isFirstPlay[i] = GameManager.instance.IsFirstPlay[i];
        }
        for (int i = 0; i < GameManager.instance.HighScore.Length; i++)
        {
            saveData.highScore[i] = GameManager.instance.HighScore[i];
        }
        for (int i = 0; i < GameManager.instance.FurnatureList.Count; i++)
        {
            saveData.furnatureList.Add(GameManager.instance.FurnatureList[i]);
        }
        for (int i = 0; i < saveData.rescuedCharacter.Count; i++)
        {
            saveData.rescuedCharacter.Add(GameManager.instance.RescuedCharacter[i]);
        }*/

        string json = JsonUtility.ToJson(saveData);
        File.WriteAllText(path, json);
    }

    private void InitData()
    {
        saveData.isFirstExecute = true;
        saveData.unlockedGameNum = 2;
        saveData.isFirstPlay = new bool[] { true, true, true, true, true };
        saveData.highScore = new int[5] {0,0,0,0,0};
        saveData.currentCharacter = 0;
        saveData.currentBonus = 1.0f;
        saveData.currentCoin = 0;
        saveData.furnatureList = new List<int>();
        saveData.rescuedCharacter = new List<int>();
        saveData.dupNum = 0;
        //LoadData();
        string json = JsonUtility.ToJson(saveData);
        File.WriteAllText(path, json);
    }
    private void LoadData()
    {
        GameManager.instance.IsFirstExecute = saveData.isFirstExecute;
        GameManager.instance.UnlockedGameNum = saveData.unlockedGameNum;
        GameManager.instance.CurrentCharacter = saveData.currentCharacter;
        GameManager.instance.CurrentBonus = saveData.currentBonus;
        GameManager.instance.CurrentCoin = saveData.currentCoin;
        GameManager.instance.DupNum = saveData.dupNum;
        for(int i = 0; i < saveData.isFirstPlay.Length; i++)
        {
            GameManager.instance.IsFirstPlay[i] = saveData.isFirstPlay[i];
        }
        for(int i = 0; i < saveData.highScore.Length; i++)
        {
            GameManager.instance.HighScore[i] = saveData.highScore[i];
        }
        for(int i = 0; i < saveData.furnatureList.Count; i++)
        {
            GameManager.instance.FurnatureList.Add(saveData.furnatureList[i]);
        }
        for(int i = 0; i< saveData.rescuedCharacter.Count; i++)
        {
            GameManager.instance.RescuedCharacter.Add(saveData.rescuedCharacter[i]);
        }
    }
}
