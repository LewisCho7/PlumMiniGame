using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class Collection_Screen : MonoBehaviour
{
    List<int> myCharacters;
    List<Dictionary<string, object>> CSVData;
    
    private Image CharacterSprite, GradeSprite;
    private TextMeshProUGUI Name, Characteristic, Ability, Story;
    private GameObject Represent;

    [SerializeField] private Sprite[] GradeAssets = new Sprite[3];

    public static int currentIndex;

    private AudioSource sound;

    void Awake() {


        myCharacters = DataManager.instance.saveData.rescuedCharacter;
        CSVData = CSVReader.Read("CharacterData");

        CharacterSprite = transform.Find("Character").GetComponent<Image>();
        Name = transform.Find("Name").GetComponent<TextMeshProUGUI>();
        Characteristic = transform.Find("Characteristic").GetComponent<TextMeshProUGUI>();
        Ability = transform.Find("Ability").GetComponent<TextMeshProUGUI>();
        Story = transform.Find("Story").GetComponent<TextMeshProUGUI>();
        GradeSprite = transform.Find("Grade").GetComponent<Image>();
        Represent = transform.Find("Represent").gameObject;

        sound = GetComponent<AudioSource>();


        currentIndex = 0;

        // 데이터 띄우기
        LoadData(myCharacters[currentIndex]);
    }


    private void LoadData(int ID) {

        var data = FindData(ID);

        if (data == null) return;

        // 캐릭터 이미지 띄우기
        CharacterSprite.sprite = Resources.Load<Sprite>("CharacterSprites/" + ID);

        // 텍스트 띄우기
        Name.text = data["이름"].ToString();
        Characteristic.text = data["특징"].ToString();
        Ability.text = data["능력"].ToString();
        Story.text = data["스토리"].ToString();


        // 등급 띄우기
        string grade = data["등급"].ToString();
        int index;
        if (grade == "common") index = 0;
        else if (grade == "rare") index = 1;
        else index = 2;
        GradeSprite.sprite = GradeAssets[index];

        // 대표 캐릭터 UI 띄우기
        Represent.SetActive(DataManager.instance.saveData.currentCharacter == ID);
    }


    private Dictionary<string, object> FindData(int ID) {

        // ID에 해당하는 데이터 리턴
        foreach (var data in CSVData) {
            if (data["ID"].ToString() == ID.ToString()) return data;
        }

        // 없으면 null 리턴
        Debug.Log("에러: ID(" + ID.ToString() + ")에 해당하는 데이터가 없습니다.");
        return null;
    }


    public void OnClickLeftBtn() {
        if (currentIndex > 0) currentIndex--;
        LoadData(myCharacters[currentIndex]);
        sound.Play();
    }

    public void OnClickRightBtn() {
        if (currentIndex < myCharacters.Count - 1) currentIndex++;
        LoadData(myCharacters[currentIndex]);
        sound.Play();
    }
}