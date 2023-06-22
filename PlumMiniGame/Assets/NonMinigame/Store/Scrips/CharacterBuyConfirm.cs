using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using UnityEngine;

public class CharacterBuyConfirm : MonoBehaviour
{
    public static int current_item_id;

    public void Buy(GameObject This)
    {
        ButtonSoundManager.instance.sound.Play();
        int price = (current_item_id <= 12) ? 100 : 200;
        price = (current_item_id <= 5) ? 150 : price;

        if (current_item_id <= 5)
        {
            DataManager.instance.saveData.currentCoin -= price;
        }
        else
        {
            DataManager.instance.saveData.dupNum -= price;
        }
        DataManager.instance.saveData.rescuedCharacter.Add(current_item_id);
        DataManager.instance.SaveGame();

        This.SetActive(false);
    }

    public void Close(GameObject clicked_obj)
    {
        ButtonSoundManager.instance.sound.Play();
        clicked_obj.SetActive(false);
    }
}
