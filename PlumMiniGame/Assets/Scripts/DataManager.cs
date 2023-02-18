using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;
using UnityEngine.SceneManagement;


[System.Serializable]
public class SaveData
{
    public bool isFirstExecute; // 게임 최초 실행 (튜토리얼)
    public int unlockedNormalGameNum; // 잠금 해제된 노말 난이도 게임 수
    public int unlockedHardGameNum; // 잠금 해제된 하드 난이도 게임 수

    public bool[] isFirstPlay; // 각 게임별 최초 실행 여부 (튜토리얼)
    public int[] highScore;    // 각 게임별 최고 점수
    public int currentCharacter; // 현재 대표 캐릭터

    public float currentBonus; // 현재 점수 보너스
    public int currentCoin;    // 현재 보유 코인

    public List<int> furnatureList;
    // 가구 리스트
    public List<int> myRoomFurnitures;

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
        }
    }

    public void SaveGame()
    {
        string json = JsonUtility.ToJson(saveData);
        File.WriteAllText(path, json);
    }

    private void InitData()
    {
        saveData.isFirstExecute = true;
        saveData.unlockedNormalGameNum = 2;
        saveData.unlockedHardGameNum = 1;
        saveData.isFirstPlay = new bool[] { true, true, true, true, true };
        saveData.highScore = new int[5] { 0, 0, 0, 0, 0 };
        saveData.currentCharacter = 0;
        saveData.currentBonus = 1.0f;
        saveData.currentCoin = 0;
        saveData.furnatureList = new List<int>();
        saveData.myRoomFurnitures = new List<int>();
        saveData.rescuedCharacter = new List<int>();
        saveData.dupNum = 0;
        string json = JsonUtility.ToJson(saveData);
        File.WriteAllText(path, json);
        SceneManager.LoadScene("TutorialScene");
    }
}
