using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Tutorial_SceneManager : MonoBehaviour
{
    [SerializeField]
    private GameObject[] afterGameObject;
    [SerializeField]
    private GameObject[] beforeGameObject;

    public void loadMyRoom()
    {
        StartCoroutine(IE_loadMyRoom());
    }

    IEnumerator IE_loadMyRoom()
    {
        for(int i = 0; i < beforeGameObject.Length; i++)
        {
            beforeGameObject[i].SetActive(false);
        }
        for(int i = 0; i < afterGameObject.Length; i++)
        {
            afterGameObject[i].SetActive(true);
        }
        yield return new WaitForSeconds(3f);
        SceneManager.LoadScene("MYROOM");
    }
}
