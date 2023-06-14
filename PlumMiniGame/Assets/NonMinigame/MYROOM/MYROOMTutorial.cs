using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MYROOMTutorial : MonoBehaviour
{
    [SerializeField]
    private AudioClip myRoomBgm;

    public List<GameObject> tutorialLists;
    public GameObject tutorialPanel;

    private int tutorialIndex = 1;

    IEnumerator Start()
    {
        yield return new WaitForSeconds(0.01f);
        if (DataManager.instance.saveData.isFirstExecute)
        {
            startTutorial();
        }
        else
        {
            BGMSoundManager.instance.sound.clip = myRoomBgm;
            if (!BGMSoundManager.instance.sound.isPlaying)
            {
                BGMSoundManager.instance.sound.Play();
            }
            gameObject.SetActive(false);
        }
        
        
    }

  

    private void startTutorial() { 
        tutorialPanel.SetActive(true);
        tutorialLists[0].SetActive(true);
    }

    public void onClickNext()
    {
        if (tutorialIndex == 7)
        {
            BGMSoundManager.instance.sound.clip = myRoomBgm;
            BGMSoundManager.instance.sound.Play();

            tutorialPanel.SetActive(false);
            DataManager.instance.saveData.isFirstExecute = false;
            DataManager.instance.SaveGame();
            gameObject.SetActive(false);
            return;
        }
        tutorialLists[tutorialIndex - 1].SetActive(false);
        tutorialLists[tutorialIndex].SetActive(true);
        tutorialIndex++;
    }
}
