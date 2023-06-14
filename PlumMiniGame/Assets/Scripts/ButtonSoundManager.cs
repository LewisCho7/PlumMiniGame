using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// 기본 버튼 사운드를 재생하기 위한 클래스 <br/>
/// ButtonSoundManager.instance.sound.Play();
/// </summary>
public class ButtonSoundManager : MonoBehaviour
{
    public AudioSource sound;

    public static ButtonSoundManager instance = null;

    void Awake() {
        if (instance == null) instance = this;
        else if (instance != this) Destroy(gameObject);
        
        DontDestroyOnLoad(gameObject);
    }
}
