using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using UnityEngine;

public class FurnitureWarningManager : MonoBehaviour
{
    public static int current_item_id;
    
    public void Buy(GameObject This)
    {
        int price = (current_item_id % 10 <= 2) ? 100 : 200;
        price = (current_item_id % 10 == 4) ? 500 : price;
        string id_string = (current_item_id < 1000) ? "0" + current_item_id.ToString() 
            : current_item_id.ToString();

        DataManager.instance.saveData.currentCoin -= 150;
        DataManager.instance.saveData.furnatureList.Add(id_string);
        DataManager.instance.SaveGame();

        This.SetActive(false);
    }

    public void Close(GameObject clicked_obj)
    {
        ButtonSoundManager.instance.sound.Play();
        clicked_obj.SetActive(false);
    }
}