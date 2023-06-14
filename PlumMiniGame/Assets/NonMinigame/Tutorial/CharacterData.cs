using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterData : MonoBehaviour
{
    public Tutorial_SceneManager _sceneManager;

    private void Awake()
    {

    }

    public int selectedCharacterNum;

    public void onClickbutton(int id)
    {
        ButtonSoundManager.instance.sound.Play();
        selectedCharacterNum = id;
        _sceneManager.loadMyRoom();
        DataManager.instance.saveData.currentCharacter = id + 1;
        DataManager.instance.saveData.rescuedCharacter.Add(id + 1);
        DataManager.instance.SaveGame();
    }

}
