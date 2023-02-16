using System.Collections;
using System.Collections.Generic;
using UnityEditor.SearchService;
using UnityEngine;
using UnityEngine.SceneManagement;

public class StoreSceneManager : MonoBehaviour
{
    public void FurnitureStoreLoad()
    {
        SceneManager.LoadScene("FurnitureStore");
    }

    public void CharacterStoreLoad()
    {
        SceneManager.LoadScene("CharacterStore");
    }
}