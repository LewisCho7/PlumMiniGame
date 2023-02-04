using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Storage_ButtonManager : MonoBehaviour
{
    public GameObject storage;
    public GameObject list;

    private bool isList;

    private void Start()
    {
        isList = true;
    }
    public void onClickList()
    {
        //list ������ ���� �ٲٱ�
        storage.SetActive(true);
        list.SetActive(false);
        isList = false;
    }

    public void onClickBack()
    {
        if (!isList)
        {
            storage.SetActive(false);
            list.SetActive(true);
        }
        else
        {
            GameSceneManager.instance.myRoomSceneLoad();
        }
        
    }
}
