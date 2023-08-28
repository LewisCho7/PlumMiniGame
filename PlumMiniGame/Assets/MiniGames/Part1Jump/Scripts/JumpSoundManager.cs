using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class JumpSoundManager : MonoBehaviour
{
    public AudioSource audio;
    public static JumpSoundManager instance;

    void Awake()
    {
        if (instance == null)
        {
            instance = this;
        }
        else
        {
            if (instance != this)
            {
                Destroy(this.gameObject);
            }
        }
    }

    // Start is called before the first frame update
    void Start()
    {
        audio = GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {

    }
}
