using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Select_Manager : MonoBehaviour
{
    public List<GameObject> minigames;
    public GameObject unlockPanel;
    private int[] normalGamePrice = new int[] { 0, 0, 500, 900, 1500 };
    private int[] hardGamePrice = new int[] { 0, 600, 1000, 1400, 1800 };

    private void Start()
    {
        unlockedGameSet();
    }

    public void unlockedGameSet()
    {
        for(int i = 0; i < minigames.Count; i++)
        {
            minigames[i].gameObject.SetActive(false);
        }
        // 잠금 해제된 게임 표시
        if (DataManager.instance.isHardMode)
        {
            for (int i = 0; i < DataManager.instance.saveData.unlockedHardGameNum; i++)
            {
                minigames[i].SetActive(true);
            }
        }
        else
        {
            for (int i = 0; i < DataManager.instance.saveData.unlockedNormalGameNum; i++)
            {
                minigames[i].SetActive(true);
            }
        }
    }

    public void onClickUnlock()
    {
        // Unlock 버튼을 눌렀을 때 적용
        unlockPanel.SetActive(true);
        ButtonSoundManager.instance.sound.Play();
    }

    public void onClickCancel()
    {
        unlockPanel.SetActive(false);
        ButtonSoundManager.instance.sound.Play();
    }

    public void onClickUnlockGame()
    {
        ButtonSoundManager.instance.sound.Play();
        if (!DataManager.instance.isHardMode)
        {
            if (DataManager.instance.saveData.unlockedNormalGameNum == 5)
            {
                return;
            }

            if (DataManager.instance.saveData.currentCoin < normalGamePrice[DataManager.instance.saveData.unlockedNormalGameNum])
            {
                unlockPanel.SetActive(false);
                return;
            }
            else
            {
                DataManager.instance.saveData.currentCoin -= normalGamePrice[DataManager.instance.saveData.unlockedNormalGameNum];
                minigames[DataManager.instance.saveData.unlockedNormalGameNum].SetActive(true);
                DataManager.instance.saveData.unlockedNormalGameNum++;
            }
        }
        else
        {
            if (DataManager.instance.saveData.unlockedHardGameNum == 5)
            {
                return;
            }
            if (DataManager.instance.saveData.currentCoin < hardGamePrice[DataManager.instance.saveData.unlockedHardGameNum])
            {
                unlockPanel.SetActive(false);
                return;
            }
            else
            {
                DataManager.instance.saveData.currentCoin -= hardGamePrice[DataManager.instance.saveData.unlockedHardGameNum];
                minigames[DataManager.instance.saveData.unlockedHardGameNum].SetActive(true);
                DataManager.instance.saveData.unlockedHardGameNum++;
            }
        }
        DataManager.instance.SaveGame();
        unlockedGameSet();
        unlockPanel.SetActive(false);
    }

}
