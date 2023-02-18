using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Collection_BackBtn : MonoBehaviour
{
    private AudioSource sound;

    void Awake() {
        sound = GetComponent<AudioSource>();
    }

    public void OnClickBackBtn() {
        sound.Play();
        SceneManager.LoadScene("MYROOM");
    }
}
