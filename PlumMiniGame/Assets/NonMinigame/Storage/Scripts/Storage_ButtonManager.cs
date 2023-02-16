using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Storage_ButtonManager : MonoBehaviour
{
    public GameObject storage;
    public GameObject list;
    public GameObject selectButton;

    private bool isList;

    private void Start()
    {
        isList = true;
    }
    public void onClickList()
    {
        //list 종류에 따라서 바꾸기
        storage.SetActive(true);
        list.SetActive(false);
        selectButton.SetActive(false);
        isList = false;
    }

    public void onClickBack()
    {
        if (!isList)
        {
            storage.SetActive(false);
            list.SetActive(true);
            selectButton.SetActive(false);
            isList = true;
        }
        else
        {
            GameSceneManager.instance.myRoomSceneLoad();
        }
        
    }
}
