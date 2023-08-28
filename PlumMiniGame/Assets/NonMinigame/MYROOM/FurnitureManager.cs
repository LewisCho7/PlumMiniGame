using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class FurnitureManager : MonoBehaviour
{
    private List<string> furnitures = new List<string>();
    public GameObject[] furnitureObjects;
    private Image spriteImage;
    public bool isSecond = false;

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
            for (int i = 1; i <= furnitureObjects.Length; i++)
            {
                string s;
                if (i < 10)
                {
                    s = "0" + i;
                }
                else if (i > 11)
                {
                    s = "" + (i + 8);
                }
                else
                {
                    s = "" + i;
                }
                if(id1 == s)
                {
                    furnitureObjects[i - 1].SetActive(true);
                    furnitureObjects[i - 1].GetComponent<FurnitureObjects>().spriteID = id;

                    if(id1 == "01" || id1 == "02")
                    {
                        Sprite sprite = Resources.Load<Sprite>("FurnitureSprites/" + id);
                        furnitureObjects[i-1].GetComponent<SpriteRenderer>().sprite = sprite;
                        break;
                    }
                    else if (id1 == "20" || id1 == "21" || id1 == "22")
                    {
                        spriteImage = furnitureObjects[i - 1].GetComponent<Image>();
                        Sprite sprite = Resources.Load<Sprite>("FurnitureSprites/" + id);
                        spriteImage.sprite = sprite;
                        spriteImage.SetNativeSize();
                        furnitureObjects[i - 1].SetActive(false);
                        break;
                    }
                    else
                    {
                        spriteImage = furnitureObjects[i - 1].GetComponent<Image>();

                        Sprite[] sprites = Resources.LoadAll<Sprite>("FurnitureSprites/Furn/" + id1);
                        int id2 = int.Parse(id.Substring(2, 2));
                        spriteImage.sprite = sprites[id2 - 1];
                        spriteImage.SetNativeSize();
                        break;
                    }
                    

                }
            }

        }
    }

    public void showSwitchedFurn()
    {
        foreach(GameObject furniture in furnitureObjects)
        {
           furniture.SetActive(true);
            string sprite_id = furniture.GetComponent<FurnitureObjects>().spriteID;

            if (isSecond)
            {
                if (!furnitures.Contains(sprite_id) || int.Parse(sprite_id.Substring(0,2)) < 20)
                {
                    furniture.SetActive(false);
                }
            }
            else
            {
                if (!furnitures.Contains(sprite_id) || int.Parse(sprite_id.Substring(0, 2)) >= 20)
                {
                    furniture.SetActive(false);
                }
            }
        }


    }
    

}
