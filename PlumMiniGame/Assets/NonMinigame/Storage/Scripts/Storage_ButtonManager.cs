using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Storage_ButtonManager : MonoBehaviour
{
    public static Storage_ButtonManager instance;
    public List<GameObject> storage;
    public GameObject list;
    public GameObject selectButton;
    public GameObject background;
    public string selectedID;


    private int int_id;
    private bool isList;

    private void Awake()
    {
        instance = this;
    }

    private void Start()
    {
        isList = true;
    }
    public void onClickList(int StorageIndex)
    {
        //list 종류에 따라서 바꾸기
        int_id = StorageIndex;
        //string_id = (StorageIndex < 10) ? ("0" + StorageIndex.ToString()) : StorageIndex.ToString();
        background.SetActive(true);
        storage[int_id - 1].SetActive(true);
        list.SetActive(false);
        selectButton.SetActive(false);
        isList = false;
    }

    public void onClickBack()
    {
        if (!isList)
        {
            storage[int_id - 1].SetActive(false);
            background.SetActive(false);
            list.SetActive(true);
            selectButton.SetActive(false);
            isList = true;
        }
        else
        {
            GameSceneManager.instance.myRoomSceneLoad();
        }

    }
    public void onClickSelect()
    {
        string id1 = selectedID.Substring(0, 2);
        foreach(string id in DataManager.instance.saveData.myRoomFurnitures)
        {
            if(id.Substring(0, 2) == id1)
            {
                DataManager.instance.saveData.myRoomFurnitures.Remove(id);
                break;
            }
        }
        DataManager.instance.saveData.myRoomFurnitures.Add(selectedID);
        DataManager.instance.SaveGame();
        GameSceneManager.instance.myRoomSceneLoad();
    }
}
