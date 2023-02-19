using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TutorialManager : MonoBehaviour
{
    
    void Start()
    {
        if (DataManager.instance.saveData.isFirstExecute)
        {
            startTutorial();
        }
    }

    private void startTutorial() { 



        
    }



}
