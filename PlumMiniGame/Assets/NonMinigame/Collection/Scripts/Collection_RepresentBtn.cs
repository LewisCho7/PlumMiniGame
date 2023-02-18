using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Collection_RepresentBtn : MonoBehaviour
{
    private AudioSource sound;
    [SerializeField] private GameObject RepresentImage;

    void Awake() {
        sound = GetComponent<AudioSource>();
    }
    
    public void OnClickRepresentBtn() {
        sound.Play();
        DataManager.instance.saveData.currentCharacter
         = DataManager.instance.saveData.rescuedCharacter[Collection_Screen.currentIndex];
        DataManager.instance.SaveGame();
        RepresentImage.SetActive(true);
    }
}
