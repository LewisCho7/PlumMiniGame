using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class CharacterText : MonoBehaviour
{
    public GameObject datamanager;
    CharacterData characterData;
    private TextMeshProUGUI tmp;
    string characterName;

    private void OnEnable()
    {
        tmp = GetComponent<TextMeshProUGUI>();
        characterData = datamanager.GetComponent<CharacterData>();
        switch (characterData.selectedCharacterNum)
        {
            case 0:
                characterName = "지바를";
                break;
            case 1:
                characterName = "프럼을";
                break;
            case 2:
                characterName = "이브를";
                break;
        }
        tmp.text = characterName + " 선택하셨군요!\n 그럼 이제 우리의 홈타운에 가요!";
    }
}
