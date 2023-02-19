using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FurnitureManager : MonoBehaviour
{
    private List<string> furnitures = new List<string>();
    public GameObject[] furnitureObjects;

    /*private enum FurnitureType
    {
        Wallpaper, Floor, Tablechair, Bed, Closet, Shelf, Clock, Window, Accessory1, Accessory2
    }*/

    private void Start()
    {
        addFromData();
        showFurnitures();
 
    }



    private void addFromData()
    {
        if (DataManager.instance != null)
        {
            foreach (string id in DataManager.instance.saveData.myRoomFurnitures)
            {
                furnitures.Add(id);
            }
        }
        furnitures.Sort();
    }

    private void showFurnitures()
    {
        foreach(string id in furnitures)
        {
            string id1 = id.Substring(0, 2);
            for (int i = 3; i <= 13; i++)
            {
                if(id1 == (i < 10 ? "0" : "") + i)
                {
                    furnitureObjects[i - 1].SetActive(true);
                    furnitureObjects[i - 1].GetComponent<FurnitureObjects>().spriteID = id;
                }
            }

        }
    }
    
  /* private void setSpriteID()
    {
        for(int i = 0; i < furnitureObjects.Length; i++)
        {
            if (furnitureObjects[i].activeSelf)
            {
                foreach
            }
        }
    }*/

}
