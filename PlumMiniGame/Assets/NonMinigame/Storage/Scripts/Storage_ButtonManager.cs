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
    public GameObject lockedItemObject;
    public List<GameObject> lockedItems;



    private int int_id;
    private bool isList;

    private void Awake()
    {
        instance = this;
    }

    private void Start()
    {
        isList = true;
        list.SetActive(true);
    }
    public void onClickList(int StorageIndex)
    {
        ButtonSoundManager.instance.sound.Play();
        //list 종류에 따라서 바꾸기
        int_id = StorageIndex;
        //string_id = (StorageIndex < 10) ? ("0" + StorageIndex.ToString()) : StorageIndex.ToString();
        background.SetActive(true);

        // id별 창고 활성화
        storage[int_id - 1].SetActive(true);

        // lockeditem 활성화
        lockedItemObject.SetActive(true);

        // id별 현재 존재 가구 조사 함수 실행
        setUnlockedItem(int_id);

        //가구 list 비활성화
        list.SetActive(false);

        selectButton.SetActive(false);
        isList = false;
    }

    public void onClickBack()
    {
        ButtonSoundManager.instance.sound.Play();
        if (!isList)
        {
            storage[int_id - 1].SetActive(false);
            background.SetActive(false);
            list.SetActive(true);
            selectButton.SetActive(false);
            lockedItemObject.SetActive(false);
            isList = true;
        }
        else
        {
            GameSceneManager.instance.myRoomSceneLoad();
        }

    }
    public void onClickSelect()
    {
        ButtonSoundManager.instance.sound.Play();
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

    private void setUnlockedItem(int int_id)
    {
        foreach (GameObject i in lockedItems){
            i.SetActive(true);
        }
        string string_id;
        string_id = (int_id < 10) ? ("0" + int_id.ToString()) : int_id.ToString();

        foreach (string id in DataManager.instance.saveData.furnatureList)
        {
            if(id.Substring(0,2) == string_id)
            {
                lockedItems[int.Parse(id.Substring(2, 2)) - 1].SetActive(false);
            }
        }
    
    }
}
