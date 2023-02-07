using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OX : MonoBehaviour
{
    [SerializeField]
    private GameObject O;
    [SerializeField]
    private GameObject X;
    void Start()
    {
        O.SetActive(false);
        X.SetActive(false);
    }

    public void Popresult(bool check)
    {
        StartCoroutine(popresult(check));
        //StopCoroutine("popresult");
    }

    private IEnumerator popresult(bool check)
    {
        setResultUI(check);
        yield return new WaitForSeconds(1);
        TurnDown();
    }
    private void setResultUI(bool check)
    {
        if (check)
        {
            O.SetActive(true);
        }
        else
        {
            X.SetActive(true);
        }
    }
    private void TurnDown()
    {
        O.SetActive(false);
        X.SetActive(false);
    }
}
