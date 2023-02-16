using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ButtonActiver : MonoBehaviour
{
    [SerializeField]
    private GameObject[] char_buybuttons;
    // Start is called before the first frame update
    void Start()
    {
        for(int i=0; i<char_buybuttons.Length; i++) 
        {
            if (Find(i))
            {
                DisableBuyButtons();
            }
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    private bool Find(int id)
    {
        foreach (int i in GameManager.instance.RescuedCharacter)
        {
            if (i == id) return true;
        }
        return false;
    }

    private void DisableBuyButtons()
    {
        //구매불가
    }
}
