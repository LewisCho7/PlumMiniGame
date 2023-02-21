using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Collection_RepresentBtn : MonoBehaviour
{
    [SerializeField] private GameObject RepresentImage;
    
    public void OnClickRepresentBtn() {
        ButtonSoundManager.instance.sound.Play();
        DataManager.instance.saveData.currentCharacter
         = DataManager.instance.saveData.rescuedCharacter[Collection_Screen.currentIndex];
        DataManager.instance.SaveGame();
        RepresentImage.SetActive(true);
    }
}
