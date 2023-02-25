using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class FurnitureManager : MonoBehaviour
{
    private List<string> furnitures = new List<string>();
    public GameObject[] furnitureObjects;
    private Image spriteImage;

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
            // int i = 1 부터 시작 + 기본 벽지 에셋 saveData에 추가
            for (int i = 1; i <= 13; i++)
            {
                if(id1 == (i < 10 ? "0" : "") + i)
                {
                    furnitureObjects[i - 1].SetActive(true);
                    furnitureObjects[i - 1].GetComponent<FurnitureObjects>().spriteID = id;

                    if(id1 == "01" || id1 == "02")
                    {
                        Sprite sprite = Resources.Load<Sprite>("FurnitureSprites/" + id);
                        furnitureObjects[i-1].GetComponent<SpriteRenderer>().sprite = sprite;
                        break;
                    }
                    else
                    {
                        spriteImage = furnitureObjects[i - 1].GetComponent<Image>();

                        Sprite[] sprites = Resources.LoadAll<Sprite>("FurnitureSprites/Furn/" + id1);
                        int id2 = int.Parse(id.Substring(2, 2));
                        Debug.Log(id2);
                        spriteImage.sprite = sprites[id2 - 1];
                        spriteImage.SetNativeSize();
                        break;
                    }
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
