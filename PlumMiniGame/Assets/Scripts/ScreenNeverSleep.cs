using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScreenNeverSleep : MonoBehaviour
{
   
    void Start()
    {
        Screen.sleepTimeout = 300;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
