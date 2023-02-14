using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;


[System.Serializable]
public class SaveData
{
    public bool isFirstExecute;
    public int unlockedGameNum;
    public bool[] isFirstPlay;
    public int[] highScore;
    public int currentCharacter; // 선택 언제?

    public float currentBonus;
    public int currentCoin;

    public List<int> furnatureList;
    public List<int> rescuedCharacter;
    public int dupNum;
}


public class DataManager : MonoBehaviour
{
    public static DataManager instance;
    string path;
    SaveData saveData;

    private void Awake()
    {
        if(instance == null)
        {
            instance = this;            
        }
    }
    private void Start()
    {
        path = Path.Combine(Application.dataPath, "database.json");
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
            if(saveData != null)
            {
                LoadData();
            }
        }

    }

    public void SaveGame()
    {
        saveData = new SaveData();
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
        }

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
        LoadData();
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
