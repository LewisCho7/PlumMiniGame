using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Storage_ButtonManager : MonoBehaviour
{
    public List<GameObject> storage;
    public GameObject list;
    public GameObject selectButton;
    public List<List<GameObject>> furnitures;
    private string string_id;
    private int int_id;
    private bool isList;

    private void Start()
    {
        isList = true;
    }
    public void onClickList(int StorageIndex)
    {
        //list 종류에 따라서 바꾸기
        int_id = StorageIndex;
        string_id = (StorageIndex < 10) ? ("0" + StorageIndex.ToString()) : StorageIndex.ToString();
        storage[int_id].SetActive(true);
        list.SetActive(false);
        selectButton.SetActive(false);
        isList = false;
    }

    public void onClickBack()
    {
        if (!isList)
        {
            //storage[storageIndex].SetActive(false);
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

    }
}
