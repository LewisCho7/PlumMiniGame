using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OX : MonoBehaviour
{
    [SerializeField]
    private Sprite[] ox;
    private SpriteRenderer sr;
    void Start()
    {
        sr = GetComponent<SpriteRenderer>();
        gameObject.SetActive(false);
    }

    public void Popresult(bool check)
    {
        gameObject.SetActive(true);
        StartCoroutine(popresult(check));
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
            sr.sprite = ox[0];
        }
        else
        {
            sr.sprite = ox[1];
        }
    }
    private void TurnDown()
    {
        gameObject.SetActive(false);
    }
}
