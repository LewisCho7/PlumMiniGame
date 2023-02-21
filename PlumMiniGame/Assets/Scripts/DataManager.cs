using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;
using UnityEngine.SceneManagement;


[System.Serializable]
public class SaveData
{
    public bool isFirstExecute; // ���� ���� ���� (Ʃ�丮��)
    public int unlockedNormalGameNum; // ��� ������ �븻 ���̵� ���� ��
    public int unlockedHardGameNum; // ��� ������ �ϵ� ���̵� ���� ��

    public bool[] isFirstPlay; // �� ���Ӻ� ���� ���� ���� (Ʃ�丮��)
    public int[] highScore;    // �� ���Ӻ� �ְ� ����
    public int currentCharacter; // ���� ��ǥ ĳ����

    public float currentBonus; // ���� ���� ���ʽ�
    public int currentCoin;    // ���� ���� ����

    public List<string> furnatureList;
    // ���� ����Ʈ
    public List<string> myRoomFurnitures;

    public List<int> rescuedCharacter;
    // ������ ĳ���� ���
    public int dupNum;
    // �ﰢ�� ������������ ����


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
                Destroy(this.gameObject);   // �̹� �����Ѵٸ� ���� ������ ������Ʈ ����
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
        saveData.furnatureList = new List<string>();
        saveData.myRoomFurnitures = new List<string>();
        saveData.rescuedCharacter = new List<int>();
        saveData.dupNum = 0;
        string json = JsonUtility.ToJson(saveData);
        File.WriteAllText(path, json);
    }
}
