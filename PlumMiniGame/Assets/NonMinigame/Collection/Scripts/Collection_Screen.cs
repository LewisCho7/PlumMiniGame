using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class Collection_Screen : MonoBehaviour
{
    List<int> myCharacters;
    List<Dictionary<string, object>> CSVData;
    
    private Image CharacterAsset;
    private TextMeshProUGUI Name, Characteristic, Ability, Story;
    private string Grade;

    private int temp;
    private int currentIndex;

    void Awake() {
        myCharacters = DataManager.instance.saveData.rescuedCharacter;
        myCharacters.Add(13);
        CSVData = CSVReader.Read("CharacterData");

        CharacterAsset = transform.Find("Character").GetComponent<Image>();
        Name = transform.Find("Name").GetComponent<TextMeshProUGUI>();
        Characteristic = transform.Find("Characteristic").GetComponent<TextMeshProUGUI>();
        Ability = transform.Find("Ability").GetComponent<TextMeshProUGUI>();
        Story = transform.Find("Story").GetComponent<TextMeshProUGUI>();

        temp = -1;
        currentIndex = 0;
    }

    
    void Update() {

        // 페이지 변경이 없었으면 동작X
        if (temp == currentIndex) return;

        temp = currentIndex;
        var data = FindData(myCharacters[currentIndex]);

        if (data != null) {
            Name.text = data["이름"].ToString();
            Characteristic.text = data["특징"].ToString();
            Ability.text = data["능력"].ToString();
            Story.text = data["스토리"].ToString();
            Grade = data["등급"].ToString();
        }
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
}