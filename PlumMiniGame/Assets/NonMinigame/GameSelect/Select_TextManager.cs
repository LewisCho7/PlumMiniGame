using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Select_TextManager : MonoBehaviour
{
    private int[] normalGamePrice = new int[] {0,0,500,900,1500};
    private int[] hardGamePrice = new int[] {0, 600, 1000, 1400, 1800 };

    private TextMeshProUGUI tmp;
    private void OnEnable()
    {
        tmp = GetComponent<TextMeshProUGUI>();
        if (!DataManager.instance.isHardMode) 
        {
            if (DataManager.instance.saveData.unlockedNormalGameNum == 5)
            {
                tmp.text = "�̴ϰ��� 6�� �غ����Դϴ�!";
            }
            else
            {
                tmp.text = "�̴ϰ��� " + (DataManager.instance.saveData.unlockedNormalGameNum + 1).ToString() + "�� �ر��Ͻðڽ��ϱ�?\n " + normalGamePrice[DataManager.instance.saveData.unlockedNormalGameNum];
            }

        }
        else
        {
            if (DataManager.instance.saveData.unlockedHardGameNum == 5)
            {
                tmp.text = "�̴ϰ��� 6�� �غ����Դϴ�!";
            }
            else
            {
                tmp.text = "�̴ϰ��� " + (DataManager.instance.saveData.unlockedHardGameNum + 1).ToString() + "�� �ر��Ͻðڽ��ϱ�?\n " + hardGamePrice[DataManager.instance.saveData.unlockedHardGameNum];
            }
        }
        
    }
   
}
