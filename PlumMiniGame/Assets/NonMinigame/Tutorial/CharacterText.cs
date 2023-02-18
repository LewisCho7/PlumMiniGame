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
                characterName = "���ٸ�";
                break;
            case 1:
                characterName = "������";
                break;
            case 2:
                characterName = "�̺긦";
                break;
        }
        tmp.text = characterName + " �����ϼ̱���!\n �׷� ���� �츮�� ȨŸ� ����!";
    }
}
